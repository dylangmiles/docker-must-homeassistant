using inverter.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace inverter
{
    public class SensorDefinitionQuery
    {
        public static IEnumerable<SensorDefinition> Get<T>()
        {
            //Generate a lookup from sensor id to class property.
            var dictionary = GetSensorPropertyInfos<T>();
            var results = new List<SensorDefinition>();


            foreach (var property in dictionary.Values)
            {
                //Get the attributes if they exist
                var modbus = property.GetCustomAttributes(true).Where(y => y.GetType() == typeof(ModbusSensorAttribute)).First() as ModbusSensorAttribute;
                var sensorLookup = property.GetCustomAttributes(true).Where(y => y.GetType() == typeof(SensorLookupAttribute)).FirstOrDefault() as SensorLookupAttribute;
                var remarks = property.GetCustomAttributes(true).Where(y => y.GetType() == typeof(SensorRemarksAttribute)).FirstOrDefault() as SensorRemarksAttribute;

                var definition = new SensorDefinition()
                {
                    Address = modbus.Address,
                    Coefficient = modbus.Coefficient,
                    IsSigned = modbus.IsSigned,
                    Uom = modbus.Uom,
                    Remarks = remarks == null ? null : remarks.Remarks,
                    Lookup = sensorLookup == null ? new string[] { } : sensorLookup.Lookup,
                    DataType = Nullable.GetUnderlyingType(property.PropertyType).ToString(),
                    Name = property.Name
                };

                results.Add(definition);

            }

            return results;
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
