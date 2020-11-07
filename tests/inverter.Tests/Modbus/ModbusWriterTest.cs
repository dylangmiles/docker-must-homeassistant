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

            }).Returns(7);


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
    }
}
