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
[ ! -z "$WorkStateNo" ] && pushMQTTData "$WorkStateNo"

AcVoltageGrade=`echo $INVERTER_DATA | jq '.AcVoltageGrade' -r`
[ ! -z "$AcVoltageGrade" ] && pushMQTTData "$AcVoltageGrade"

RatedPower=`echo $INVERTER_DATA | jq '.RatedPower' -r`
[ ! -z "$RatedPower" ] && pushMQTTData "$RatedPower"

BatteryVoltage=`echo $INVERTER_DATA | jq '.BatteryVoltage' -r`
[ ! -z "$BatteryVoltage" ] && pushMQTTData "$BatteryVoltage"

InverterVoltage=`echo $INVERTER_DATA | jq '.InverterVoltage' -r`
[ ! -z "$InverterVoltage" ] && pushMQTTData "$InverterVoltage"

GridVoltage=`echo $INVERTER_DATA | jq '.GridVoltage' -r`
[ ! -z "$GridVoltage" ] && pushMQTTData "$GridVoltage"

BusVoltage=`echo $INVERTER_DATA | jq '.BusVoltage' -r`
[ ! -z "$BusVoltage" ] && pushMQTTData "$BusVoltage"

ControlCurrent=`echo $INVERTER_DATA | jq '.ControlCurrent' -r`
[ ! -z "$ControlCurrent" ] && pushMQTTData "$ControlCurrent"

InverterCurrent=`echo $INVERTER_DATA | jq '.InverterCurrent' -r`
[ ! -z "$InverterCurrent" ] && pushMQTTData "$InverterCurrent"

GridCurrent=`echo $INVERTER_DATA | jq '.GridCurrent' -r`
[ ! -z "$GridCurrent" ] && pushMQTTData "$GridCurrent"

LoadCurrent=`echo $INVERTER_DATA | jq '.LoadCurrent' -r`
[ ! -z "$LoadCurrent" ] && pushMQTTData "$LoadCurrent"

PInverter=`echo $INVERTER_DATA | jq '.PInverter' -r`
[ ! -z "$PInverter" ] && pushMQTTData "$PInverter"

PGrid=`echo $INVERTER_DATA | jq '.PGrid' -r`
[ ! -z "$PGrid" ] && pushMQTTData "$PGrid"

PLoad=`echo $INVERTER_DATA | jq '.PLoad' -r`
[ ! -z "$PLoad" ] && pushMQTTData "$PLoad"

LoadPercent=`echo $INVERTER_DATA | jq '.LoadPercent' -r`
[ ! -z "$LoadPercent" ] && pushMQTTData "$LoadPercent"

SInverter=`echo $INVERTER_DATA | jq '.SInverter' -r`
[ ! -z "$SInverter" ] && pushMQTTData "$SInverter"

SGrid=`echo $INVERTER_DATA | jq '.SGrid' -r`
[ ! -z "$SGrid" ] && pushMQTTData "$SGrid"

SLoad=`echo $INVERTER_DATA | jq '.SLoad' -r`
[ ! -z "$SLoad" ] && pushMQTTData "$SLoad"

QInverter=`echo $INVERTER_DATA | jq '.QInverter' -r`
[ ! -z "$QInverter" ] && pushMQTTData "$QInverter"

QGrid=`echo $INVERTER_DATA | jq '.QGrid' -r`
[ ! -z "$QGrid" ] && pushMQTTData "$QGrid"

QLoad=`echo $INVERTER_DATA | jq '.QLoad' -r`
[ ! -z "$QLoad" ] && pushMQTTData "$QLoad"

InverterFrequency=`echo $INVERTER_DATA | jq '.InverterFrequency' -r`
[ ! -z "$InverterFrequency" ] && pushMQTTData "$InverterFrequency"

GridFrequency=`echo $INVERTER_DATA | jq '.GridFrequency' -r`
[ ! -z "$GridFrequency" ] && pushMQTTData "$GridFrequency"

InverterMaxNumber=`echo $INVERTER_DATA | jq '.InverterMaxNumber' -r`
[ ! -z "$InverterMaxNumber" ] && pushMQTTData "$InverterMaxNumber"

