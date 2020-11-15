#!/bin/bash

pushMQTTData () {

    MQTT_SERVER=`cat /app/mqtt.json | jq '.server' -r`
    MQTT_PORT=`cat /app/mqtt.json | jq '.port' -r`
    MQTT_TOPIC=`cat /app/mqtt.json | jq '.topic' -r`
    MQTT_DEVICENAME=`cat /app/mqtt.json | jq '.devicename' -r`
    MQTT_USERNAME=`cat /app/mqtt.json | jq '.username' -r`
    MQTT_PASSWORD=`cat /app/mqtt.json | jq '.password' -r`

    mosquitto_pub \
        -h $MQTT_SERVER \
        -p $MQTT_PORT \
        -u "$MQTT_USERNAME" \
        -P "$MQTT_PASSWORD" \
        -t "$MQTT_TOPIC/sensor/"$MQTT_DEVICENAME"_$1" \
        -m "$2"
}

INVERTER_DATA=`timeout 10 dotnet inverter.dll poll -a=false`

#####################################################################################

WorkStateNo=`echo $INVERTER_DATA | jq '.WorkStateNo' -r`
[ ! -z "$WorkStateNo" ] && pushMQTTData "WorkStateNo" "$WorkStateNo"

AcVoltageGrade=`echo $INVERTER_DATA | jq '.AcVoltageGrade' -r`
[ ! -z "$AcVoltageGrade" ] && pushMQTTData "AcVoltageGrade" "$AcVoltageGrade"

RatedPower=`echo $INVERTER_DATA | jq '.RatedPower' -r`
[ ! -z "$RatedPower" ] && pushMQTTData "RatedPower" "$RatedPower"

BatteryVoltage=`echo $INVERTER_DATA | jq '.BatteryVoltage' -r`
[ ! -z "$BatteryVoltage" ] && pushMQTTData "BatteryVoltage" "$BatteryVoltage"

InverterVoltage=`echo $INVERTER_DATA | jq '.InverterVoltage' -r`
[ ! -z "$InverterVoltage" ] && pushMQTTData "InverterVoltage" "$InverterVoltage"

GridVoltage=`echo $INVERTER_DATA | jq '.GridVoltage' -r`
[ ! -z "$GridVoltage" ] && pushMQTTData "GridVoltage" "$GridVoltage"

BusVoltage=`echo $INVERTER_DATA | jq '.BusVoltage' -r`
[ ! -z "$BusVoltage" ] && pushMQTTData "BusVoltage" "$BusVoltage"

ControlCurrent=`echo $INVERTER_DATA | jq '.ControlCurrent' -r`
[ ! -z "$ControlCurrent" ] && pushMQTTData "ControlCurrent" "$ControlCurrent"

InverterCurrent=`echo $INVERTER_DATA | jq '.InverterCurrent' -r`
[ ! -z "$InverterCurrent" ] && pushMQTTData "InverterCurrent" "$InverterCurrent"

GridCurrent=`echo $INVERTER_DATA | jq '.GridCurrent' -r`
[ ! -z "$GridCurrent" ] && pushMQTTData "GridCurrent" "$GridCurrent"

LoadCurrent=`echo $INVERTER_DATA | jq '.LoadCurrent' -r`
[ ! -z "$LoadCurrent" ] && pushMQTTData "LoadCurrent" "$LoadCurrent"

PInverter=`echo $INVERTER_DATA | jq '.PInverter' -r`
[ ! -z "$PInverter" ] && pushMQTTData "PInverter" "$PInverter"

PGrid=`echo $INVERTER_DATA | jq '.PGrid' -r`
[ ! -z "$PGrid" ] && pushMQTTData "PGrid" "$PGrid"

PLoad=`echo $INVERTER_DATA | jq '.PLoad' -r`
[ ! -z "$PLoad" ] && pushMQTTData "PLoad" "$PLoad"

LoadPercent=`echo $INVERTER_DATA | jq '.LoadPercent' -r`
[ ! -z "$LoadPercent" ] && pushMQTTData "LoadPercent" "$LoadPercent"

SInverter=`echo $INVERTER_DATA | jq '.SInverter' -r`
[ ! -z "$SInverter" ] && pushMQTTData "SInverter" "$SInverter"

