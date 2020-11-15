using System;
using System.Collections.Generic;
using System.Text;
using inverter.Modbus;

namespace inverter.Models
{
    /// <summary>
    /// The sensor definitions of the PH1800 series of inverters manufactured by Must Solar.
    /// </summary>
    public partial class Ph1800
    {


        [ModbusSensor(20000, 1.00d, true)]
        public System.Int16? MachineTypeH { get; set; }

        [ModbusSensor(20001, 1.00d, true)]
        public System.Int16? MachineTypeL { get; set; }

        [ModbusSensor(20002, 1.00d, true)]
        public System.Int16? SerialNumberH { get; set; }

        [ModbusSensor(20003, 1.00d, true)]
        public System.Int16? SerialNumberL { get; set; }

        [ModbusSensor(20004, 1.00d, true)]
        public System.Int16? HardwareNo { get; set; }

        [ModbusSensor(20005, 1.00d, true)]
        public System.Int16? SoftwareNo { get; set; }

        [ModbusSensor(20006, 1.00d, true)]
        public System.Int16? ProtocalEditionNo { get; set; }

        [ModbusSensor(20009, 1.00d, true)]
        public System.Int16? BatteryVoltageC { get; set; }

        [ModbusSensor(20010, 1.00d, true)]
        public System.Int16? InverterVoltageC { get; set; }

        [ModbusSensor(20011, 1.00d, true)]
        public System.Int16? GridVoltageC { get; set; }

        [ModbusSensor(20012, 1.00d, true)]
        public System.Int16? BusVoltageC { get; set; }

        [ModbusSensor(20013, 1.00d, true)]
        public System.Int16? ControlCurrentC { get; set; }

        [ModbusSensor(20014, 1.00d, true)]
        public System.Int16? InverterCurrentC { get; set; }

        [ModbusSensor(20015, 1.00d, true)]
        public System.Int16? GridCurrentC { get; set; }

        [ModbusSensor(20016, 1.00d, true)]
        public System.Int16? LoadCurrentC { get; set; }

        [ModbusSensor(20101, 1.00d, true)]
        public System.Int16? InverterOffgridWorkEnable { get; set; }

        [ModbusSensor(20102, 0.10d, true)]
        [SensorRemarks(
@"
Set the output voltage. (220VAC-240VAC).
"
        )]
        public System.Double? InverterOutputVoltageSet { get; set; }

        [ModbusSensor(20103, 0.01d, true)]
        [SensorRemarks(
@"
Set the output frequency. (50Hz or 60Hz).
"
        )]
        public System.Double? InverterOutputFrequencySet { get; set; }

        [ModbusSensor(20104, 1.00d, true)]
        public System.Int16? InverterSearchModeEnable { get; set; }

        [ModbusSensor(20108, 1.00d, true)]
        public System.Int16? InverterDischargerToGridEnable { get; set; }

        [ModbusSensor(20109, 1.00d, true)]
        [SensorLookup(new string[]
            {
                "",
                "SBU",
                "SUB",
                "UTI",
                "SOL",
            }
        )]
        [SensorRemarks(
@"
Output source priority selection

SBU
Solar energy provides power to the loads as first priority, If solar energy is not sufficient to power all connected loads, battery energy will supply power to the loads at the same time. Utility provides power to the loads only when battery voltage drops to either low-level warning voltage or the setting point in program 20118 (20) or solar and battery is not sufficient. The battery energy will supply power to the load in the condition of the utility is unavailable or the battery voltage is higher than the setting point in program 20119 (21) (when BLU is selected) or program 20118 (20) (when LBU is selected). If the solar is available, but the voltage is lower than the setting point in program 20118 (20), the utility will charge the battery until the battery voltage reaches the setting point in program 20118 (20) to protect the battery from damage.

SUB
Solar energy provides power to the loads as first priority, If solar energy is not sufficient to power all connected loads, Utility energy will supply power to the loads at the same time. The battery energy will supply power to the load only in the condition of the utility is unavailable. If the solar is unavailable, the utility will charge the battery until the battery voltage reaches the setting point in program 20119 (21). If the solar is available, but the voltage is lower than the setting point in program 20118 (20), the utility will charge the battery until the battery voltage reaches the setting point in program 20118 (20) to protect the battery from damage.

UTI
Utility will provide power to the loads as first priority. Solar and battery energy will provide power to the loads only when utility power is not available.

SOL
Solar energy provides power to the loads as first priority. If battery voltage has been higher than the setting point in program 20119 (21) for 5 minutes, and the solar energy has been available for 5 minutes too, the inverter will turn to battery mode, solar and battery will provide power to the loads at the same time. When the battery voltage drops to the setting point in program 20118 (20), the inverter will turn to bypass mode, utility provides power to the load only, and the solar will charge the battery at the same time.

"
        )]
        public System.Int16? EnergyUseMode { get; set; }

