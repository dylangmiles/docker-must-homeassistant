using System;
using System.IO;

namespace inverter.Modbus
{
    public class ModbusWriter
    {
        private ISerialPort _serialPort;

        public ModbusWriter(ISerialPort serialPort)
        {
            _serialPort = serialPort;
        }

        public void write(byte deviceId, ushort address, ushort[] values)
        {
            //Construct the request
            var requestLength = 9 + 2 * values.Length;
            var request = new byte[requestLength];
            using (var stream = new MemoryStream(request))
            using (var writer = new BigEndianBinaryWriter(stream))
            {
                writer.Write(deviceId);                     // DeviceId
                writer.Write(0x10);                         // Write multiple registers
                writer.Write(address);                      // Start address
                writer.Write((ushort)values.Length);        // Number of values to write
                writer.Write((byte)(values.Length * 2));    // Number of values to write

                foreach( var value in values)
                {
                    writer.Write(value);
                }

                writer.Write(0x00);                         // CRC
                writer.Write(0x00);                         // CRC
            }

            //Calculate and write the CRC
            var crc = Utils.CalculateCrc(request, 0, requestLength - 2);

            using (var stream = new MemoryStream(request, requestLength - 2, 2))
            using (var writer = new BigEndianBinaryWriter(stream))
            {
                writer.Write(crc);
            }

            //Send the message over the wire
            _serialPort.Write(request, 0, request.Length);


            //Read the response
            var response = new byte[8];
            var read = _serialPort.Read(response, 0, response.Length);

            //Check read length
            if (read != response.Length)
            {
                throw new InvalidDataException($"Invalid length of data read. Expected {response.Length} bytes and got {read} bytes.");
            }


            using (var stream = new MemoryStream(response))
            using (var reader = new BigEndianBinaryReader(stream))
            {
                var returnDeviceId = reader.ReadByte();
                if (returnDeviceId != deviceId) throw new InvalidDataException($"Invalid Device Id. Expected {deviceId} and got {returnDeviceId}.");

                var returnFunctionCode = reader.ReadByte();
                if (returnFunctionCode != 0x10) throw new InvalidDataException($"Invalid Function Code. Expected 0x10 (16) and got 0x{returnFunctionCode:X} ({returnFunctionCode}).");

                var returnAddress = reader.ReadUInt6();
                if (returnAddress != address) throw new InvalidDataException($"Invalid Address. Expected {address} bytes and received {returnAddress}.");

                var returnSensorCount = reader.ReadUInt6();
                if (returnSensorCount != values.Length) throw new InvalidDataException($"Invalid Sensor Count. Expected {values.Length} bytes and received {returnSensorCount}.");

                var returnCrc = reader.ReadUInt6();
                var calcCrc = Utils.CalculateCrc(response, 0, response.Length - 2);

                if (returnCrc != calcCrc)
                {
                    throw new InvalidDataException($"Invalid CRC. Expected {calcCrc} and got {returnCrc}.");
                }
            }

        }
    }
}
