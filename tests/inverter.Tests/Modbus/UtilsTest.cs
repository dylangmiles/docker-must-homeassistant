using inverter.Modbus;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.IO;


namespace inverter.Tests.Modbus
{
    [TestClass]
    public class UtilsTest
    {
        [TestMethod]
        public void CalculateCrc_Success()
        {
            //Given a modbus query with asking for two values starting at 2000 
            var data = new byte[] {
                0x01,           // Device Id
                0x03,           // Query
                0x07,           // Most significant byte of 2000
                0xD0,           // Least signification byte of 2000
                0x00,           // Most significant byte of values requested
                0x02,           // Least significant byte of values requested.
                0x00,
                0x00
            };

            //When
            ushort crc = Utils.CalculateCrc(data, 0, 6);

            Assert.AreEqual((ushort)50310, crc);
            
        }

         [TestMethod]
        public void CalculateCrc_Reference_Success()
        {
            //Given a modbus query with asking for two values starting at 2000 
            var data = new byte[] {
                0x04,           // Device Id
                0x03,           // Query
                0x4e,           // Most significant byte of 2000
                0x20,           // Least signification byte of 2000
                0x00,           // Most significant byte of values requested
                0x07,           // Least significant byte of values requested.
                0x00,
                0x00
            };

            //When
            ushort crc = Utils.CalculateCrc(data, 0, 6);

            Assert.AreEqual((ushort)4799, crc);
            
        }
    }
}