        [ModbusSensor(20111, 1.00d, true)]
        [SensorLookup(new string[]
            {
                "VDE4105",
                "UPS",
                "APL",
                "GEN",
            }
        )]
        [SensorRemarks(
@"
AC input voltage range

VDE4105
If selected, acceptable AC input voltage range will conform to VDE4105(184VAC-253VAC)

UPS
If selected, acceptable AC input voltage range will be within 170-280VAC.

APL (default)
If selected, acceptable AC input voltage range will be within 90-280VAC.

GEN
When the user uses the device to connect the generator, select the generator mode.
"
        )]
        public System.Int16? GridProtectStandard { get; set; }

        [ModbusSensor(20112, 1.00d, true)]
        [SensorLookup(new string[]
            {
                "LBU",
                "BLU",
            }
        )]
        [SensorRemarks(
@"
Solar supply priority.

LBU
Solar energy provides power to
the loads as first priority

BLU
Solar energy provides power to
charge battery as first priority

"
        )]
        public System.Int16? SolarUseAim { get; set; }

        [ModbusSensor(20113, 0.10d, true)]
        public System.Double? InverterMaxDischargerCurrent { get; set; }

        [ModbusSensor(20118, 0.10d, true)]
        [SensorRemarks(
@"
Battery stop discharging voltage when grid is available

This setting affects the behaviour of 20109 (01) when SBU, SUB or SOL are selected.

12V model:
Default setting is 11.5V. Setting range is from 11V to 14.5V.

12V model:
Default setting is 23V. Setting range is from 22.0V to 29.0V.

Increment of each click is 0.1V.
"
        )]
        public System.Double? BatteryStopDischargingVoltage { get; set; }

        [ModbusSensor(20119, 0.10d, true)]
        [SensorRemarks(
@"
Battery stop charging voltage when grid is available

This setting affects the behaviour of 20109 (01) when SBU, SUB or SOL are selected.

12V model:
Default setting is 13.5V. Setting range is from 11V to 14.5V.

12V model:
Default setting is 27V. Setting range is from 22.0V to 29.0V.

Increment of each click is 0.1V.
"
        )]
        public System.Double? BatteryStopChargingVoltage { get; set; }

        [ModbusSensor(20125, 0.10d, true)]
        [SensorRemarks(
@"
Maximum utility charging current

1kW
10A (default) with 20A maximum.

2-3kW
20A (default) with 30A maximum.



"
        )]
        public System.Double? GridMaxChargerCurrentSet { get; set; }

        [ModbusSensor(20127, 0.10d, true)]
        [SensorRemarks(
@"
Low DC cut off battery voltage

12V model:
Default setting is 10.2V. Setting range is from 10.0V to 12V.

24V model:
Default setting is 20.4V. Setting range is from 20.0V to 24.0V.

If 'User-Defined' LI is selected in program (10110) 14, this program can be set up. Increment of each click is 0.1V.

Low DC cut-off voltage will be fixed to setting value no matter what percentage of load is connected.
"
        )]
        public System.Double? BatteryLowVoltage { get; set; }

