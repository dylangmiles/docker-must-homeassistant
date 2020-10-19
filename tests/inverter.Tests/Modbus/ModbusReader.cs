using System;
using System.Collections.Generic;
using System.IO;

namespace inverter.Tests.Modbus
{
    public class ModbusReader
    {
        private ISerialPort _serialPort;

        public ModbusReader(ISerialPort serialPort)
        {
            _serialPort = serialPort;
        }

        internal ushort[] Read(byte deviceId, ushort address, ushort count)
        {
            //Make the request
            var request = new byte[8];
            using (var stream = new MemoryStream(request))
            using (var writer = new BigEndianBinaryWriter(stream))
            {
                writer.Write(deviceId);
                writer.Write(0x03);
                writer.Write(address);
                writer.Write(count);
                writer.Write(0xCC);
                writer.Write(0xDD);
            }

            _serialPort.Write(request, 0, request.Length);


            var response = new byte[3 + 2 + 2 * count];
            var read = _serialPort.Read(response, 0, response.Length); //TODO: Handle timeouts here and failed CRCs


            var values = new List<ushort>();
            using (var stream = new MemoryStream(response))
            using (var reader = new BigEndianBinaryReader(stream))
            {
                //response[0] == deviceId
                //response[1] == (byte)0x3
                //response[2] == count

                var returnDeviceId = reader.ReadByte();
                var returnFunctionCode = reader.ReadByte();
                var returnByteCount = reader.ReadByte() / 2;

                for (var i = 0; i < returnByteCount; i++)
                {
                    var value = reader.ReadUInt6();
                    values.Add(value);
                }
            }


            return values.ToArray();

        }
    }
}