using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
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

            var result = SensorDefinitionQuery.Get<MockModel>().ToList();

            Assert.AreEqual((short)20000, result[0].Address);
            Assert.AreEqual("X", result[0].Uom);
            Assert.AreEqual(1.0, result[0].Coefficient);
            Assert.AreEqual("Sensor1", result[0].Name);
            Assert.AreEqual("System.Int16", result[0].DataType);
            Assert.AreEqual(true, result[0].IsSigned);
            
            Assert.AreEqual("", result[0].Lookup[0]);
            Assert.AreEqual("First", result[0].Lookup[1]);
            Assert.AreEqual("Second", result[0].Lookup[2]);

            Assert.AreEqual("Some notes and remarks", result[0].Remarks);
        }


    }
}