SGrid=`echo $INVERTER_DATA | jq '.SGrid' -r`
[ ! -z "$SGrid" ] && pushMQTTData "SGrid" "$SGrid"

SLoad=`echo $INVERTER_DATA | jq '.SLoad' -r`
[ ! -z "$SLoad" ] && pushMQTTData "SLoad" "$SLoad"

QInverter=`echo $INVERTER_DATA | jq '.QInverter' -r`
[ ! -z "$QInverter" ] && pushMQTTData "QInverter" "$QInverter"

QGrid=`echo $INVERTER_DATA | jq '.QGrid' -r`
[ ! -z "$QGrid" ] && pushMQTTData "QGrid" "$QGrid"

QLoad=`echo $INVERTER_DATA | jq '.QLoad' -r`
[ ! -z "$QLoad" ] && pushMQTTData "QLoad" "$QLoad"

InverterFrequency=`echo $INVERTER_DATA | jq '.InverterFrequency' -r`
[ ! -z "$InverterFrequency" ] && pushMQTTData "InverterFrequency" "$InverterFrequency"

GridFrequency=`echo $INVERTER_DATA | jq '.GridFrequency' -r`
[ ! -z "$GridFrequency" ] && pushMQTTData "GridFrequency" "$GridFrequency"

InverterMaxNumber=`echo $INVERTER_DATA | jq '.InverterMaxNumber' -r`
[ ! -z "$InverterMaxNumber" ] && pushMQTTData "InverterMaxNumber" "$InverterMaxNumber"

CombineType=`echo $INVERTER_DATA | jq '.CombineType' -r`
[ ! -z "$CombineType" ] && pushMQTTData "CombineType" "$CombineType"

InverterNumber=`echo $INVERTER_DATA | jq '.InverterNumber' -r`
[ ! -z "$InverterNumber" ] && pushMQTTData "InverterNumber" "$InverterNumber"

AcRadiatorTemp=`echo $INVERTER_DATA | jq '.AcRadiatorTemp' -r`
[ ! -z "$AcRadiatorTemp" ] && pushMQTTData "AcRadiatorTemp" "$AcRadiatorTemp"

TransformerTemp=`echo $INVERTER_DATA | jq '.TransformerTemp' -r`
[ ! -z "$TransformerTemp" ] && pushMQTTData "TransformerTemp" "$TransformerTemp"

DcRadiatorTemp=`echo $INVERTER_DATA | jq '.DcRadiatorTemp' -r`
[ ! -z "$DcRadiatorTemp" ] && pushMQTTData "DcRadiatorTemp" "$DcRadiatorTemp"

InverterRelayStateNo=`echo $INVERTER_DATA | jq '.InverterRelayStateNo' -r`
[ ! -z "$InverterRelayStateNo" ] && pushMQTTData "InverterRelayStateNo" "$InverterRelayStateNo"

GridRelayStateNo=`echo $INVERTER_DATA | jq '.GridRelayStateNo' -r`
[ ! -z "$GridRelayStateNo" ] && pushMQTTData "GridRelayStateNo" "$GridRelayStateNo"

LoadRelayStateNo=`echo $INVERTER_DATA | jq '.LoadRelayStateNo' -r`
[ ! -z "$LoadRelayStateNo" ] && pushMQTTData "LoadRelayStateNo" "$LoadRelayStateNo"

NLineRelayStateNo=`echo $INVERTER_DATA | jq '.NLineRelayStateNo' -r`
[ ! -z "$NLineRelayStateNo" ] && pushMQTTData "NLineRelayStateNo" "$NLineRelayStateNo"

DcRelayStateNo=`echo $INVERTER_DATA | jq '.DcRelayStateNo' -r`
[ ! -z "$DcRelayStateNo" ] && pushMQTTData "DcRelayStateNo" "$DcRelayStateNo"

EarthRelayStateNo=`echo $INVERTER_DATA | jq '.EarthRelayStateNo' -r`
[ ! -z "$EarthRelayStateNo" ] && pushMQTTData "EarthRelayStateNo" "$EarthRelayStateNo"

Error1=`echo $INVERTER_DATA | jq '.Error1' -r`
[ ! -z "$Error1" ] && pushMQTTData "Error1" "$Error1"

