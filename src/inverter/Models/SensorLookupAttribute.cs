using System;

namespace inverter.Models
{
    [AttributeUsage(AttributeTargets.Property)]
    public class SensorLookupAttribute : Attribute
    {

        public SensorLookupAttribute(string[] lookup)
        {
            this.Lookup = lookup;
        }

        public string[] Lookup {get;}
    }
}