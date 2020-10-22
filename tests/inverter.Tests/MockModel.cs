using inverter.Models;

namespace inverter.Tests
{
    internal class MockModel
    {
        public MockModel()
        {
        }

        [ModbusSensor(20000, "sensor1", 1.0)]
        public short? Sensor1 { get; internal set; }

        [ModbusSensor(20001, "sensor2", 1.0)]
        public short? Sensor2 { get; internal set; }

        [ModbusSensor(20002, "sensor3", 1.0)]
        public short? Sensor3 { get; internal set; }


        [ModbusSensor(15001, "Sensor15001", 0.1)]
        public double? Sensor15001 { get; internal set; }

        [ModbusSensor(15002, "Sensor15002", 0.1)]
        public double? Sensor15002 { get; internal set; }
    }
}