Error2=`echo $INVERTER_DATA | jq '.Error2' -r`
[ ! -z "$Error2" ] && pushMQTTData "Error2" "$Error2"

Error3=`echo $INVERTER_DATA | jq '.Error3' -r`
[ ! -z "$Error3" ] && pushMQTTData "Error3" "$Error3"

Warning1=`echo $INVERTER_DATA | jq '.Warning1' -r`
[ ! -z "$Warning1" ] && pushMQTTData "Warning1" "$Warning1"

Warning2=`echo $INVERTER_DATA | jq '.Warning2' -r`
[ ! -z "$Warning2" ] && pushMQTTData "Warning2" "$Warning2"

BattPower=`echo $INVERTER_DATA | jq '.BattPower' -r`
[ ! -z "$BattPower" ] && pushMQTTData "BattPower" "$BattPower"

BattCurrent=`echo $INVERTER_DATA | jq '.BattCurrent' -r`
[ ! -z "$BattCurrent" ] && pushMQTTData "BattCurrent" "$BattCurrent"

BattVoltageGrade=`echo $INVERTER_DATA | jq '.BattVoltageGrade' -r`
[ ! -z "$BattVoltageGrade" ] && pushMQTTData "BattVoltageGrade" "$BattVoltageGrade"

RatedPowerW=`echo $INVERTER_DATA | jq '.RatedPowerW' -r`
[ ! -z "$RatedPowerW" ] && pushMQTTData "RatedPowerW" "$RatedPowerW"

CommunicationProtocalEdition=`echo $INVERTER_DATA | jq '.CommunicationProtocalEdition' -r`
[ ! -z "$CommunicationProtocalEdition" ] && pushMQTTData "CommunicationProtocalEdition" "$CommunicationProtocalEdition"

ArrowFlag=`echo $INVERTER_DATA | jq '.ArrowFlag' -r`
[ ! -z "$ArrowFlag" ] && pushMQTTData "ArrowFlag" "$ArrowFlag"

ChrWorkstateNo=`echo $INVERTER_DATA | jq '.ChrWorkstateNo' -r`
[ ! -z "$ChrWorkstateNo" ] && pushMQTTData "ChrWorkstateNo" "$ChrWorkstateNo"

MpptStateNo=`echo $INVERTER_DATA | jq '.MpptStateNo' -r`
[ ! -z "$MpptStateNo" ] && pushMQTTData "MpptStateNo" "$MpptStateNo"

ChargingStateNo=`echo $INVERTER_DATA | jq '.ChargingStateNo' -r`
[ ! -z "$ChargingStateNo" ] && pushMQTTData "ChargingStateNo" "$ChargingStateNo"

PvVoltage=`echo $INVERTER_DATA | jq '.PvVoltage' -r`
[ ! -z "$PvVoltage" ] && pushMQTTData "PvVoltage" "$PvVoltage"

ChrBatteryVoltage=`echo $INVERTER_DATA | jq '.ChrBatteryVoltage' -r`
[ ! -z "$ChrBatteryVoltage" ] && pushMQTTData "ChrBatteryVoltage" "$ChrBatteryVoltage"

ChargerCurrent=`echo $INVERTER_DATA | jq '.ChargerCurrent' -r`
[ ! -z "$ChargerCurrent" ] && pushMQTTData "ChargerCurrent" "$ChargerCurrent"

ChargerPower=`echo $INVERTER_DATA | jq '.ChargerPower' -r`
[ ! -z "$ChargerPower" ] && pushMQTTData "ChargerPower" "$ChargerPower"

RadiatorTemp=`echo $INVERTER_DATA | jq '.RadiatorTemp' -r`
[ ! -z "$RadiatorTemp" ] && pushMQTTData "RadiatorTemp" "$RadiatorTemp"

ExternalTemp=`echo $INVERTER_DATA | jq '.ExternalTemp' -r`
[ ! -z "$ExternalTemp" ] && pushMQTTData "ExternalTemp" "$ExternalTemp"

BatteryRelayNo=`echo $INVERTER_DATA | jq '.BatteryRelayNo' -r`
[ ! -z "$BatteryRelayNo" ] && pushMQTTData "BatteryRelayNo" "$BatteryRelayNo"