CombineType=`echo $INVERTER_DATA | jq '.CombineType' -r`
[ ! -z "$CombineType" ] && pushMQTTData "$CombineType"

InverterNumber=`echo $INVERTER_DATA | jq '.InverterNumber' -r`
[ ! -z "$InverterNumber" ] && pushMQTTData "$InverterNumber"

AcRadiatorTemp=`echo $INVERTER_DATA | jq '.AcRadiatorTemp' -r`
[ ! -z "$AcRadiatorTemp" ] && pushMQTTData "$AcRadiatorTemp"

TransformerTemp=`echo $INVERTER_DATA | jq '.TransformerTemp' -r`
[ ! -z "$TransformerTemp" ] && pushMQTTData "$TransformerTemp"

DcRadiatorTemp=`echo $INVERTER_DATA | jq '.DcRadiatorTemp' -r`
[ ! -z "$DcRadiatorTemp" ] && pushMQTTData "$DcRadiatorTemp"

InverterRelayStateNo=`echo $INVERTER_DATA | jq '.InverterRelayStateNo' -r`
[ ! -z "$InverterRelayStateNo" ] && pushMQTTData "$InverterRelayStateNo"

GridRelayStateNo=`echo $INVERTER_DATA | jq '.GridRelayStateNo' -r`
[ ! -z "$GridRelayStateNo" ] && pushMQTTData "$GridRelayStateNo"

LoadRelayStateNo=`echo $INVERTER_DATA | jq '.LoadRelayStateNo' -r`
[ ! -z "$LoadRelayStateNo" ] && pushMQTTData "$LoadRelayStateNo"

NLineRelayStateNo=`echo $INVERTER_DATA | jq '.NLineRelayStateNo' -r`
[ ! -z "$NLineRelayStateNo" ] && pushMQTTData "$NLineRelayStateNo"

DcRelayStateNo=`echo $INVERTER_DATA | jq '.DcRelayStateNo' -r`
[ ! -z "$DcRelayStateNo" ] && pushMQTTData "$DcRelayStateNo"

EarthRelayStateNo=`echo $INVERTER_DATA | jq '.EarthRelayStateNo' -r`
[ ! -z "$EarthRelayStateNo" ] && pushMQTTData "$EarthRelayStateNo"

AccumulatedChargerPowerH=`echo $INVERTER_DATA | jq '.AccumulatedChargerPowerH' -r`
[ ! -z "$AccumulatedChargerPowerH" ] && pushMQTTData "$AccumulatedChargerPowerH"

AccumulatedChargerPowerL=`echo $INVERTER_DATA | jq '.AccumulatedChargerPowerL' -r`
[ ! -z "$AccumulatedChargerPowerL" ] && pushMQTTData "$AccumulatedChargerPowerL"

AccumulatedDischargerPowerH=`echo $INVERTER_DATA | jq '.AccumulatedDischargerPowerH' -r`
[ ! -z "$AccumulatedDischargerPowerH" ] && pushMQTTData "$AccumulatedDischargerPowerH"

AccumulatedDischargerPowerL=`echo $INVERTER_DATA | jq '.AccumulatedDischargerPowerL' -r`
[ ! -z "$AccumulatedDischargerPowerL" ] && pushMQTTData "$AccumulatedDischargerPowerL"

AccumulatedBuyPowerH=`echo $INVERTER_DATA | jq '.AccumulatedBuyPowerH' -r`
[ ! -z "$AccumulatedBuyPowerH" ] && pushMQTTData "$AccumulatedBuyPowerH"

AccumulatedBuyPowerL=`echo $INVERTER_DATA | jq '.AccumulatedBuyPowerL' -r`
[ ! -z "$AccumulatedBuyPowerL" ] && pushMQTTData "$AccumulatedBuyPowerL"

AccumulatedSellPowerH=`echo $INVERTER_DATA | jq '.AccumulatedSellPowerH' -r`
[ ! -z "$AccumulatedSellPowerH" ] && pushMQTTData "$AccumulatedSellPowerH"

