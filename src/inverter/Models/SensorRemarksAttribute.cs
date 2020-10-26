using System;

namespace inverter.Models
{
    [AttributeUsage(AttributeTargets.Property)]
    public class SensorRemarksAttribute : Attribute
    {
        public SensorRemarksAttribute(string remarks)
        {
            this.Remarks = remarks;
        }

        public string Remarks {get; set;}
    }
}