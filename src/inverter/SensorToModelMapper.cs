using inverter.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace inverter
{
    public class SensorToModelMapper
    {
        public static void Map<T>(short startAddress, ushort[] values, T model)
        {
            //Generate a lookup from sensor id to class property.
            var dictionary = GetModbusSensorPropertyInfos<T>();

            var index = startAddress;
            foreach (var value in values)
            {

                //If the property does not exist, continue
                if (dictionary.ContainsKey(index) == false)
                {
                    index++;
                    continue;
                }

                //Get the property we are interested in
                var property = dictionary[index];

                //Get the sensor attributes
                var attribute = property.GetCustomAttributes(true).Where(y => y.GetType() == typeof(ModbusSensorAttribute)).First() as ModbusSensorAttribute;

                if (property.PropertyType == typeof(double?))
                {
                    property.SetValue(model, value * attribute.Coefficient);
                }

                if (property.PropertyType == typeof(short?))
                {
                    property.SetValue(model, (short)(value * attribute.Coefficient));
                }


                index++;
            }

        }


        public static Dictionary<short, PropertyInfo> GetModbusSensorPropertyInfos<T>()
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

        public static Dictionary<string, PropertyInfo> GetPublishedSensorPropertyInfos<T>()
        {
            var dictionary = new Dictionary<string, PropertyInfo>();

            PropertyInfo[] properties = typeof(T).GetProperties();

            var propertyInfos = properties
                .Where(x => x.CustomAttributes.Any(y => y.AttributeType == typeof(SensorInterpretationAttribute)));

            foreach (PropertyInfo property in propertyInfos)
            {
                var attribute = property.GetCustomAttributes(true).Where(y => y.GetType() == typeof(SensorInterpretationAttribute)).First() as SensorInterpretationAttribute;
                dictionary.Add(property.Name, property);
            }

            return dictionary;
        }
    }


}