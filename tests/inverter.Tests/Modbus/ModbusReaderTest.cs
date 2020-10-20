using inverter.Modbus;
using inverter.Tests.Modbus;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.IO;

namespace inverter.Tests.Modbus
{
    [TestClass]
    public class ModbusReaderTest
    {
        //TODO: Timeouts
        //TODO: Port closed?

        //Windows   - Little Endian 0x01 0x00
        //Linux     - Big Endian    0x00 0x01
        //Modbus    - Big Endian    0x00 0x01

        [TestMethod]
        public void Read_FiveValues_Success()
        {

            var port = new Mock<ISerialPort>();
            byte[] request = null;
            port.Setup(foo => foo.Write(It.IsAny<byte[]>(), It.IsAny<int>(), It.IsAny<int>())).Callback<byte[],int,int>((b,o,c) => request = b);

            byte[] response = null;
            port.Setup(foo => foo.Read(It.IsAny<byte[]>(), It.IsAny<int>(), It.IsAny<int>())).Callback<byte[], int, int>((b,o,c) => {

                using (var stream = new MemoryStream(b))
                using( var writer = new BigEndianBinaryWriter(stream))
                {
                    writer.Write((byte)0x01);   // Device Id
                    writer.Write((byte)0x03);   // Operation - 3 Response
                    writer.Write((byte)0x0A);   // Byte count of values

                    writer.Write((ushort)10);   // Value 0
                    writer.Write((ushort)11);   // Value 1
                    writer.Write((ushort)12);
                    writer.Write((ushort)13);
                    writer.Write((ushort)14);   // Value 5

                    writer.Write((byte)0xE0);   //Check sum
                    writer.Write((byte)0xD0);   //Check sum
                }

                response = b;

            }).Returns(15);
            
            var reader = new ModbusReader(port.Object);

            byte deviceId = 1;
            ushort address = 2000;
            ushort count = 5;

            ushort[] data = reader.Read( deviceId, address, count );

            Assert.AreEqual(5, data.Length);
            CollectionAssert.AreEqual(new byte[] { 0x01, 0x03, 0x07, 0xD0, 0x00, 0x05, 0x85, 0x44 }, request);
            CollectionAssert.AreEqual(new byte[] { 0x01, 0x03, 0x0A, 0x00, 0xA, 0x00, 0x0B, 0x00, 0x0C, 0x00,0x0D,0x00,0x0E,0xE0,0xD0 }, response);

            Assert.AreEqual(11, data[1]);
        }

                    
        [TestMethod]
        [Tests.ExpectedExceptionWithMessage(typeof(InvalidDataException), "Invalid CRC. Expected 57552 and got 57808.")]
        public void Read_Invalid_Crc_InvalidDataExcaption()
        {


            var port = new Mock<ISerialPort>();
            byte[] request = null;
            port.Setup(foo => foo.Write(It.IsAny<byte[]>(), It.IsAny<int>(), It.IsAny<int>())).Callback<byte[],int,int>((b,o,c) => request = b);

            byte[] response = null;
            port.Setup(foo => foo.Read(It.IsAny<byte[]>(), It.IsAny<int>(), It.IsAny<int>())).Callback<byte[], int, int>((b,o,c) => {

                using (var stream = new MemoryStream(b))
                using( var writer = new BigEndianBinaryWriter(stream))
                {
                    writer.Write((byte)0x01);   // Device Id
                    writer.Write((byte)0x03);   // Operation - 3 Response
                    writer.Write((byte)0x0A);   // Byte count of values

                    writer.Write((ushort)10);   // Value 0
                    writer.Write((ushort)11);   // Value 1
                    writer.Write((ushort)12);
                    writer.Write((ushort)13);
                    writer.Write((ushort)14);   // Value 5

                    writer.Write((byte)0xE1);   //Check sum
                    writer.Write((byte)0xD0);   //Check sum fails
                }

                response = b;

            }).Returns(15);
            
            var reader = new ModbusReader(port.Object);

            byte deviceId = 1;
            ushort address = 2000;
            ushort count = 5;

            ushort[] data = reader.Read( deviceId, address, count );

            //Assert InvalidDataException is thrown
            
        }

