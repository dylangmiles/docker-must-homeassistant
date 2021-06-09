using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using inverter.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace inverter.Tests.Models
{

    [TestClass]
    public class Ph1800Test
    {
        [TestMethod]
        public void BatteryPercent_NullBatteryVoltage_Null()
        {
            //Given
            var result = new Ph1800();

            Assert.AreEqual( null, result.BatteryPercent );

        }

        [TestMethod]
        public void BatteryPercent_DrainingVoltage_24_396_100()
        {
            //Given
            var result = new Ph1800()
            {
                BatteryVoltage = 24.396d,
                BatteryRelayNo = 0,
                LoadPercent = 15
            };


            Assert.AreEqual( (short)100, result.BatteryPercent );

        }
    }
}