AccumulatedSellPowerL=`echo $INVERTER_DATA | jq '.AccumulatedSellPowerL' -r`
[ ! -z "$AccumulatedSellPowerL" ] && pushMQTTData "$AccumulatedSellPowerL"

AccumulatedLoadPowerH=`echo $INVERTER_DATA | jq '.AccumulatedLoadPowerH' -r`
[ ! -z "$AccumulatedLoadPowerH" ] && pushMQTTData "$AccumulatedLoadPowerH"

AccumulatedLoadPowerL=`echo $INVERTER_DATA | jq '.AccumulatedLoadPowerL' -r`
[ ! -z "$AccumulatedLoadPowerL" ] && pushMQTTData "$AccumulatedLoadPowerL"

AccumulatedSelfusePowerH=`echo $INVERTER_DATA | jq '.AccumulatedSelfusePowerH' -r`
[ ! -z "$AccumulatedSelfusePowerH" ] && pushMQTTData "$AccumulatedSelfusePowerH"

AccumulatedSelfusePowerL=`echo $INVERTER_DATA | jq '.AccumulatedSelfusePowerL' -r`
[ ! -z "$AccumulatedSelfusePowerL" ] && pushMQTTData "$AccumulatedSelfusePowerL"

AccumulatedPvsellPowerH=`echo $INVERTER_DATA | jq '.AccumulatedPvsellPowerH' -r`
[ ! -z "$AccumulatedPvsellPowerH" ] && pushMQTTData "$AccumulatedPvsellPowerH"

AccumulatedPvsellPowerL=`echo $INVERTER_DATA | jq '.AccumulatedPvsellPowerL' -r`
[ ! -z "$AccumulatedPvsellPowerL" ] && pushMQTTData "$AccumulatedPvsellPowerL"

AccumulatedGridChargerPowerH=`echo $INVERTER_DATA | jq '.AccumulatedGridChargerPowerH' -r`
[ ! -z "$AccumulatedGridChargerPowerH" ] && pushMQTTData "$AccumulatedGridChargerPowerH"

AccumulatedGridChargerPowerL=`echo $INVERTER_DATA | jq '.AccumulatedGridChargerPowerL' -r`
[ ! -z "$AccumulatedGridChargerPowerL" ] && pushMQTTData "$AccumulatedGridChargerPowerL"

Error1=`echo $INVERTER_DATA | jq '.Error1' -r`
[ ! -z "$Error1" ] && pushMQTTData "$Error1"

Error2=`echo $INVERTER_DATA | jq '.Error2' -r`
[ ! -z "$Error2" ] && pushMQTTData "$Error2"

Error3=`echo $INVERTER_DATA | jq '.Error3' -r`
[ ! -z "$Error3" ] && pushMQTTData "$Error3"

Warning1=`echo $INVERTER_DATA | jq '.Warning1' -r`
[ ! -z "$Warning1" ] && pushMQTTData "$Warning1"

Warning2=`echo $INVERTER_DATA | jq '.Warning2' -r`
[ ! -z "$Warning2" ] && pushMQTTData "$Warning2"

BattPower=`echo $INVERTER_DATA | jq '.BattPower' -r`
[ ! -z "$BattPower" ] && pushMQTTData "$BattPower"

BattCurrent=`echo $INVERTER_DATA | jq '.BattCurrent' -r`
[ ! -z "$BattCurrent" ] && pushMQTTData "$BattCurrent"

BattVoltageGrade=`echo $INVERTER_DATA | jq '.BattVoltageGrade' -r`
[ ! -z "$BattVoltageGrade" ] && pushMQTTData "$BattVoltageGrade"

RatedPowerW=`echo $INVERTER_DATA | jq '.RatedPowerW' -r`
[ ! -z "$RatedPowerW" ] && pushMQTTData "$RatedPowerW"

CommunicationProtocalEdition=`echo $INVERTER_DATA | jq '.CommunicationProtocalEdition' -r`
[ ! -z "$CommunicationProtocalEdition" ] && pushMQTTData "$CommunicationProtocalEdition"