        [ModbusSensor(20128, 0.10d, true)]
        public System.Double? BatteryHighVoltage { get; set; }

        [ModbusSensor(20132, 0.10d, true)]
        [SensorRemarks(
@"
Maximum charging current

Max.charging current=utility charging current + solar charging current.

1kW
60A (default). Can be from 1A to 70A.

2-3kW MPPT-50A
60A (default). Can be from 1A to 80A.

2-3kW MPPT-60A
60A (default). Can be from 1A to 80A.

2-3kW MPPT-80A
80A (default). Can be from 1A to 80A.

"
        )]
        public System.Double? MaxCombineChargerCurrent { get; set; }

        [ModbusSensor(20142, 1.00d, true)]
        [SensorLookup(new string[]
            {
                "OverLoadRestartForbid",
                "OverTempRestartForbid",
                "OverLoadBypassForbid",
                "AutoTurnPageFlagForbid",
                "GridBuzzEnable(only use by PV1800)",
                "BuzzForbide(only use by PV1800)",
                "LcdLightEnable",
                "RecordFaultForbid",
                "",
                "",
                "",
                "",
                "",
                "",
                "",
                "",
            }
        )]
        [SensorRemarks(
@"
TODO: This is not coming through in poll and not sure of default values.
"
        )]
        public System.UInt16? SystemSetting { get; set; }

        [ModbusSensor(20143, 1.00d, true)]
        [SensorLookup(new string[]
            {
                "Solar first",
                "",
                "Solar and Utility (default)",
                "Only Solar",
            }
        )]
        [SensorRemarks(
@"
Charger source priority

If this inverter/charger is working in Line, Standby or Fault mode, charger source can be programmed as below:

Solar first
Solar energy will charge battery as first priority. Utility will charge battery only when solar energy is not available.

Solar and utility (default)
Solar energy and utility will charge battery at the same time.

Only solar
Solar energy will be the only charger source no matter utility is available or not.

If this inverter/charger is working in Battery mode or Power saving mode, only solar energy can charge battery. Solar energy will charge battery if it's available and suffcient.


"
        )]
        public System.Int16? ChargerSourcePriority { get; set; }

        [ModbusSensor(25201, 1.00d, true)]
        [SensorInterpretation("state-machine")]
        [SensorLookup(new string[]
            {
                "PowerOn",
                "SelfTest",
                "OffGrid",
                "Grid-Tie",
                "ByPass",
                "Stop",
                "Grid charging",
            }
        )]
        [SensorRemarks(
@"

PowerOn
The inverter is powering on.

SelfTest
The inverter is performing a self test.

OffGrid
The inverter will provide output power from battery and PV power.
Inverter power loads from PV energy.
Inverter power loads from battery and PV energy.
Inverter power loads from battery only.

Grid-Tie
PV energy is charger PV is on into the battery and utility provide power to the AC load.
PV is on
PV is off

ByPass
Error are caused by inside circuit error or external reasons such as over temperature, output short circuited and so on.

Stop
The inverter stop working if you turn off the inverter by the soft key or error has occurred in the condition of no grid.

Grid charging
PV energy and grid can charge batteries.

"
        )]
        public System.Int16? WorkStateNo { get; set; }

        [ModbusSensor(25202, 1.00d, true)]
        [SensorInterpretation("current-ac","Vac")]
        public System.Int16? AcVoltageGrade { get; set; }

        [ModbusSensor(25203, 1.00d, true)]
        [SensorInterpretation("lightbulb-outline","VA")]
        public System.Int16? RatedPower { get; set; }

        [ModbusSensor(25205, 0.10d, true)]
        [SensorInterpretation("current-dc","Vdc-batt")]
        public System.Double? BatteryVoltage { get; set; }

