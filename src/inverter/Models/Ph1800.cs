using System;
using System.Collections.Generic;
using System.Text;

namespace inverter.Models
{
    public partial class  Ph1800
    {
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
