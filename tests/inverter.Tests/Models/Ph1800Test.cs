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
        public void BatteryPercent_Draining_Load_20_Voltage_24_396_100()
        {
            //Given
            var result = new Ph1800()
            {
                BatteryVoltage = 24.396d,
                BatteryRelayNo = 0,
                LoadPercent = 15,
                BattVoltageGrade = 24
            };


            Assert.AreEqual( (short)100, result.BatteryPercent );

        }

        [TestMethod]
        public void BatteryPercent_Draining_Load_20_Voltage_23_4_75()
        {
            //Given
            var result = new Ph1800()
            {
                BatteryVoltage = 23.4d,
                BatteryRelayNo = 0,
                LoadPercent = 15,
                BattVoltageGrade = 24
            };


            Assert.AreEqual( (short)75, result.BatteryPercent );
        }

        [TestMethod]
        public void BatteryPercent_Draining_Load_20_Voltage_23_898_87()
        {
            //Given
            var result = new Ph1800()
            {
                BatteryVoltage = 23.898d,
                BatteryRelayNo = 0,
                LoadPercent = 15,
                BattVoltageGrade = 24
            };


            Assert.AreEqual( (short)88, result.BatteryPercent );
        }

        [TestMethod]
        public void BatteryPercent_Draining_Load_20_Voltage_21_418_25()
        {
            //Given
            var result = new Ph1800()
            {
                BatteryVoltage = 21.418d,
                BatteryRelayNo = 0,
                LoadPercent = 15,
                BattVoltageGrade = 24
            };


            Assert.AreEqual( (short)25, result.BatteryPercent );
        }

        [TestMethod]
        public void BatteryPercent_Draining_Load_20_Voltage_20_411_0()
        {
            //Given
            var result = new Ph1800()
            {
                BatteryVoltage = 20.411d,
                BatteryRelayNo = 0,
                LoadPercent = 15,
                BattVoltageGrade = 24
            };


            Assert.AreEqual( (short)0, result.BatteryPercent );
        }

        [TestMethod]
        public void BatteryPercent_Draining_Load_50_Voltage_23_298_87()
        {
            //Given
            var result = new Ph1800()
            {
                BatteryVoltage = 23.298d,
                BatteryRelayNo = 0,
                LoadPercent = 45,
                BattVoltageGrade = 24
            };


            Assert.AreEqual( (short)87, result.BatteryPercent );
        }

        [TestMethod]
        public void BatteryPercent_Draining_Load_80_Voltage_22_098_87()
        {
            //Given
            var result = new Ph1800()
            {
                BatteryVoltage = 22.098d,
                BatteryRelayNo = 0,
                LoadPercent = 80,
                BattVoltageGrade = 24
            };


            Assert.AreEqual( (short)87, result.BatteryPercent );
        }


        [TestMethod]
        public void BatteryPercent_Charging_Voltage_27_100()
        {
            //Given
            var result = new Ph1800()
            {
                BatteryVoltage = 27d,
                BatteryRelayNo = 1,
                BattVoltageGrade = 24
            };


            Assert.AreEqual( (short)100, result.BatteryPercent );
        }

        [TestMethod]
        public void BatteryPercent_Charging_Voltage_28_100()
        {
            //Given
            var result = new Ph1800()
            {
                BatteryVoltage = 28d,
                BatteryRelayNo = 1,
                BattVoltageGrade = 24
            };


            Assert.AreEqual( (short)100, result.BatteryPercent );
        }

        [TestMethod]
        public void BatteryPercent_Charging_Voltage_26_004_75()
        {
            //Given
            var result = new Ph1800()
            {
                BatteryVoltage = 26.004d,
                BatteryRelayNo = 1,
                BattVoltageGrade = 24
            };


            Assert.AreEqual( (short)75, result.BatteryPercent );
        }

        [TestMethod]
        public void BatteryPercent_Charging_Voltage_24_25()
        {
            //Given
            var result = new Ph1800()
            {
                BatteryVoltage = 24d,
                BatteryRelayNo = 1,
                BattVoltageGrade = 24
            };


            Assert.AreEqual( (short)25, result.BatteryPercent );
        }

        [TestMethod]
        public void BatteryPercent_Charging_Voltage_23_10()
        {
            //Given
            var result = new Ph1800()
            {
                BatteryVoltage = 23.60d,
                BatteryRelayNo = 1,
                BattVoltageGrade = 24
            };


            Assert.AreEqual( (short)15, result.BatteryPercent );
        }
    }
}