        [ModbusSensor(25206, 0.10d, true)]
        [SensorInterpretation("current-ac","Vac")]
        public System.Double? InverterVoltage { get; set; }

        [ModbusSensor(25207, 0.10d, true)]
        [SensorInterpretation("current-ac","Vac")]
        public System.Double? GridVoltage { get; set; }

        [ModbusSensor(25208, 0.10d, true)]
        [SensorInterpretation("cog-transfer-outline","Vdc/Vac")]
        public System.Double? BusVoltage { get; set; }

        [ModbusSensor(25209, 0.10d, true)]
        [SensorInterpretation("current-ac","Aac")]
        public System.Double? ControlCurrent { get; set; }

        [ModbusSensor(25210, 0.10d, true)]
        [SensorInterpretation("current-ac","Aac")]
        public System.Double? InverterCurrent { get; set; }

        [ModbusSensor(25211, 0.10d, true)]
        [SensorInterpretation("current-ac","Aac")]
        public System.Double? GridCurrent { get; set; }

        [ModbusSensor(25212, 0.10d, true)]
        [SensorInterpretation("current-ac","Aac")]
        public System.Double? LoadCurrent { get; set; }

        [ModbusSensor(25213, 1.00d, true)]
        [SensorInterpretation("cog-transfer-outline","W")]
        public System.Int16? PInverter { get; set; }

        [ModbusSensor(25214, 1.00d, true)]
        [SensorInterpretation("transmission-tower","W")]
        public System.Int16? PGrid { get; set; }

        [ModbusSensor(25215, 1.00d, true)]
        [SensorInterpretation("lightbulb-on-outline","W")]
        public System.Int16? PLoad { get; set; }

        [ModbusSensor(25216, 1.00d, true)]
        [SensorInterpretation("progress-download","%")]
        public System.Int16? LoadPercent { get; set; }

        [ModbusSensor(25217, 1.00d, true)]
        [SensorInterpretation("cog-transfer-outline","VA")]
        public System.Int16? SInverter { get; set; }

        [ModbusSensor(25218, 1.00d, true)]
        [SensorInterpretation("transmission-tower","VA")]
        public System.Int16? SGrid { get; set; }

        [ModbusSensor(25219, 1.00d, true)]
        [SensorInterpretation("lightbulb-on-outline","VA")]
        public System.Int16? SLoad { get; set; }

        [ModbusSensor(25221, 1.00d, true)]
        [SensorInterpretation("cog-transfer-outline","Var")]
        public System.Int16? QInverter { get; set; }

        [ModbusSensor(25222, 1.00d, true)]
        [SensorInterpretation("transmission-tower","Var")]
        public System.Int16? QGrid { get; set; }

        [ModbusSensor(25223, 1.00d, true)]
        [SensorInterpretation("lightbulb-on-outline","Var")]
        public System.Int16? QLoad { get; set; }

        [ModbusSensor(25225, 0.01d, true)]
        [SensorInterpretation("sine-wave","Hz")]
        public System.Double? InverterFrequency { get; set; }

        [ModbusSensor(25226, 0.01d, true)]
        [SensorInterpretation("sine-wave","Hz")]
        public System.Double? GridFrequency { get; set; }

        [ModbusSensor(25229, 1.00d, true)]
        [SensorInterpretation("format-list-numbered")]
        public System.Int16? InverterMaxNumber { get; set; }

        [ModbusSensor(25230, 1.00d, true)]
        [SensorInterpretation("format-list-bulleted-type")]
        public System.Int16? CombineType { get; set; }

        [ModbusSensor(25231, 1.00d, true)]
        [SensorInterpretation("format-list-numbered")]
        public System.Int16? InverterNumber { get; set; }

        [ModbusSensor(25233, 1.00d, true)]
        [SensorInterpretation("thermometer","oC")]
        public System.Int16? AcRadiatorTemp { get; set; }

