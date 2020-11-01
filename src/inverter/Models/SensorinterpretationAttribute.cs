using System;
using System.Collections.Generic;
using System.Text;

namespace inverter.Models
{
    [AttributeUsage(AttributeTargets.Property)]
    public class SensorInterpretationAttribute : Attribute
    {
        public SensorInterpretationAttribute(string icon, string uom = null, bool publish = true)
        {
            this.Uom = uom;
            this.Icon = icon;
            this.Publish = publish;
        }

        public string Uom { get; }
        public string Icon { get; }
        public bool Publish { get; }
    }
}
