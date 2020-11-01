using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace inverter.Tests
{
    [TestClass]
    public class SensortToModelMapperTest
    {
        [TestMethod]
        public void Map_OneShort_Success()
        {
            //Given 
            var startAddress = (short)20000;
            var values = new ushort[] {1};
            var model = new MockModel();

            SensorToModelMapper.Map(startAddress, values, model);

            Assert.AreEqual(model.Sensor1, (short)1);
            Assert.AreEqual(model.Sensor2, null);

        }

        [TestMethod]
        public void Map_ThreeShorts_Success()
        {
            //Given 
            var startAddress = (short)20000;
            var values = new ushort[] {1, 2, 3};
            var model = new MockModel();

            SensorToModelMapper.Map(startAddress, values, model);

            Assert.AreEqual((short)1, model.Sensor1);
            Assert.AreEqual((short)2, model.Sensor2);
            Assert.AreEqual((short)3, model.Sensor3);

        }

        [TestMethod]
        public void Map_Double_Success()
        {
            //Given 
            var startAddress = (short)15001;
            var values = new ushort[] {14};
            var model = new MockModel();

            SensorToModelMapper.Map(startAddress, values, model);

            Assert.AreEqual((double)1.4, model.Sensor15001.Value, 0.01d);
            Assert.AreEqual(null, model.Sensor15002);
        }

        [TestMethod]
        public void Map_SensorNotInModel()
        {
            //Given 
            var startAddress = (short)10106;
            var values = new ushort[] {1};
            var model = new MockModel();

            SensorToModelMapper.Map(startAddress, values, model);


            //Noting should happen. No exception and no value set.
            
        }
    }
}
