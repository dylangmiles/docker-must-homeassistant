using System;
using System.Collections.Generic;
using System.Text;

namespace inverter.Models
{
    [AttributeUsage(AttributeTargets.Property)]
    public class ModbusSensorAttribute : Attribute
    {
        public ushort Address { get; }

        public double Coefficient { get; }

        public bool IsSigned { get; }

        public ModbusSensorAttribute(ushort address, double coefficient, bool isSigned = true)
        {
            Address = address;
            Coefficient = coefficient;
            IsSigned = isSigned;
        }

    }
}
