using System;
using System.Collections.Generic;
using System.Text;

namespace inverter.Models
{
    public class Vc1800
    {
        [ModbusSensor(10000, "machineTypeHigh", 1.0, true)]
        public short? MachineTypeHigh { get; set; }

        [ModbusSensor(10001, "machineTypeLow", 1.0, true)]
        public short? MachineTypeLow { get; set; }

        [ModbusSensor(10004, "hardwareVersion", 1.0, true)]
        public short? HardwareVersion { get; set; }

        [ModbusSensor(10005, "softwareVersion", 1.0, true)]
        public short? SoftwareVersion { get; set; }

        [ModbusSensor(15201, "chargerWorkstate", 1.0, true)]
        public short? ChargerWorkstate { get; set; }
        
        [ModbusSensor(15202, "mpptState", 1.0, true)]
        public short? MpptState { get; set; }

        [ModbusSensor(15203, "chargingState", 1.0, true)]
        public short? ChargingState { get; set; }

        [ModbusSensor(15205, "pvVoltage", 0.1, true, "V")]
        public double? PvVoltage { get; set; }

        [ModbusSensor(15206, "batteryVoltage", 0.1, true, "V")]
        public double? BatteryVoltage { get; set; }

        [ModbusSensor(15207, "chargerCurrent", 0.1, true, "A")]
        public double? ChargerCurrent { get; set; }

        [ModbusSensor(15208, "chargerPower", 1.0, true, "W")]
        public short? ChargerPower {get; set;}
    
        [ModbusSensor(15209, "radiatorTemp", 1.0, true, "℃")]
        public short? RadiatorTemp {get; set;}
    
        [ModbusSensor(15210, "externalTemp", 1.0, true, "℃")]
        public short? ExternalTemp { get; set; }

        [ModbusSensor(15211, "batteryRelay", 1.0, true)]
        public short? BatteryRelay { get; set; }

        [ModbusSensor(15212, "pvRelay", 1.0, true)]
        public short? PvRelay { get; set; }

        [ModbusSensor(15213, "errorMessage", 1.0, true)]
        public short? ErrorMessage { get; set; }

        [ModbusSensor(15214, "warningMessage", 1.0, true)]
        public short? WarningMessage { get; set; }

        [ModbusSensor(15215, "battVolGrade", 1.0, true, "V")]
        public short? BattVolGrade {get; set;}
    
        [ModbusSensor(15216, "ratedCurrent", 0.1, true, "A")]
        public double? RatedCurrent {get; set;}
    
        [ModbusSensor(15217, "accumulatedPVPowerHigh", 1000.0, true, "KWH")]
        public int? AccumulatedPvPowerH { get; set; }

        [ModbusSensor(15218, "accumulatedPVPowerLow", 0.1, true, "KWH")]
        public double? AccumulatedPvPowerL { get; set; }

        [ModbusSensor(15219, "accumulatedDay", 1.0, true, "days")]
        public short? AccumulatedDay {get; set;}
    
        [ModbusSensor(15220, "accumulatedHour", 1.0, true, "hours")]
        public short? AccumulatedHour {get; set;}
    
        [ModbusSensor(15221, "accumulatedMinute", 1.0, true, "minutes")]
        public short? AccumulatedMinute { get; set; }
    
        [ModbusSensor(15222, "communicationProtocolEdition", 1.0, true)]
        public short? CommunicationProtocolEdition { get; set; }

        [ModbusSensor(15223, "soc", 1.0, true, "%")]
        public short? Soc { get; set; }
    
        [ModbusSensor(15224, "arrowFlag", 1.0, true)]
        public short? ArrowFlag { get; set; }

        [ModbusSensor(10002, "serialNumberHigh", 1.0, true)]
        public short? SerialNumberHigh { get; set; }

        [ModbusSensor(10003, "serialNumberLow", 1.0, true)]
        public short? SerialNumberLow { get; set; }

        [ModbusSensor(10006, "pvVoltageCalibrationCoefficient", 1.0, true)]
        public short? pvVoltageCalibrationCoefficient { get; set; }

        [ModbusSensor(10007, "batteryVoltageCalibrationCoefficient", 1.0, true)]
        public short? BatteryVoltageCalibrationCoefficient { get; set; }

        [ModbusSensor(10008, "chargerCurrentCalibrationCoefficient", 1.0, true)]
        public short? ChargerCurrentCalibrationCoefficient { get; set; }

        [ModbusSensor(10101, "chargerWorkEnable", 1.0, true)]
        public short? ChargerWorkEnable { get; set; }

        [ModbusSensor(10103, "batteryFloatVoltage", 0.1, true, "V")]
        public double? BatteryFloatVoltage { get; set; }

        [ModbusSensor(10104, "batteryAbsorbtionVoltage", 0.1, true, "V")]
        public double? BatteryAbsorptionVoltage { get; set; }

        [ModbusSensor(10105, "batteryLowVoltage", 0.1, true, "V")]
        public double? BatteryLowVoltage { get; set; }

        [ModbusSensor(10107, "batteryHighVoltage", 0.1, true, "V")]
        public double? BatteryHighVoltage { get; set; }

        [ModbusSensor(10108, "maxChargerCurrent", 0.1, true, "A")]
        public double? MaxChargerCurrent { get; set; }

        [ModbusSensor(10110, "batteryType", 1.0, true)]
        public short? BatteryType { get; set; }

        [ModbusSensor(10111, "batteryAH", 1.0, true)]
        public short? BatteryAh { get; set; }

        [ModbusSensor(10112, "removeTheAccumulatedData", 1.0, true)]
        public short? RemoveTheAccumulatedData { get; set; }

        [ModbusSensor(10113, "batteryVoltageGrade", 1.0, true)]
        public short? BatteryVoltageGrade { get; set; }

        [ModbusSensor(10116, "cvChargingMaxTime", 1.0, true, "minutes")]
        public short? CvCharingMaxTime { get; set; }

        [ModbusSensor(10117, "btsTemperatureCompensationRatio", 0.1, true, "mV")]
        public double? BtsTemperatureCompensationRatio { get; set; }

        [ModbusSensor(10118, "batteryEqualizationEnable", 1.0, true)]
        public short? BatteryEqualizationEnable { get; set; }

        [ModbusSensor(10119, "batteryEqualizationVoltage", 0.1, true, "V")]
        public double? BatteryEqualizationVoltage { get; set; }

        [ModbusSensor(10120, "maxCurrentOfBatteryEqualization", 0.1, true, "A")]
        public double? MaxCurrentOfBatteryEqualization { get; set; }

        [ModbusSensor(10121, "batteryEqualizedTime", 1.0, true)]
        public short? BatteryEqualizedTime { get; set; }

        [ModbusSensor(10122, "batteryEqualizedTimeout", 1.0, true, "minutes")]
        public short? BatteryEqualizedTimeout { get; set; }

        [ModbusSensor(10123, "equalizationInterval", 1.0, true, "days")]
        public short? EqualizationInterval { get; set; }

        [ModbusSensor(10124, "equalizationActiveImmediately", 1.0, true)]
        public short? EqualizationActivedImmediately { get; set; }

        [ModbusSensor(10125, "systemSetting", 1.0, true)]
        public short? SystemSetting { get; set; }

        [ModbusSensor(10126, "resetTheParameter", 1.0, true)]
        public short? ResetTheParameter { get; set; }

    }
}
