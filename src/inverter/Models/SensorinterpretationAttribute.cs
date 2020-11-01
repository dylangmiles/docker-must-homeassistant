using System;
using System.Collections.Generic;
using System.Text;

namespace inverter.Models
{
    [AttributeUsage(AttributeTargets.Property)]
    public class SensorinterpretationAttribute : Attribute
    {
        public SensorinterpretationAttribute(string icon, string uom = null)
        {
            this.Uom = uom;
            this.Icon = icon;
        }

        public string Uom { get; }
        public string Icon { get; }
    }
}