        [ModbusSensor(25234, 1.00d, true)]
        [SensorInterpretation("thermometer","oC")]
        public System.Int16? TransformerTemp { get; set; }

        [ModbusSensor(25235, 1.00d, true)]
        [SensorInterpretation("thermometer","oC")]
        public System.Int16? DcRadiatorTemp { get; set; }

        [ModbusSensor(25237, 1.00d, true)]
        [SensorInterpretation("electric-switch")]
        public System.Int16? InverterRelayStateNo { get; set; }

        [ModbusSensor(25238, 1.00d, true)]
        [SensorInterpretation("electric-switch")]
        public System.Int16? GridRelayStateNo { get; set; }

        [ModbusSensor(25239, 1.00d, true)]
        [SensorInterpretation("electric-switch")]
        public System.Int16? LoadRelayStateNo { get; set; }

        [ModbusSensor(25240, 1.00d, true)]
        [SensorInterpretation("electric-switch")]
        public System.Int16? NLineRelayStateNo { get; set; }

        [ModbusSensor(25241, 1.00d, true)]
        [SensorInterpretation("electric-switch")]
        public System.Int16? DcRelayStateNo { get; set; }

        [ModbusSensor(25242, 1.00d, true)]
        [SensorInterpretation("electric-switch")]
        public System.Int16? EarthRelayStateNo { get; set; }

        [ModbusSensor(25245, 1.00d, true)]
        [SensorInterpretation("chart-bell-curve-cumulative","W-High", false)]
        public System.Int16? AccumulatedChargerPowerH { get; set; }

        [ModbusSensor(25246, 1.00d, true)]
        [SensorInterpretation("chart-bell-curve-cumulative","W-Low", false)]
        public System.Int16? AccumulatedChargerPowerL { get; set; }

        [ModbusSensor(25247, 1.00d, true)]
        [SensorInterpretation("chart-bell-curve-cumulative","W-High", false)]
        public System.Int16? AccumulatedDischargerPowerH { get; set; }

        [ModbusSensor(25248, 1.00d, true)]
        [SensorInterpretation("chart-bell-curve-cumulative","W-Low", false)]
        public System.Int16? AccumulatedDischargerPowerL { get; set; }

        [ModbusSensor(25249, 1.00d, true)]
        [SensorInterpretation("chart-bell-curve-cumulative","W-High", false)]
        public System.Int16? AccumulatedBuyPowerH { get; set; }

        [ModbusSensor(25250, 1.00d, true)]
        [SensorInterpretation("chart-bell-curve-cumulative","W-Low", false)]
        public System.Int16? AccumulatedBuyPowerL { get; set; }

        [ModbusSensor(25251, 1.00d, true)]
        [SensorInterpretation("chart-bell-curve-cumulative","W-High", false)]
        public System.Int16? AccumulatedSellPowerH { get; set; }

        [ModbusSensor(25252, 1.00d, true)]
        [SensorInterpretation("chart-bell-curve-cumulative","W-Low", false)]
        public System.Int16? AccumulatedSellPowerL { get; set; }

        [ModbusSensor(25253, 1.00d, true)]
        [SensorInterpretation("chart-bell-curve-cumulative","W-High", false)]
        public System.Int16? AccumulatedLoadPowerH { get; set; }

        [ModbusSensor(25254, 1.00d, true)]
        [SensorInterpretation("chart-bell-curve-cumulative","W-Low", false)]
        public System.Int16? AccumulatedLoadPowerL { get; set; }

        [ModbusSensor(25255, 1.00d, true)]
        [SensorInterpretation("chart-bell-curve-cumulative","W-High", false)]
        public System.Int16? AccumulatedSelfusePowerH { get; set; }

        [ModbusSensor(25256, 1.00d, true)]
        [SensorInterpretation("chart-bell-curve-cumulative","W-Low", false)]
        public System.Int16? AccumulatedSelfusePowerL { get; set; }

