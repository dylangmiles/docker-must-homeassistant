using System;
using System.Collections.Generic;
using System.Text;

namespace inverter.Models
{
    [AttributeUsage(AttributeTargets.Property)]
    public class ModbusSensorAttribute : Attribute
    {
        
        public string Name {get;}

        public int Address { get; }

        public double Coefficient { get; }

        public bool IsSigned { get; }

        public string Uom { get; }

        public ModbusSensorAttribute(int address, string name, double coefficient, bool isSigned = true, string uom = "")
        {
            this.Address = address;
            this.Coefficient = coefficient;
            this.IsSigned = isSigned;
            this.Name = name;
        }

    }
}