        [TestMethod]
        [Tests.ExpectedExceptionWithMessage(typeof(InvalidDataException), "Invalid Device Id. Expected 1 and got 2")]
        public void Read_Invalid_DeviceId_InvalidDataException()
        {

     
            var port = new Mock<ISerialPort>();
            byte[] request = null;
            port.Setup(foo => foo.Write(It.IsAny<byte[]>(), It.IsAny<int>(), It.IsAny<int>())).Callback<byte[],int,int>((b,o,c) => request = b);

            byte[] response = null;
            port.Setup(foo => foo.Read(It.IsAny<byte[]>(), It.IsAny<int>(), It.IsAny<int>())).Callback<byte[], int, int>((b,o,c) => {

                

                using (var stream = new MemoryStream(b))
                using( var writer = new BigEndianBinaryWriter(stream))
                {
                    writer.Write((byte)0x02);   // Device Id is invalid
                    writer.Write((byte)0x03);   // Operation - 3 Response
                    writer.Write((byte)0x0A);   // Byte count of values

                    writer.Write((ushort)10);   // Value 0
                    writer.Write((ushort)11);   // Value 1
                    writer.Write((ushort)12);
                    writer.Write((ushort)13);
                    writer.Write((ushort)14);   // Value 5

                    writer.Write((byte)0x13);   //Check sum
                    writer.Write((byte)0xE5);   //Check sum
                }

                response = b;

            }).Returns(15);
            
            var reader = new ModbusReader(port.Object);

            byte deviceId = 1;
            ushort address = 2000;
            ushort count = 5;

            ushort[] data = reader.Read( deviceId, address, count );

            //Assert invalid data exception
        }

        [TestMethod]
        [Tests.ExpectedExceptionWithMessage(typeof(InvalidDataException), "Invalid Function Code. Expected 03 and got 4.")]
        public void Read_Invalid_Function_Code_InvalidDataException()
        {

            //Windows   - Little Endian 0x01 0x00
            //Linux     - Big Endian    0x00 0x01
            //Modbus    - Big Endian    0x00 0x01

            var port = new Mock<ISerialPort>();
            byte[] request = null;
            port.Setup(foo => foo.Write(It.IsAny<byte[]>(), It.IsAny<int>(), It.IsAny<int>())).Callback<byte[],int,int>((b,o,c) => request = b);

            byte[] response = null;
            port.Setup(foo => foo.Read(It.IsAny<byte[]>(), It.IsAny<int>(), It.IsAny<int>())).Callback<byte[], int, int>((b,o,c) => {

                

                using (var stream = new MemoryStream(b))
                using( var writer = new BigEndianBinaryWriter(stream))
                {
                    writer.Write((byte)0x01);   // Device Id is invalid
                    writer.Write((byte)0x04);   // Operation - 3 Response
                    writer.Write((byte)0x0A);   // Byte count of values

                    writer.Write((ushort)10);   // Value 0
                    writer.Write((ushort)11);   // Value 1
                    writer.Write((ushort)12);
                    writer.Write((ushort)13);
                    writer.Write((ushort)14);   // Value 5

                    writer.Write((byte)0x1b);   //Check sum
                    writer.Write((byte)0x15);   //Check sum
                }

                response = b;

            }).Returns(15);
            
            var reader = new ModbusReader(port.Object);

            byte deviceId = 1;
            ushort address = 2000;
            ushort count = 5;

            ushort[] data = reader.Read( deviceId, address, count );

            //Assert invalid data exception
        }

        [TestMethod]
        [Tests.ExpectedExceptionWithMessage(typeof(InvalidDataException), "Invalid length of data read. Expected 15 bytes and got 13 bytes.")]
        public void Read_Invalid_Length_of_Data_InvalidDataException()
        {

            //Windows   - Little Endian 0x01 0x00
            //Linux     - Big Endian    0x00 0x01
            //Modbus    - Big Endian    0x00 0x01

            var port = new Mock<ISerialPort>();
            byte[] request = null;
            port.Setup(foo => foo.Write(It.IsAny<byte[]>(), It.IsAny<int>(), It.IsAny<int>())).Callback<byte[],int,int>((b,o,c) => request = b);

            byte[] response = null;
            port.Setup(foo => foo.Read(It.IsAny<byte[]>(), It.IsAny<int>(), It.IsAny<int>())).Callback<byte[], int, int>((b,o,c) => {

                

                using (var stream = new MemoryStream(b))
                using( var writer = new BigEndianBinaryWriter(stream))
                {
                    writer.Write((byte)0x01);   // Device Id is invalid
                    writer.Write((byte)0x03);   // Operation - 3 Response
                    writer.Write((byte)0x0A);   // Byte count of values

                    writer.Write((ushort)10);   // Value 0
                    writer.Write((ushort)11);   // Value 1
                    writer.Write((ushort)12);
                    writer.Write((ushort)13);
                    writer.Write((ushort)14);   // Value 5

                    //writer.Write((byte)0x1b);   //Check sum
                    //writer.Write((byte)0x15);   //Check sum
                }

                response = b;

            }).Returns(13); //Two bytes short
            
            var reader = new ModbusReader(port.Object);

            byte deviceId = 1;
            ushort address = 2000;
            ushort count = 5;

            ushort[] data = reader.Read( deviceId, address, count );

            //Assert invalid data exception
        }
    }
}