        [ModbusSensor(25257, 1.00d, true)]
        [SensorInterpretation("chart-bell-curve-cumulative","W-High", false)]
        public System.Int16? AccumulatedPvsellPowerH { get; set; }

        [ModbusSensor(25258, 1.00d, true)]
        [SensorInterpretation("chart-bell-curve-cumulative","W-Low", false)]
        public System.Int16? AccumulatedPvsellPowerL { get; set; }

        [ModbusSensor(25259, 1.00d, true)]
        [SensorInterpretation("chart-bell-curve-cumulative","W-High", false)]
        public System.Int16? AccumulatedGridChargerPowerH { get; set; }

        [ModbusSensor(25260, 1.00d, true)]
        [SensorInterpretation("chart-bell-curve-cumulative","W-Low", false)]
        public System.Int16? AccumulatedGridChargerPowerL { get; set; }

        [ModbusSensor(25261, 1.00d, true)]
        [SensorInterpretation("alert-circle-outline")]
        [SensorLookup(new string[]
            {
                "Fan is locked when inverter is off",
                "Inverter transformer over temperature",
                "battery voltage is too high",
                "battery voltage is too low",
                "Output short circuited",
                "Inverter output voltage is high",
                "Overload time out",
                "Inverter bus voltage is too high",
                "Bus soft start failed",
                "Main relay failed",
                "Inverter output voltage sensor error",
                "Inverter grid voltage sensor error",
                "Inverter output current sensor error",
                "Inverter grid current sensor error",
                "Inverter load current sensor error",
                "Inverter grid over current error",
            }
        )]
        public System.Int16? Error1 { get; set; }

        [ModbusSensor(25262, 1.00d, true)]
        [SensorInterpretation("alert-circle-outline")]
        [SensorLookup(new string[]
            {
                "Inverter radiator over temperature",
                "Solar charger battery voltage class error",
                "Solar charger current sensor error",
                "Solar charger current is uncontrollable",
                "Inverter grid voltage is low",
                "Inverter grid voltage is high",
                "Inverter grid under frequency",
                "Inverter grid over frequency",
                "Inverter over current protection error",
                "Inverter bus voltage is too low",
                "Inverter soft start failed",
                "Over DC voltage in AC output",
                "Battery connection is open",
                "Inverter control current sensor error",
                "Inverter output voltage is too low",
                "",
            }
        )]
        public System.Int16? Error2 { get; set; }

        [ModbusSensor(25263, 1.00d, true)]
        [SensorInterpretation("alert-circle-outline")]
        public System.Int16? Error3 { get; set; }

        [ModbusSensor(25265, 1.00d, true)]
        [SensorInterpretation("alert-outline")]
        [SensorLookup(new string[]
            {
                "Fan is locked when inverter is on.",
                "Fan2 is locked when inverter is on.",
                "Battery is over-charged.",
                "Low battery",
                "Overload",
                "Output power derating",
                "Solar charger stops due to low battery.",
                "Solar charger stops due to high PV voltage.",
                "Solar charger stops due to over load.",
                "Solar charger over temperature",
                "PV charger communication error ",
                "",
                "",
                "",
                "",
                "",
            }
        )]
        public System.Int16? Warning1 { get; set; }

        [ModbusSensor(25266, 1.00d, true)]
        [SensorInterpretation("alert-outline")]
        public System.Int16? Warning2 { get; set; }

        [ModbusSensor(25273, 1.00d, true)]
        [SensorInterpretation("car-battery","W")]
        public System.Int16? BattPower { get; set; }

        [ModbusSensor(25274, 1.00d, true)]
        [SensorInterpretation("current-dc","Adc")]
        public System.Int16? BattCurrent { get; set; }

        [ModbusSensor(25275, 1.00d, true)]
        [SensorInterpretation("current-dc","Vdc-batt")]
        public System.Int16? BattVoltageGrade { get; set; }

