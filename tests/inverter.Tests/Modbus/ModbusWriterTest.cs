using inverter.Modbus;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace inverter.Tests.Modbus
{
    [TestClass]
    public class ModbusWriterTest
    {

        //Windows   - Little Endian 0x01 0x00
        //Linux     - Big Endian    0x00 0x01
        //Modbus    - Big Endian    0x00 0x01

        [TestMethod]
        public void Write_OneValue_Success()
        {
            var port = new Mock<ISerialPort>();
            
            byte[] request = null;
            port.Setup(foo => foo.Write(It.IsAny<byte[]>(), It.IsAny<int>(), It.IsAny<int>())).Callback<byte[],int,int>((b,o,c) => request = b);

            byte[] response = null;
            port.Setup(foo => foo.Read(It.IsAny<byte[]>(), It.IsAny<int>(), It.IsAny<int>())).Callback<byte[], int, int>((b,o,c) => {

                using (var stream = new MemoryStream(b))
                using( var writer = new BigEndianBinaryWriter(stream))
                {
                    writer.Write((byte)0x04);   // Device Id
                    writer.Write((byte)0x10);   // Function - 16 - write multiple registers
                    writer.Write((byte)0x4e);   // Address 20109
                    writer.Write((byte)0x8d);   // Address 20109
                    writer.Write((byte)0x00);   // Number of registers written
                    writer.Write((byte)0x01);   // Number of registers written
                    
                    writer.Write((byte)0x86);   //CRC
                    writer.Write((byte)0x9f);   //CRC
                }

                response = b;

            }).Returns(8);


             var writer = new ModbusWriter(port.Object);


            byte deviceId = 4;
            ushort address = 20109;
            ushort[] values = {3};


            writer.write(deviceId, address, values);


            /* Energy use lookup
            "",
            "SBU",
            "SUB",
            "UTI",
            "SOL"
            */
            //Message to set 20109 to 3 ... Set EnergyUse to Utility.
            //04    (4)             device id
            //10    (16)            function id
            //4e8d  (20109)         starting address
            //00    (1)             number of registers to write
            //01    (1)             number of registers to write
            //02    (2)             number of bytes to write
            //0003  (3)             value of address
            //69d8                  crc
            CollectionAssert.AreEqual(new byte[] { 0x04, 0x10, 0x4e, 0x8d, 0x00, 0x01, 0x02, 0x00, 0x03, 0x69, 0xd8 }, request);

            //Response acknowledgement
            //04    (4)             device id
            //10    (16)            function id
            //4e8d  (20109)         the starting address
            //0001  (1)             number of registers written to
            //869f                  crc
            CollectionAssert.AreEqual(new byte[] { 0x04, 0x10, 0x4e, 0x8d, 0x00, 0x01, 0x86, 0x9f }, response);

        }


        [TestMethod]
        [Tests.ExpectedExceptionWithMessage(typeof(InvalidDataException), "Invalid CRC. Expected 34463 and got 34462.")]
        public void Write_Invalid_Crc_InvalidDataExcaption()
        {

            var port = new Mock<ISerialPort>();
            
            byte[] request = null;
            port.Setup(foo => foo.Write(It.IsAny<byte[]>(), It.IsAny<int>(), It.IsAny<int>())).Callback<byte[],int,int>((b,o,c) => request = b);

            byte[] response = null;
            port.Setup(foo => foo.Read(It.IsAny<byte[]>(), It.IsAny<int>(), It.IsAny<int>())).Callback<byte[], int, int>((b,o,c) => {

                using (var stream = new MemoryStream(b))
                using( var writer = new BigEndianBinaryWriter(stream))
                {
                    writer.Write((byte)0x04);   // Device Id
                    writer.Write((byte)0x10);   // Function - 16 - write multiple registers
                    writer.Write((byte)0x4e);   // Address 20109
                    writer.Write((byte)0x8d);   // Address 20109
                    writer.Write((byte)0x00);   // Number of registers written
                    writer.Write((byte)0x01);   // Number of registers written
                    
                    writer.Write((byte)0x86);   //CRC
                    writer.Write((byte)0x9e);   //CRC invalid
                }

                response = b;

            }).Returns(8);


             var writer = new ModbusWriter(port.Object);


            byte deviceId = 4;
            ushort address = 20109;
            ushort[] values = {3};


            writer.write(deviceId, address, values);

        }

        [TestMethod]
        [Tests.ExpectedExceptionWithMessage(typeof(InvalidDataException), "Invalid Sensor Count. Expected 1 bytes and received 2.")]
        public void Write_Invalid_Sensor_Count_InvalidDataExcaption()
        {

            var port = new Mock<ISerialPort>();
            
            byte[] request = null;
            port.Setup(foo => foo.Write(It.IsAny<byte[]>(), It.IsAny<int>(), It.IsAny<int>())).Callback<byte[],int,int>((b,o,c) => request = b);

            byte[] response = null;
            port.Setup(foo => foo.Read(It.IsAny<byte[]>(), It.IsAny<int>(), It.IsAny<int>())).Callback<byte[], int, int>((b,o,c) => {

                using (var stream = new MemoryStream(b))
                using( var writer = new BigEndianBinaryWriter(stream))
                {
                    writer.Write((byte)0x04);   // Device Id
                    writer.Write((byte)0x10);   // Function - 16 - write multiple registers
                    writer.Write((byte)0x4e);   // Address 20109
                    writer.Write((byte)0x8d);   // Address 20109
                    writer.Write((byte)0x00);   // Number of registers written
                    writer.Write((byte)0x02);   // Number of registers written
                    
                    writer.Write((byte)0x86);   //CRC
                    writer.Write((byte)0x9e);   //CRC invalid
                }

                response = b;

            }).Returns(8);


             var writer = new ModbusWriter(port.Object);


            byte deviceId = 4;
            ushort address = 20109;
            ushort[] values = {3};


            writer.write(deviceId, address, values);
        }

        [TestMethod]
        [Tests.ExpectedExceptionWithMessage(typeof(InvalidDataException), "Invalid Address. Expected 20109 bytes and received 20111.")]
        public void Write_Invalid_Return_Address_InvalidDataExcaption()
        {

            var port = new Mock<ISerialPort>();
            
            byte[] request = null;
            port.Setup(foo => foo.Write(It.IsAny<byte[]>(), It.IsAny<int>(), It.IsAny<int>())).Callback<byte[],int,int>((b,o,c) => request = b);

            byte[] response = null;
            port.Setup(foo => foo.Read(It.IsAny<byte[]>(), It.IsAny<int>(), It.IsAny<int>())).Callback<byte[], int, int>((b,o,c) => {

                using (var stream = new MemoryStream(b))
                using( var writer = new BigEndianBinaryWriter(stream))
                {
                    writer.Write((byte)0x04);   // Device Id
                    writer.Write((byte)0x10);   // Function - 16 - write multiple registers
                    writer.Write((byte)0x4e);   // Address 20109
                    writer.Write((byte)0x8f);   // Address 20109
                    writer.Write((byte)0x00);   // Number of registers written
                    writer.Write((byte)0x01);   // Number of registers written
                    
                    writer.Write((byte)0x86);   //CRC
                    writer.Write((byte)0x9e);   //CRC invalid
                }

                response = b;

            }).Returns(8);


             var writer = new ModbusWriter(port.Object);


            byte deviceId = 4;
            ushort address = 20109;
            ushort[] values = {3};


            writer.write(deviceId, address, values);
        }

        [TestMethod]
        [Tests.ExpectedExceptionWithMessage(typeof(InvalidDataException), "Invalid Function Code. Expected 0x10 (16) and got 0x11 (17).")]
        public void Write_Invalid_Function_Code_InvalidDataExcaption()
        {
            var port = new Mock<ISerialPort>();
            
            byte[] request = null;
            port.Setup(foo => foo.Write(It.IsAny<byte[]>(), It.IsAny<int>(), It.IsAny<int>())).Callback<byte[],int,int>((b,o,c) => request = b);

            byte[] response = null;
            port.Setup(foo => foo.Read(It.IsAny<byte[]>(), It.IsAny<int>(), It.IsAny<int>())).Callback<byte[], int, int>((b,o,c) => {

                using (var stream = new MemoryStream(b))
                using( var writer = new BigEndianBinaryWriter(stream))
                {
                    writer.Write((byte)0x04);   // Device Id
                    writer.Write((byte)0x11);   // Function - 16 - write multiple registers
                    writer.Write((byte)0x4e);   // Address 20109
                    writer.Write((byte)0x8d);   // Address 20109
                    writer.Write((byte)0x00);   // Number of registers written
                    writer.Write((byte)0x01);   // Number of registers written
                    
                    writer.Write((byte)0x86);   //CRC
                    writer.Write((byte)0x9e);   //CRC invalid
                }

                response = b;

            }).Returns(8);

            var writer = new ModbusWriter(port.Object);

            byte deviceId = 4;
            ushort address = 20109;
            ushort[] values = {3};

            writer.write(deviceId, address, values);
        }

        [TestMethod]
        [Tests.ExpectedExceptionWithMessage(typeof(InvalidDataException), "Invalid Device Id. Expected 4 and got 3.")]
        public void Write_Invalid_Device_Id_InvalidDataExcaption()
        {
            var port = new Mock<ISerialPort>();
            
            byte[] request = null;
            port.Setup(foo => foo.Write(It.IsAny<byte[]>(), It.IsAny<int>(), It.IsAny<int>())).Callback<byte[],int,int>((b,o,c) => request = b);

            byte[] response = null;
            port.Setup(foo => foo.Read(It.IsAny<byte[]>(), It.IsAny<int>(), It.IsAny<int>())).Callback<byte[], int, int>((b,o,c) => {

                using (var stream = new MemoryStream(b))
                using( var writer = new BigEndianBinaryWriter(stream))
                {
                    writer.Write((byte)0x03);   // Device Id
                    writer.Write((byte)0x10);   // Function - 16 - write multiple registers
                    writer.Write((byte)0x4e);   // Address 20109
                    writer.Write((byte)0x8d);   // Address 20109
                    writer.Write((byte)0x00);   // Number of registers written
                    writer.Write((byte)0x01);   // Number of registers written
                    
                    writer.Write((byte)0x86);   //CRC
                    writer.Write((byte)0x9e);   //CRC invalid
                }

                response = b;

            }).Returns(8);

            var writer = new ModbusWriter(port.Object);

            byte deviceId = 4;
            ushort address = 20109;
            ushort[] values = {3};

            writer.write(deviceId, address, values);
        }

        [TestMethod]
        [Tests.ExpectedExceptionWithMessage(typeof(InvalidDataException), "Invalid length of data read. Expected 8 bytes and got 5 bytes.")]
        public void Write_Invalid_Data_Length_InvalidDataException()
        {
            var port = new Mock<ISerialPort>();
            
            byte[] request = null;
            port.Setup(foo => foo.Write(It.IsAny<byte[]>(), It.IsAny<int>(), It.IsAny<int>())).Callback<byte[],int,int>((b,o,c) => request = b);

            byte[] response = null;
            port.Setup(foo => foo.Read(It.IsAny<byte[]>(), It.IsAny<int>(), It.IsAny<int>())).Callback<byte[], int, int>((b,o,c) => {

                using (var stream = new MemoryStream(b))
                using( var writer = new BigEndianBinaryWriter(stream))
                {
                    writer.Write((byte)0x04);   // Device Id
                    writer.Write((byte)0x10);   // Function - 16 - write multiple registers
                    writer.Write((byte)0x4e);   // Address 20109
                    writer.Write((byte)0x8d);   // Address 20109
                    writer.Write((byte)0x00);   // Number of registers written
                    writer.Write((byte)0x01);   // Number of registers written
                    
                    writer.Write((byte)0x86);   //CRC
                    writer.Write((byte)0x9e);   //CRC invalid
                }

                response = b;

            }).Returns(5);

            var writer = new ModbusWriter(port.Object);

            byte deviceId = 4;
            ushort address = 20109;
            ushort[] values = {3};

            writer.write(deviceId, address, values);
        }
    }
}
