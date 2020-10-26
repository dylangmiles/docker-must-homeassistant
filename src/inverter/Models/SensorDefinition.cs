using System;

namespace inverter.Models
{
    public class SensorDefinition
    {
        public short Address { get; internal set; }
        public string Uom { get; internal set; }
        public double Coefficient { get; internal set; }
        public Type DataType { get; internal set; }
        public string[] Lookup { get; internal set; }
        public string Remarks { get; internal set; }
        public bool IsSigned { get; internal set; }
    }
}
