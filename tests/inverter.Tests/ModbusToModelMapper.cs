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
            //Generate a lookup from sensor id to class property.
            var dictionary = GetSensorPropertyInfos<T>();

            var index = startAddress;
            foreach(var value in values)
            {
                //Get the property we are interested in
                var property = dictionary[index];

                //Get the sensor attributes
                var attribute = property.GetCustomAttributes(true).Where(y => y.GetType() == typeof(ModbusSensorAttribute)).First() as ModbusSensorAttribute;

                if (property.PropertyType == typeof(double?)) {
                    property.SetValue(model, (double)(value * attribute.Coefficient));
                }

                if (property.PropertyType == typeof(short?))
                {
                    property.SetValue(model, (short)(value * attribute.Coefficient));
                }


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