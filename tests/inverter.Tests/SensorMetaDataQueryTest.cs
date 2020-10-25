using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace inverter.Tests
{
    [TestClass]
    public class SensorMetaDataQueryTest
    {

        [TestMethod]
        public void Query_Success()
        {
            //Given
            var modelType = typeof(MockModel);

            var result = SensorMetaDataQuery.Get(modelType);

            Assert.AreEqual((short)2000, result.Address);
            Assert.AreEqual("X", result.Uom);
            Assert.AreEqual(0.1, result.Coefficient);
            Assert.AreEqual(typeof(double), result.DataType);
            
            Assert.AreEqual("", result.Lookup[0]);
            Assert.AreEqual("First", result.Lookup[1]);
            Assert.AreEqual("Second", result.Lookup[1]);


        }


    }

    public class SensorMetaDataQuery
    {
        public static SensorMetaData Get(Type modelType)
        {
            throw new NotImplementedException();
        }
    }

    public class SensorMetaData
    {
        public short Address { get; internal set; }
        public string Uom { get; internal set; }
        public double Coefficient { get; internal set; }
        public Type DataType { get; internal set; }
        public string[] Lookup { get; internal set; }
    }
}
