using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace inverter.Models
{
    public class ModbusSensorHelper
    {
        public static Dictionary<ushort, PropertyInfo> GetModbusSensorPropertyInfos<T>()
        {
            var dictionary = new Dictionary<ushort, PropertyInfo>();

            PropertyInfo[] properties = typeof(T).GetProperties();

            var propertyInfos = properties
                .Where(x => x.CustomAttributes.Any(y => y.AttributeType == typeof(ModbusSensorAttribute)));

            foreach (PropertyInfo property in propertyInfos)
            {
                var attribute = property.GetCustomAttributes(true).Where(y => y.GetType() == typeof(ModbusSensorAttribute)).First() as ModbusSensorAttribute;
                dictionary.Add(attribute.Address, property);
            }

            return dictionary;
        }
    }
}
