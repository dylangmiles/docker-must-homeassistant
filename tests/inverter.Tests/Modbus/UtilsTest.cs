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
                0x02,            // Count of values requested
                0x00,
                0x00
            };

            //When
            ushort crc = Utils.CalculateCrc(data);

            Assert.AreEqual((ushort)17524, crc);
            
        }
    }
}