        [ModbusSensor(25277, 1.00d, true)]
        [SensorInterpretation("certificate","W")]
        public System.Int16? RatedPowerW { get; set; }

        [ModbusSensor(25278, 1.00d, true)]
        [SensorInterpretation("barcode")]
        public System.Int16? CommunicationProtocalEdition { get; set; }

        [ModbusSensor(25279, 1.00d, true)]
        [SensorInterpretation("state-machine")]
        public System.Int16? ArrowFlag { get; set; }

        [ModbusSensor(10001, 1.00d, true)]
        public System.Int16? ChrMachineType { get; set; }

        [ModbusSensor(10002, 1.00d, true)]
        public System.Int16? ChrSerialNumberH { get; set; }

        [ModbusSensor(10003, 1.00d, true)]
        public System.Int16? ChrSerialNumberL { get; set; }

        [ModbusSensor(10004, 1.00d, true)]
        public System.Int16? ChrHardwareNo { get; set; }

        [ModbusSensor(10005, 1.00d, true)]
        public System.Int16? ChrSoftwareNo { get; set; }

        [ModbusSensor(10006, 1.00d, true)]
        public System.Int16? PvVoltageC { get; set; }

        [ModbusSensor(10007, 1.00d, true)]
        public System.Int16? ChrBatteryVoltageC { get; set; }

        [ModbusSensor(10008, 1.00d, true)]
        public System.Int16? ChargerCurrentC { get; set; }

        [ModbusSensor(10103, 0.10d, true)]
        [SensorRemarks(
@"
Floating charging voltage

12V model:
Default setting is 13.5V. Setting range is from 12.0V to 14.6V.

24V model:
Default setting is 27.0V. Setting range is from 24.0V to 29.2V.

If 'User-Defined' LI is selected in program (10110) 14, this program can be set up. Increment of each click is 0.1V.
"
        )]
        public System.Double? FloatVoltage { get; set; }

        [ModbusSensor(10104, 0.10d, true)]
        [SensorRemarks(
@"
Bulk charging voltage (C.V voltage)

12V model:
Default setting is 14.1V. Setting range is from 12.0V to 14.6V.

24V model:
Default setting is 28.2V. Setting range is from 24.0V to 29.2V.

If 'User-Defined' LI is selected in program (10110) 14, this program can be set up. Increment of each click is 0.1V.
"
        )]
        public System.Double? AbsorptionVoltage { get; set; }

        [ModbusSensor(10105, 0.10d, true)]
        public System.Double? ChrBatteryLowVoltage { get; set; }

        [ModbusSensor(10108, 0.10d, true)]
        public System.Double? MaxChargerCurrent { get; set; }

        [ModbusSensor(10110, 1.00d, true)]
        [SensorLookup(new string[]
            {
                "",
                "User defined battery",
                "Lithium battery ",
                "SEALED_LEAD  battery",
                "AGM  battery (default)",
                "GEL  battery",
                "FLOODED  battery",
            }
        )]
        [SensorRemarks(
@"
Battery type


f 'User-Defined' LI is selected, battery charge voltage and low DC cut-off voltage can be set up in program 10104 (17), 10103 (18) and 10105 (19).
"
        )]
        public System.Int16? BatteryType { get; set; }

        [ModbusSensor(10111, 1.00d, true)]
        public System.Int16? BatteryAh { get; set; }

        [ModbusSensor(15201, 1.00d, true)]
        [SensorInterpretation("state-machine")]
        [SensorLookup(new string[]
            {
                "Initialization mode ",
                "Selftest Mode",
                "Work Mode",
                "Stop Mode",
            }
        )]
        public System.Int16? ChrWorkstateNo { get; set; }

        [ModbusSensor(15202, 1.00d, true)]
        [SensorInterpretation("electric-switch")]
        [SensorLookup(new string[]
            {
                "Stop",
                "MPPT",
                "Current limiting",
            }
        )]
        public System.Int16? MpptStateNo { get; set; }