PvRelayNo=`echo $INVERTER_DATA | jq '.PvRelayNo' -r`
[ ! -z "$PvRelayNo" ] && pushMQTTData "PvRelayNo" "$PvRelayNo"

ChrError1=`echo $INVERTER_DATA | jq '.ChrError1' -r`
[ ! -z "$ChrError1" ] && pushMQTTData "ChrError1" "$ChrError1"

ChrWarning1=`echo $INVERTER_DATA | jq '.ChrWarning1' -r`
[ ! -z "$ChrWarning1" ] && pushMQTTData "ChrWarning1" "$ChrWarning1"

BattVolGrade=`echo $INVERTER_DATA | jq '.BattVolGrade' -r`
[ ! -z "$BattVolGrade" ] && pushMQTTData "BattVolGrade" "$BattVolGrade"

RatedCurrent=`echo $INVERTER_DATA | jq '.RatedCurrent' -r`
[ ! -z "$RatedCurrent" ] && pushMQTTData "RatedCurrent" "$RatedCurrent"

AccumulatedDay=`echo $INVERTER_DATA | jq '.AccumulatedDay' -r`
[ ! -z "$AccumulatedDay" ] && pushMQTTData "AccumulatedDay" "$AccumulatedDay"

AccumulatedHour=`echo $INVERTER_DATA | jq '.AccumulatedHour' -r`
[ ! -z "$AccumulatedHour" ] && pushMQTTData "AccumulatedHour" "$AccumulatedHour"

AccumulatedMinute=`echo $INVERTER_DATA | jq '.AccumulatedMinute' -r`
[ ! -z "$AccumulatedMinute" ] && pushMQTTData "AccumulatedMinute" "$AccumulatedMinute"



# Composite

AccumulatedChargerPower=`echo $INVERTER_DATA | jq '.AccumulatedChargerPower' -r`
[ ! -z "$AccumulatedChargerPower" ] && pushMQTTData "AccumulatedChargerPower" "$AccumulatedChargerPower"

AccumulatedDischargerPower=`echo $INVERTER_DATA | jq '.AccumulatedDischargerPower' -r`
[ ! -z "$AccumulatedDischargerPower" ] && pushMQTTData "AccumulatedDischargerPower" "$AccumulatedDischargerPower"

AccumulatedBuyPower=`echo $INVERTER_DATA | jq '.AccumulatedBuyPower' -r`
[ ! -z "$AccumulatedBuyPower" ] && pushMQTTData "AccumulatedBuyPower" "$AccumulatedBuyPower"

AccumulatedSellPower=`echo $INVERTER_DATA | jq '.AccumulatedSellPower' -r`
[ ! -z "$AccumulatedSellPower" ] && pushMQTTData "AccumulatedSellPower" "$AccumulatedSellPower"

AccumulatedLoadPower=`echo $INVERTER_DATA | jq '.AccumulatedLoadPower' -r`
[ ! -z "$AccumulatedLoadPower" ] && pushMQTTData "AccumulatedLoadPower" "$AccumulatedLoadPower"

AccumulatedSelfusePower=`echo $INVERTER_DATA | jq '.AccumulatedSelfusePower' -r`
[ ! -z "$AccumulatedSelfusePower" ] && pushMQTTData "AccumulatedSelfusePower" "$AccumulatedSelfusePower"

AccumulatedPvsellPower=`echo $INVERTER_DATA | jq '.AccumulatedPvsellPower' -r`
[ ! -z "$AccumulatedPvsellPower" ] && pushMQTTData "AccumulatedPvsellPower" "$AccumulatedPvsellPower"

AccumulatedGridChargerPower=`echo $INVERTER_DATA | jq '.AccumulatedGridChargerPower' -r`
[ ! -z "AccumulatedGridChargerPower" ] && pushMQTTData "AccumulatedGridChargerPower" "$AccumulatedGridChargerPower"

AccumulatedPvPower=`echo $INVERTER_DATA | jq '.AccumulatedPvPower' -r`
[ ! -z "AccumulatedPvPower" ] && pushMQTTData "AccumulatedPvPower" "$AccumulatedPvPower"
