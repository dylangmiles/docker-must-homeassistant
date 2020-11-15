using System;

namespace inverter.Models
{
    public class SensorDefinition
    {
        public ushort Address { get; internal set; }
        public string Name { get; set; }
        public double Coefficient { get; internal set; }
        public bool IsSigned { get; internal set; }
        public string DataType { get; internal set; }
        public string Uom { get; internal set; }
        public string Icon { get; internal set; }
        public string[] Lookup { get; internal set; }
        public string Remarks { get; internal set; }
        public bool Publish { get; internal set; }
    }
}
