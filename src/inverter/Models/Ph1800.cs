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
                return  (double?)this.AccumulatedChargerPowerH ?? 0d * 1000d + (double?)this.AccumulatedChargerPowerL ?? 0d * 0.1d;
            }
        }

        [SensorInterpretation("chart-bell-curve-cumulative","KWH")]
        public double? AccumulatedDischargerPower
        {   get
            {
                return (double?)this.AccumulatedDischargerPowerH ?? 0d * 1000d + (double?)this.AccumulatedDischargerPowerL ?? 0d * 0.1d;
            }
        }

        [SensorInterpretation("chart-bell-curve-cumulative","KWH")]
        public double? AccumulatedBuyPower
        {   get
            {
                   return (double?)this.AccumulatedBuyPowerH ?? 0d * 1000d + (double?)this.AccumulatedBuyPowerL ?? 0d * 0.1d;
            }
        }

        [SensorInterpretation("chart-bell-curve-cumulative","KWH")]
        public double? AccumulatedSellPower
        {   get
            {
                return (double?)this.AccumulatedSellPowerH ?? 0d * 1000d + (double?)this.AccumulatedSellPowerL ?? 0d * 0.1d;
            }
        }

        [SensorInterpretation("chart-bell-curve-cumulative","KWH")]
        public double? AccumulatedLoadPower
        {   get
            {
                return (double?)this.AccumulatedLoadPowerH ?? 0d * 1000d + (double?)this.AccumulatedLoadPowerL ?? 0d * 0.1d;
            }
        }

        [SensorInterpretation("chart-bell-curve-cumulative","KWH")]
        public double? AccumulatedSelfusePower
        {   get
            {
                return (double?)this.AccumulatedSelfusePowerH ?? 0d * 1000d + (double?)this.AccumulatedSelfusePowerL ?? 0d * 0.1d;
            }
        }

        [SensorInterpretation("chart-bell-curve-cumulative","KWH")]
        public double? AccumulatedPvsellPower
        {   get
            {
                return (double?)this.AccumulatedPvsellPowerH ?? 0d * 1000d + (double?)this.AccumulatedPvsellPowerL ?? 0d * 0.1d;
            }
        }

        [SensorInterpretation("chart-bell-curve-cumulative","KWH")]
        public double? AccumulatedGridChargerPower
        {   get
            {
                return (double?)this.AccumulatedGridChargerPowerH ?? 0d * 1000d + (double?)this.AccumulatedGridChargerPowerL ?? 0d * 0.1d;
            }
        }

        [SensorInterpretation("chart-bell-curve-cumulative","KWH")]
        public double? AccumulatedPvPower
        {   get
            {
                return (double?)this.AccumulatedPvPowerH ?? 0d * 1000d + (double?)this.AccumulatedPvPowerL ?? 0d * 0.1d;
            }
        }

    }
}
