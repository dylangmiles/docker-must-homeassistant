using System;
using System.Collections.Generic;
using System.Text;

namespace inverter.Models
{
    /// <summary>
    /// Values from the PH1800 series charger module
    /// </summary>
    public class Pc1800Module
    {
        [ModbusSensor(10000, 1.0, true)]
        public short? MachineTypeHigh { get; set; }

        [ModbusSensor(10001, 1.0, true)]
        public short? MachineTypeLow { get; set; }

        [ModbusSensor(10004, 1.0, true)]
        public short? HardwareVersion { get; set; }

        [ModbusSensor(10005, 1.0, true)]
        public short? SoftwareVersion { get; set; }

        [ModbusSensor(15201, 1.0, true)]
        public short? ChargerWorkstate { get; set; }
        
        [ModbusSensor(15202, 1.0, true)]
        public short? MpptState { get; set; }

        [ModbusSensor(15203, 1.0, true)]
        public short? ChargingState { get; set; }

        [ModbusSensor(15205, 0.1, true, "V")]
        public double? PvVoltage { get; set; }

        [ModbusSensor(15206, 0.1, true, "V")]
        public double? BatteryVoltage { get; set; }

        [ModbusSensor(15207, 0.1, true, "A")]
        public double? ChargerCurrent { get; set; }

        [ModbusSensor(15208, 1.0, true, "W")]
        public short? ChargerPower {get; set;}
    
        [ModbusSensor(15209, 1.0, true, "℃")]
        public short? RadiatorTemp {get; set;}
    
        [ModbusSensor(15210, 1.0, true, "℃")]
        public short? ExternalTemp { get; set; }

        [ModbusSensor(15211, 1.0, true)]
        public short? BatteryRelay { get; set; }

        [ModbusSensor(15212, 1.0, true)]
        public short? PvRelay { get; set; }

        [ModbusSensor(15213, 1.0, true)]
        public short? ErrorMessage { get; set; }

        [ModbusSensor(15214, 1.0, true)]
        public short? WarningMessage { get; set; }

        [ModbusSensor(15215, 1.0, true, "V")]
        public short? BattVolGrade {get; set;}
    
        [ModbusSensor(15216, 0.1, true, "A")]
        public double? RatedCurrent {get; set;}
    
        [ModbusSensor(15217, 1000.0, true, "KWH")]
        public int? AccumulatedPvPowerH { get; set; }

        [ModbusSensor(15218, 0.1, true, "KWH")]
        public double? AccumulatedPvPowerL { get; set; }

        [ModbusSensor(15219, 1.0, true, "days")]
        public short? AccumulatedDay {get; set;}
    
        [ModbusSensor(15220, 1.0, true, "hours")]
        public short? AccumulatedHour {get; set;}
    
        [ModbusSensor(15221, 1.0, true, "minutes")]
        public short? AccumulatedMinute { get; set; }
    
        [ModbusSensor(15222, 1.0, true)]
        public short? CommunicationProtocolEdition { get; set; }

        [ModbusSensor(15223, 1.0, true, "%")]
        public short? Soc { get; set; }
    
        [ModbusSensor(15224, 1.0, true)]
        public short? ArrowFlag { get; set; }

        [ModbusSensor(10002, 1.0, true)]
        public short? SerialNumberHigh { get; set; }

        [ModbusSensor(10003, 1.0, true)]
        public short? SerialNumberLow { get; set; }

        [ModbusSensor(10006, 1.0, true)]
        public short? pvVoltageCalibrationCoefficient { get; set; }

        [ModbusSensor(10007, 1.0, true)]
        public short? BatteryVoltageCalibrationCoefficient { get; set; }

        [ModbusSensor(10008, 1.0, true)]
        public short? ChargerCurrentCalibrationCoefficient { get; set; }

        [ModbusSensor(10101, 1.0, true)]
        public short? ChargerWorkEnable { get; set; }

        [ModbusSensor(10103, 0.1, true, "V")]
        public double? BatteryFloatVoltage { get; set; }

        [ModbusSensor(10104, 0.1, true, "V")]
        public double? BatteryAbsorptionVoltage { get; set; }

        [ModbusSensor(10105, 0.1, true, "V")]
        public double? BatteryLowVoltage { get; set; }

        [ModbusSensor(10107, 0.1, true, "V")]
        public double? BatteryHighVoltage { get; set; }

        [ModbusSensor(10108, 0.1, true, "A")]
        public double? MaxChargerCurrent { get; set; }

        [ModbusSensor(10110, 1.0, true)]
        public short? BatteryType { get; set; }

        [ModbusSensor(10111, 1.0, true)]
        public short? BatteryAh { get; set; }

        [ModbusSensor(10112, 1.0, true)]
        public short? RemoveTheAccumulatedData { get; set; }

        [ModbusSensor(10113, 1.0, true)]
        public short? BatteryVoltageGrade { get; set; }

        [ModbusSensor(10116, 1.0, true, "minutes")]
        public short? CvCharingMaxTime { get; set; }

        [ModbusSensor(10117, 0.1, true, "mV")]
        public double? BtsTemperatureCompensationRatio { get; set; }

        [ModbusSensor(10118, 1.0, true)]
        public short? BatteryEqualizationEnable { get; set; }

        [ModbusSensor(10119, 0.1, true, "V")]
        public double? BatteryEqualizationVoltage { get; set; }

        [ModbusSensor(10120, 0.1, true, "A")]
        public double? MaxCurrentOfBatteryEqualization { get; set; }

        [ModbusSensor(10121, 1.0, true)]
        public short? BatteryEqualizedTime { get; set; }

        [ModbusSensor(10122, 1.0, true, "minutes")]
        public short? BatteryEqualizedTimeout { get; set; }

        [ModbusSensor(10123, 1.0, true, "days")]
        public short? EqualizationInterval { get; set; }

        [ModbusSensor(10124, 1.0, true)]
        public short? EqualizationActivedImmediately { get; set; }

        [ModbusSensor(10125, 1.0, true)]
        public short? SystemSetting { get; set; }

        [ModbusSensor(10126, 1.0, true)]
        public short? ResetTheParameter { get; set; }

    }
}
