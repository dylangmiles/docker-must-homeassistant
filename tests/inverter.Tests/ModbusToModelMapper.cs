using inverter.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace inverter.Tests
{
    public class ModbusToModelMapper
    {
        internal static void Map<T>(short startAddress, short[] values, T model)
        {
            var dictionary = GetSensorPropertyInfos<T>();

            var index = startAddress;
            foreach(var value in values)
            {
                var propertyInfo = dictionary[index];
                propertyInfo.SetValue(model, value);

                index ++;
            }

        }


        private static Dictionary<short, PropertyInfo> GetSensorPropertyInfos<T>()
        {
            var dictionary = new Dictionary<short, PropertyInfo>();

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