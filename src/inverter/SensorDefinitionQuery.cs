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
            var dictionary = ModbusSensorHelper.GetModbusSensorPropertyInfos<T>();
            var results = new List<SensorDefinition>();


            foreach (var property in dictionary.Values)
            {
                //Get the attributes if they exist
                var modbus = property.GetCustomAttributes(true).Where(y => y.GetType() == typeof(ModbusSensorAttribute)).First() as ModbusSensorAttribute;
                var sensorLookup = property.GetCustomAttributes(true).Where(y => y.GetType() == typeof(SensorLookupAttribute)).FirstOrDefault() as SensorLookupAttribute;
                var remarks = property.GetCustomAttributes(true).Where(y => y.GetType() == typeof(SensorRemarksAttribute)).FirstOrDefault() as SensorRemarksAttribute;
                var interpretation = property.GetCustomAttributes(true).Where(y => y.GetType() == typeof(SensorInterpretationAttribute)).FirstOrDefault() as SensorInterpretationAttribute;

                var definition = new SensorDefinition()
                {
                    Address = modbus.Address,
                    Coefficient = modbus.Coefficient,
                    IsSigned = modbus.IsSigned,
                    Remarks = remarks == null ? null : remarks.Remarks,
                    Lookup = sensorLookup == null ? new string[] { } : sensorLookup.Lookup,
                    DataType = Nullable.GetUnderlyingType(property.PropertyType).ToString(),
                    Name = property.Name,
                    Icon = interpretation == null ? null : interpretation.Icon,
                    Uom = interpretation == null ? null: interpretation.Uom,
                    Publish = interpretation == null ? false : interpretation.Publish
                };

                results.Add(definition);

            }

            return results;
        }
        
    }
}