        [ModbusSensor(15203, 1.00d, true)]
        [SensorInterpretation("electric-switch")]
        [SensorLookup(new string[]
            {
                "Stop",
                "Absorb charge",
                "Float charge",
            }
        )]
        public System.Int16? ChargingStateNo { get; set; }

        [ModbusSensor(15205, 0.10d, true)]
        [SensorInterpretation("current-dc","Vdc-pv")]
        public System.Double? PvVoltage { get; set; }

        [ModbusSensor(15206, 0.10d, true)]
        [SensorInterpretation("current-dc","Vdc-batt")]
        public System.Double? ChrBatteryVoltage { get; set; }

        [ModbusSensor(15207, 0.10d, true)]
        [SensorInterpretation("current-dc","Adc")]
        public System.Double? ChargerCurrent { get; set; }

        [ModbusSensor(15208, 1.00d, true)]
        [SensorInterpretation("car-turbopower","W")]
        public System.Int16? ChargerPower { get; set; }

        [ModbusSensor(15209, 1.00d, true)]
        [SensorInterpretation("thermometer","oC")]
        public System.Int16? RadiatorTemp { get; set; }

        [ModbusSensor(15210, 1.00d, true)]
        [SensorInterpretation("thermometer","oC")]
        public System.Int16? ExternalTemp { get; set; }

        [ModbusSensor(15211, 1.00d, true)]
        [SensorInterpretation("electric-switch")]
        public System.Int16? BatteryRelayNo { get; set; }

        [ModbusSensor(15212, 1.00d, true)]
        [SensorInterpretation("electric-switch")]
        public System.Int16? PvRelayNo { get; set; }

        [ModbusSensor(15213, 1.00d, true)]
        [SensorInterpretation("alert-circle-outline")]
        [SensorLookup(new string[]
            {
                "Hardware protection",
                "Over current",
                "Current sensor error",
                "Over temperature",
                "PV voltage is too high",
                "",
                "Battery voltage is too high",
                "Battery voltage is too Low",
                "Current is uncontrollable",
                "Parameter error",
                "",
                "",
                "",
                "",
                "",
                "",
            }
        )]
        public System.Int16? ChrError1 { get; set; }

        [ModbusSensor(15214, 1.00d, true)]
        [SensorInterpretation("alert-outline")]
        [SensorLookup(new string[]
            {
                "Fan Error",
                "",
                "",
                "",
                "",
                "",
                "",
                "",
                "",
                "",
                "",
                "",
                "",
                "",
                "",
                "",
            }
        )]
        public System.Int16? ChrWarning1 { get; set; }

        [ModbusSensor(15215, 1.00d, true)]
        [SensorInterpretation("current-dc","Vdc-batt")]
        public System.Int16? BattVolGrade { get; set; }

        [ModbusSensor(15216, 0.10d, true)]
        [SensorInterpretation("current-dc","Adc")]
        public System.Double? RatedCurrent { get; set; }

        [ModbusSensor(15217, 1.00d, true)]
        [SensorInterpretation("chart-bell-curve-cumulative","W-High", false)]
        public System.Int16? AccumulatedPvPowerH { get; set; }

        [ModbusSensor(15218, 1.00d, true)]
        [SensorInterpretation("chart-bell-curve-cumulative","W-Low", false)]
        public System.Int16? AccumulatedPvPowerL { get; set; }

        [ModbusSensor(15219, 1.00d, true)]
        [SensorInterpretation("calendar-day","day")]
        public System.Int16? AccumulatedDay { get; set; }

        [ModbusSensor(15220, 1.00d, true)]
        [SensorInterpretation("clock-outline","hour")]
        public System.Int16? AccumulatedHour { get; set; }

        [ModbusSensor(15221, 1.00d, true)]
        [SensorInterpretation("timer-outline","min")]
        public System.Int16? AccumulatedMinute { get; set; }

    }
}