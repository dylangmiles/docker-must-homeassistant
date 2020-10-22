using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace inverter.Tests
{
    [TestClass]
    public class ModbusToModelMapperTest
    {
        [TestMethod]
        public void Map_OneShort_Success()
        {
            //Given 
            var startAddress = (short)20000;
            var values = new short[] {1};
            var model = new MockModel();

            ModbusToModelMapper.Map(startAddress, values, model);

            Assert.AreEqual(model.Sensor1, (short)1);
            Assert.AreEqual(model.Sensor2, null);

        }

        [TestMethod]
        public void Map_ThreeShorts_Success()
        {
            //Given 
            var startAddress = (short)20000;
            var values = new short[] {1, 2, 3};
            var model = new MockModel();

            ModbusToModelMapper.Map(startAddress, values, model);

            Assert.AreEqual(model.Sensor1, (short)1);
            Assert.AreEqual(model.Sensor2, (short)2);
            Assert.AreEqual(model.Sensor3, (short)3);

        }
    }
}
