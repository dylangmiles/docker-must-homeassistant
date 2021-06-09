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
                if (this.BatteryVoltage.HasValue == false || this.LoadPercent.HasValue == false || this.BatteryRelayNo.HasValue == false)
                {
                    return null;
                }

                var batteryPercent = 0;

                var batteryVoltage = this.BatteryVoltage;
                var batteryVoltagePerCell = batteryVoltage / 12; // Assume 24 volt battery for now. So then we have 12 cells or 6 cells per 12 volt battery.
                var batteryRelayNo = this.BatteryRelayNo;

                var loadPercentage = this.LoadPercent;

                // Battery is not charging
                if (batteryRelayNo == 0)
                {
                    if (loadPercentage < 20)
                    {
                        var l4t = 2.033d; // This is a guess based on next two intervals
                        if (batteryVoltagePerCell >= l4t)
                        {
                            return 100;
                        }
                    }

                    return 0;
                }

                return null;

                //var batteryPercent = 0;

                //var batteryVoltage = this.BatteryVoltage;
                //var batteryVoltagePerCell = batteryVoltage / 12; // Assume 24 volt battery for now. So then we have 12 cells or 6 cells per 12 volt battery.
                //var batteryRelayNo = this.BatteryRelayNo;

                //var loadPercentage = this.LoadPercent;

                //// Battery is not charging
                //if (batteryRelayNo == 0)
                //{
                //    if (loadPercentage < 20)
                //    {
                //        var l4t = 2.033d; // This is a guess based on next two intervals
                //        if (batteryVoltagePerCell >= l4t)
                //        {
                //            return 100;
                //        }

                //        var l4b = 1.95d;
                //        if (batteryVoltagePerCell >= l4b)
                //        {
                //            return (short)(75 + Math.Round(25d * (batteryVoltagePerCell.Value - l4b) / (l4t - l4b), 0, MidpointRounding.AwayFromZero));
                //        }

                //        var l3b = 1.867d;
                //        if (batteryVoltagePerCell >= l3b)
                //        {
                //            return (short)(50 + Math.Round(25d * (batteryVoltagePerCell.Value - l3b) / (l4b - l3b), 0, MidpointRounding.AwayFromZero));
                //        }

                //        var l2b = 1.784d;
                //        if (batteryVoltagePerCell >= l2b)
                //        {
                //            return (short)(25 + Math.Round(25d * (batteryVoltagePerCell.Value - l2b) / (l3b - l2b), 0, MidpointRounding.AwayFromZero));
                //        }

                //        var l1b = 1.701d;
                //        if (batteryVoltagePerCell >= l1b)
                //        {
                //            return (short)(0 + Math.Round(25d * (batteryVoltagePerCell.Value - l1b) / (l2b - l1b), 0, MidpointRounding.AwayFromZero));
                //        }

                //        // Flat battery
                //        return 0;
                //    }

                //    if (loadPercentage < 50)
                //    {
                //        var l4t = 1.983d; // This is a guess based on next two intervals
                //        if (batteryVoltagePerCell >= l4t)
                //        {
                //            return 100;
                //        }

                //        var l4b = 1.9d;
                //        if (batteryVoltagePerCell >= l4b)
                //        {
                //            return (short)(75 + Math.Round(25d * (batteryVoltagePerCell.Value - l4b) / (l4t - l4b), 0, MidpointRounding.AwayFromZero));
                //        }

                //        var l3b = 1.817d;
                //        if (batteryVoltagePerCell >= l3b)
                //        {
                //            return (short)(50 + Math.Round(25d * (batteryVoltagePerCell.Value - l3b) / (l4b - l3b), 0, MidpointRounding.AwayFromZero));
                //        }

                //        var l2b = 1.734;
                //        if (batteryVoltagePerCell >= l2b)
                //        {
                //            return (short)(25 + Math.Round(25d * (batteryVoltagePerCell.Value - l2b) / (l3b - l2b), 0, MidpointRounding.AwayFromZero));
                //        }

                //        var l1b = 1.651d;
                //        if (batteryVoltagePerCell >= l1b)
                //        {
                //            return (short)(0 + Math.Round(25d * (batteryVoltagePerCell.Value - l1b) / (l2b - l1b), 0, MidpointRounding.AwayFromZero));
                //        }

                //        // Flat battery
                //        return 0;
                //    }

                //    // Greater than 50%
                //    var l4t = 1.883d; // This is a guess based on next two intervals
                //    if (batteryVoltagePerCell >= l4t)
                //    {
                //        return 100;
                //    }

                //    var l4b = 1.8d;
                //    if (batteryVoltagePerCell >= l4b)
                //    {
                //        return (short)(75 + Math.Round(25d * (batteryVoltagePerCell.Value - l4b) / (l4t - l4b), 0, MidpointRounding.AwayFromZero));
                //    }

                //    var l3b = 1.717d;
                //    if (batteryVoltagePerCell >= l3b)
                //    {
                //        return (short)(50 + Math.Round(25d * (batteryVoltagePerCell.Value - l3b) / (l4b - l3b), 0, MidpointRounding.AwayFromZero));
                //    }

                //    var l2b = 1.634;
                //    if (batteryVoltagePerCell >= l2b)
                //    {
                //        return (short)(25 + Math.Round(25d * (batteryVoltagePerCell.Value - l2b) / (l3b - l2b), 0, MidpointRounding.AwayFromZero));
                //    }

                //    var l1b = 1.551d;
                //    if (batteryVoltagePerCell >= l1b)
                //    {
                //        return (short)(0 + Math.Round(25d * (batteryVoltagePerCell.Value - l1b) / (l2b - l1b), 0, MidpointRounding.AwayFromZero));
                //    }

                //    // Flat battery
                //    return 0;
                //}

                //// Battery is charging
                //if (batteryRelayNo == 1)
                //{
                //    var l4t = 2.2833d;
                //    if (batteryVoltagePerCell >= l4t)
                //    {
                //        return 100;
                //    }

                //    var l4b = 2.167d;
                //    if (batteryVoltagePerCell >= l4b)
                //    {
                //        return (short)(75 + Math.Round(25d * (batteryVoltagePerCell.Value - l4b) / (l4t - l4b), 0, MidpointRounding.AwayFromZero));
                //    }

                //    var l3b = 2.083d;
                //    if (batteryVoltagePerCell >= l3b)
                //    {
                //        return (short)(50 + Math.Round(25d * (batteryVoltagePerCell.Value - l3b) / (l4b - l3b), 0, MidpointRounding.AwayFromZero));
                //    }

                //    var l2b = 2.000d;
                //    if (batteryVoltagePerCell >= l2b)
                //    {
                //        return (short)(25 + Math.Round(25d * (batteryVoltagePerCell.Value - l2b) / (l3b - l2b), 0, MidpointRounding.AwayFromZero));
                //    }

                //    var l1b = 1.966d; //TODO: Need to confirm this
                //    if (batteryVoltagePerCell >= l1b)
                //    {
                //        return (short)(0 + Math.Round(25d * (batteryVoltagePerCell.Value - l1b) / (l2b - l1b), 0, MidpointRounding.AwayFromZero));
                //    }

                //    // Flat battery
                //    return 0;

                //}

                //return null;

            }
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
