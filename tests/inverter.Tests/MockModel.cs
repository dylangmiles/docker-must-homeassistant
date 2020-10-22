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
    }
}