using System;
using System.Collections.Generic;
using System.IO;

namespace inverter.Tests.Modbus
{
    /// <summary>
    /// Read from a serial port using the Modbus protocol.
    /// </summary>
    public class ModbusReader
    {
        private ISerialPort _serialPort;

        public ModbusReader(ISerialPort serialPort)
        {
            _serialPort = serialPort;
        }

        internal ushort[] Read(byte deviceId, ushort address, ushort count)
        {
            //Construct the request
            var request = new byte[8];
            using (var stream = new MemoryStream(request))
            using (var writer = new BigEndianBinaryWriter(stream))
            {
                writer.Write(deviceId);     // DeviceId
                writer.Write(0x03);         // Query
                writer.Write(address);      // Start address
                writer.Write(count);        // Number of values requested
                writer.Write(0x00);         // CRC
                writer.Write(0x00);         // CRC
            }

            //Calculate and write the CRC
            var crc = Utils.CalculateCrc(request, 0, 6);

            using (var stream = new MemoryStream(request, 6, 2))
            using (var writer = new BigEndianBinaryWriter(stream))
            {
                writer.Write(crc);
            }
            
            //Send the message over the wire
            _serialPort.Write(request, 0, request.Length);


            //Read the response
            var response = new byte[3 + 2 + 2 * count];
            var read = _serialPort.Read(response, 0, response.Length);

            //TODO: Check read length
            if (read != response.Length)
            {
                throw new InvalidDataException("Invalid length of data read.");
            }


            var values = new List<ushort>();
            using (var stream = new MemoryStream(response))
            using (var reader = new BigEndianBinaryReader(stream))
            {
                var returnDeviceId = reader.ReadByte();
                if (returnDeviceId != deviceId) throw new InvalidDataException("Invalid Device Id.");

                var returnFunctionCode = reader.ReadByte();
                if (returnFunctionCode != 0x03) throw new InvalidDataException("Invalid Function Code.");

                var returnByteCount = reader.ReadByte();
                if (returnByteCount != 2 * count) throw new InvalidDataException("Invalid Byte Count.");

                var returnSensorCount = returnByteCount / 2;

                for (var i = 0; i < returnSensorCount; i++)
                {
                    var value = reader.ReadUInt6();
                    values.Add(value);
                }

                var returnCrc = reader.ReadUInt6();
                var calcCrc = Utils.CalculateCrc(response, 0, response.Length - 2);

                if (returnCrc != calcCrc)
                {
                    throw new InvalidDataException("Invalid CRC.");
                }
            }


            return values.ToArray();

        }
    }
}