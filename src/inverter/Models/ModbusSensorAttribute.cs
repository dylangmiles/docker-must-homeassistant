using System;
using System.Collections.Generic;
using System.Text;

namespace inverter.Models
{
    [AttributeUsage(AttributeTargets.Property)]
    public class ModbusSensorAttribute : Attribute
    {
        public short Address { get; }

        public double Coefficient { get; }

        public bool IsSigned { get; }

        public string Uom { get; }

        public ModbusSensorAttribute(short address, double coefficient, bool isSigned = true, string uom = null)
        {
            this.Address = address;
            this.Coefficient = coefficient;
            this.IsSigned = isSigned;
            this.Uom = uom;
        }

    }
}
