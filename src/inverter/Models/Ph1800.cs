using System;
using System.Collections.Generic;
using System.Text;

namespace inverter.Models
{
    public partial class  Ph1800
    {

        [SensorInterpretation("battery","%")]
        public short? BatteryPercent
        {
            get
            {
                if (this.BatteryVoltage.HasValue == false || this.WorkStateNo.HasValue == false || this.ChrWorkstateNo.HasValue == false || this.BattVoltageGrade.HasValue == false)
                {
                    return null;
                }

                var batteryVoltage = this.BatteryVoltage.Value;
                var batteryVoltageGrade = this.BattVoltageGrade.Value;
                var batteryCellCount = batteryVoltageGrade / 2; // Assume 2 volt cells. So a 12 volt battery will have 6 cells.
                var cellVoltage = batteryVoltage / batteryCellCount;
                var batteryMode = this.WorkStateNo == 2; // In battery mode. Battery is being used
                var charging = this.ChrWorkstateNo == 2; // Battery is being charged
                var batteryLoaded = batteryMode == true && charging == false; // Load is supported by battery with no charging


                
                // if in line mode or battery is charing then don't use load
                // if battery is not charging and in battery mode then use load



                // Battery is not charging
                if (batteryLoaded == true)
                {
                    if (this.LoadPercent.HasValue == false)
                    {
                        return null;
                    }

                    var loadPercentage = this.LoadPercent.Value;

                    if (loadPercentage < 20)
                    {
                        return CalculateBatteryPercent(1.701d, 2.033d, 0.083, 4, cellVoltage);
                    }

                    if (loadPercentage < 50)
                    {
                        return CalculateBatteryPercent(1.651d, 1.983d, 0.083, 4, cellVoltage);
                    }

                    return CalculateBatteryPercent(1.551d, 1.883d, 0.083, 4, cellVoltage);
                }

                // We are charging
                if (batteryLoaded == false)
                {
                    return CalculateBatteryPercent(1.917d, 2.25d, 0.083, 4, cellVoltage);
                }

                return null;
              
            }
        }

        private short CalculateBatteryPercent(double lower, double upper, double interval, int intervals, double cellVoltage)
        {
            
            if (cellVoltage >= upper) return 100;

            var threshold = upper;
            var percentageBase = 100d;
            var percentageInterval = 100d / (double)intervals;
            for (var level = 0; level < intervals; level++)
            {
                threshold = threshold - (level * interval);
                percentageBase = percentageBase - (level * percentageInterval);

                if (cellVoltage >= threshold)
                {
                    return (short) (percentageBase + Math.Round(percentageInterval * (cellVoltage - threshold) / interval, 0,
                        MidpointRounding.AwayFromZero));
                }
            }

            return 0;
        }

        [SensorInterpretation("chart-bell-curve-cumulative","KWH")]
        public double? AccumulatedChargerPower
        {   get
            {
                return  (this.AccumulatedChargerPowerH ?? 0d) * 1000d + (this.AccumulatedChargerPowerL ?? 0d) * 0.1d;
            }
        }

        [SensorInterpretation("chart-bell-curve-cumulative","KWH")]
        public double? AccumulatedDischargerPower
        {   get
            {
                return (this.AccumulatedDischargerPowerH ?? 0d) * 1000d + (this.AccumulatedDischargerPowerL ?? 0d) * 0.1d;
            }
        }

        [SensorInterpretation("chart-bell-curve-cumulative","KWH")]
        public double? AccumulatedBuyPower
        {   get
            {
                   return (this.AccumulatedBuyPowerH ?? 0d) * 1000d + (this.AccumulatedBuyPowerL ?? 0d) * 0.1d;
            }
        }

        [SensorInterpretation("chart-bell-curve-cumulative","KWH")]
        public double? AccumulatedSellPower
        {   get
            {
                return (this.AccumulatedSellPowerH ?? 0d) * 1000d + (this.AccumulatedSellPowerL ?? 0d) * 0.1d;
            }
        }

        [SensorInterpretation("chart-bell-curve-cumulative","KWH")]
        public double? AccumulatedLoadPower
        {   get
            {
                return (this.AccumulatedLoadPowerH ?? 0d) * 1000d + (this.AccumulatedLoadPowerL ?? 0d) * 0.1d;
            }
        }

        [SensorInterpretation("chart-bell-curve-cumulative","KWH")]
        public double? AccumulatedSelfusePower
        {   get
            {
                return (this.AccumulatedSelfusePowerH ?? 0d) * 1000d + (this.AccumulatedSelfusePowerL ?? 0d) * 0.1d;
            }
        }

        [SensorInterpretation("chart-bell-curve-cumulative","KWH")]
        public double? AccumulatedPvsellPower
        {   get
            {
                return (this.AccumulatedPvsellPowerH ?? 0d) * 1000d + (this.AccumulatedPvsellPowerL ?? 0d) * 0.1d;
            }
        }

        [SensorInterpretation("chart-bell-curve-cumulative","KWH")]
        public double? AccumulatedGridChargerPower
        {   get
            {
                return (this.AccumulatedGridChargerPowerH ?? 0d) * 1000d + (this.AccumulatedGridChargerPowerL ?? 0d) * 0.1d;
            }
        }

        [SensorInterpretation("chart-bell-curve-cumulative","KWH")]
        public double? AccumulatedPvPower
        {   get
            {
                return (this.AccumulatedPvPowerH ?? 0d) * 1000d + (this.AccumulatedPvPowerL ?? 0d) * 0.1d;
            }
        }

    }
}