ArrowFlag=`echo $INVERTER_DATA | jq '.ArrowFlag' -r`
[ ! -z "$ArrowFlag" ] && pushMQTTData "$ArrowFlag"

ChrWorkstateNo=`echo $INVERTER_DATA | jq '.ChrWorkstateNo' -r`
[ ! -z "$ChrWorkstateNo" ] && pushMQTTData "$ChrWorkstateNo"

MpptStateNo=`echo $INVERTER_DATA | jq '.MpptStateNo' -r`
[ ! -z "$MpptStateNo" ] && pushMQTTData "$MpptStateNo"

ChargingStateNo=`echo $INVERTER_DATA | jq '.ChargingStateNo' -r`
[ ! -z "$ChargingStateNo" ] && pushMQTTData "$ChargingStateNo"

PvVoltage=`echo $INVERTER_DATA | jq '.PvVoltage' -r`
[ ! -z "$PvVoltage" ] && pushMQTTData "$PvVoltage"

ChrBatteryVoltage=`echo $INVERTER_DATA | jq '.ChrBatteryVoltage' -r`
[ ! -z "$ChrBatteryVoltage" ] && pushMQTTData "$ChrBatteryVoltage"

ChargerCurrent=`echo $INVERTER_DATA | jq '.ChargerCurrent' -r`
[ ! -z "$ChargerCurrent" ] && pushMQTTData "$ChargerCurrent"

ChargerPower=`echo $INVERTER_DATA | jq '.ChargerPower' -r`
[ ! -z "$ChargerPower" ] && pushMQTTData "$ChargerPower"

RadiatorTemp=`echo $INVERTER_DATA | jq '.RadiatorTemp' -r`
[ ! -z "$RadiatorTemp" ] && pushMQTTData "$RadiatorTemp"

ExternalTemp=`echo $INVERTER_DATA | jq '.ExternalTemp' -r`
[ ! -z "$ExternalTemp" ] && pushMQTTData "$ExternalTemp"

BatteryRelayNo=`echo $INVERTER_DATA | jq '.BatteryRelayNo' -r`
[ ! -z "$BatteryRelayNo" ] && pushMQTTData "$BatteryRelayNo"

PvRelayNo=`echo $INVERTER_DATA | jq '.PvRelayNo' -r`
[ ! -z "$PvRelayNo" ] && pushMQTTData "$PvRelayNo"

ChrError1=`echo $INVERTER_DATA | jq '.ChrError1' -r`
[ ! -z "$ChrError1" ] && pushMQTTData "$ChrError1"

ChrWarning1=`echo $INVERTER_DATA | jq '.ChrWarning1' -r`
[ ! -z "$ChrWarning1" ] && pushMQTTData "$ChrWarning1"

BattVolGrade=`echo $INVERTER_DATA | jq '.BattVolGrade' -r`
[ ! -z "$BattVolGrade" ] && pushMQTTData "$BattVolGrade"

RatedCurrent=`echo $INVERTER_DATA | jq '.RatedCurrent' -r`
[ ! -z "$RatedCurrent" ] && pushMQTTData "$RatedCurrent"

AccumulatedPvPowerH=`echo $INVERTER_DATA | jq '.AccumulatedPvPowerH' -r`
[ ! -z "$AccumulatedPvPowerH" ] && pushMQTTData "$AccumulatedPvPowerH"

AccumulatedPvPowerL=`echo $INVERTER_DATA | jq '.AccumulatedPvPowerL' -r`
[ ! -z "$AccumulatedPvPowerL" ] && pushMQTTData "$AccumulatedPvPowerL"

AccumulatedDay=`echo $INVERTER_DATA | jq '.AccumulatedDay' -r`
[ ! -z "$AccumulatedDay" ] && pushMQTTData "$AccumulatedDay"

AccumulatedHour=`echo $INVERTER_DATA | jq '.AccumulatedHour' -r`
[ ! -z "$AccumulatedHour" ] && pushMQTTData "$AccumulatedHour"

AccumulatedMinute=`echo $INVERTER_DATA | jq '.AccumulatedMinute' -r`
[ ! -z "$AccumulatedMinute" ] && pushMQTTData "$AccumulatedMinute"


