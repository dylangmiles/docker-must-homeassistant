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

# 0 = Power_On, 1 = SelfTest, 2 = OffGrid, 3 = Grid-Tie, 4 = ByPass, 5 = Stop, 6 = GridCharging
workStateNo=`echo $INVERTER_DATA | jq '.workStateNo' -r`
[ ! -z "$workStateNo" ] && pushMQTTData "workStateNo" "$workStateNo"

acVoltageGrade=`echo $INVERTER_DATA | jq '.acVoltageGrade' -r`
[ ! -z "$acVoltageGrade" ] && pushMQTTData "acVoltageGrade" "$acVoltageGrade"

ratedPower=`echo $INVERTER_DATA | jq '.ratedPower' -r`
[ ! -z "$ratedPower" ] && pushMQTTData "ratedPower" "$ratedPower"

batteryVoltage=`echo $INVERTER_DATA | jq '.batteryVoltage' -r`
[ ! -z "$batteryVoltage" ] && pushMQTTData "batteryVoltage" "$batteryVoltage"

inverterVoltage=`echo $INVERTER_DATA | jq '.inverterVoltage' -r`
[ ! -z "$inverterVoltage" ] && pushMQTTData "inverterVoltage" "$inverterVoltage"

gridVoltage=`echo $INVERTER_DATA | jq '.gridVoltage' -r`
[ ! -z "$gridVoltage" ] && pushMQTTData "gridVoltage" "$gridVoltage"

busVoltage=`echo $INVERTER_DATA | jq '.busVoltage' -r`
[ ! -z "$busVoltage" ] && pushMQTTData "busVoltage" "$busVoltage"

controlCurrent=`echo $INVERTER_DATA | jq '.controlCurrent' -r`
[ ! -z "$controlCurrent" ] && pushMQTTData "controlCurrent" "$controlCurrent"

inverterCurrent=`echo $INVERTER_DATA | jq '.inverterCurrent' -r`
[ ! -z "$inverterCurrent" ] && pushMQTTData "inverterCurrent" "$inverterCurrent"

gridCurrent=`echo $INVERTER_DATA | jq '.gridCurrent' -r`
[ ! -z "$gridCurrent" ] && pushMQTTData "gridCurrent" "$gridCurrent"

loadCurrent=`echo $INVERTER_DATA | jq '.loadCurrent' -r`
[ ! -z "$loadCurrent" ] && pushMQTTData "loadCurrent" "$loadCurrent"

pInverter=`echo $INVERTER_DATA | jq '.pInverter' -r`
[ ! -z "$pInverter" ] && pushMQTTData "pInverter" "$pInverter"

gridCurrent=`echo $INVERTER_DATA | jq '.gridCurrent' -r`
[ ! -z "$gridCurrent" ] && pushMQTTData "gridCurrent" "$gridCurrent"

loadCurrent=`echo $INVERTER_DATA | jq '.loadCurrent' -r`
[ ! -z "$loadCurrent" ] && pushMQTTData "loadCurrent" "$loadCurrent"

pInverter=`echo $INVERTER_DATA | jq '.pInverter' -r`
[ ! -z "$pInverter" ] && pushMQTTData "pInverter" "$pInverter"

pGrid=`echo $INVERTER_DATA | jq '.pGrid' -r`
[ ! -z "$pGrid" ] && pushMQTTData "pGrid" "$pGrid"

pLoad=`echo $INVERTER_DATA | jq '.pLoad' -r`
[ ! -z "$pLoad" ] && pushMQTTData "pLoad" "$pLoad"

loadPercent=`echo $INVERTER_DATA | jq '.loadPercent' -r`
[ ! -z "$loadPercent" ] && pushMQTTData "pLoad" "$loadPercent"

sInverter=`echo $INVERTER_DATA | jq '.sInverter' -r`
[ ! -z "$sInverter" ] && pushMQTTData "sInverter" "$sInverter"

sGrid=`echo $INVERTER_DATA | jq '.sGrid' -r`
[ ! -z "$sGrid" ] && pushMQTTData "sGrid" "$sGrid"

sLoad=`echo $INVERTER_DATA | jq '.sLoad' -r`
[ ! -z "$sLoad" ] && pushMQTTData "sLoad" "$sLoad"

qInverter=`echo $INVERTER_DATA | jq '.qInverter' -r`
[ ! -z "$qInverter" ] && pushMQTTData "qInverter" "$qInverter"

qGrid=`echo $INVERTER_DATA | jq '.qGrid' -r`
[ ! -z "$qGrid" ] && pushMQTTData "qGrid" "$qGrid"

qLoad=`echo $INVERTER_DATA | jq '.qLoad' -r`
[ ! -z "$qLoad" ] && pushMQTTData "qLoad" "$qLoad"

inverterFrequency=`echo $INVERTER_DATA | jq '.inverterFrequency' -r`
[ ! -z "$inverterFrequency" ] && pushMQTTData "inverterFrequency" "$inverterFrequency"

gridFrequency=`echo $INVERTER_DATA | jq '.gridFrequency' -r`
[ ! -z "$gridFrequency" ] && pushMQTTData "gridFrequency" "$gridFrequency"

inverterMaxNumber=`echo $INVERTER_DATA | jq '.inverterMaxNumber' -r`
[ ! -z "$inverterMaxNumber" ] && pushMQTTData "inverterMaxNumber" "$inverterMaxNumber"

combineType=`echo $INVERTER_DATA | jq '.combineType' -r`
[ ! -z "$combineType" ] && pushMQTTData "combineType" "$combineType"

inverterNumber=`echo $INVERTER_DATA | jq '.inverterNumber' -r`
[ ! -z "$inverterNumber" ] && pushMQTTData "inverterNumber" "$inverterNumber"

acRadiatorTemp=`echo $INVERTER_DATA | jq '.acRadiatorTemp' -r`
[ ! -z "$acRadiatorTemp" ] && pushMQTTData "acRadiatorTemp" "$acRadiatorTemp"

transformerTemp=`echo $INVERTER_DATA | jq '.transformerTemp' -r`
[ ! -z "$transformerTemp" ] && pushMQTTData "transformerTemp" "$transformerTemp"

dcRadiatorTemp=`echo $INVERTER_DATA | jq '.dcRadiatorTemp' -r`
[ ! -z "$dcRadiatorTemp" ] && pushMQTTData "dcRadiatorTemp" "$dcRadiatorTemp"

inverterRelayStateNo=`echo $INVERTER_DATA | jq '.inverterRelayStateNo' -r`
[ ! -z "$inverterRelayStateNo" ] && pushMQTTData "inverterRelayStateNo" "$inverterRelayStateNo"

gridRelayStateNo=`echo $INVERTER_DATA | jq '.gridRelayStateNo' -r`
[ ! -z "$gridRelayStateNo" ] && pushMQTTData "gridRelayStateNo" "$gridRelayStateNo"

loadRelayStateNo=`echo $INVERTER_DATA | jq '.loadRelayStateNo' -r`
[ ! -z "$loadRelayStateNo" ] && pushMQTTData "loadRelayStateNo" "$loadRelayStateNo"

nLineRelayStateNo=`echo $INVERTER_DATA | jq '.nLineRelayStateNo' -r`
[ ! -z "$nLineRelayStateNo" ] && pushMQTTData "nLineRelayStateNo" "$nLineRelayStateNo"

dcRelayStateNo=`echo $INVERTER_DATA | jq '.dcRelayStateNo' -r`
[ ! -z "$dcRelayStateNo" ] && pushMQTTData "dcRelayStateNo" "$dcRelayStateNo"

earthRelayStateNo=`echo $INVERTER_DATA | jq '.earthRelayStateNo' -r`
[ ! -z "$earthRelayStateNo" ] && pushMQTTData "earthRelayStateNo" "$earthRelayStateNo"

accumulatedChargerPowerH=`echo $INVERTER_DATA | jq '.accumulatedChargerPowerH' -r`
[ ! -z "$accumulatedChargerPowerH" ] && pushMQTTData "accumulatedChargerPowerH" "$accumulatedChargerPowerH"

accumulatedChargerPowerL=`echo $INVERTER_DATA | jq '.accumulatedChargerPowerL' -r`
[ ! -z "$accumulatedChargerPowerL" ] && pushMQTTData "accumulatedChargerPowerL" "$accumulatedChargerPowerL"

accumulatedDischargerPowerH=`echo $INVERTER_DATA | jq '.accumulatedDischargerPowerH' -r`
[ ! -z "$accumulatedDischargerPowerH" ] && pushMQTTData "accumulatedDischargerPowerH" "$accumulatedDischargerPowerH"

accumulatedDischargerPowerL=`echo $INVERTER_DATA | jq '.accumulatedDischargerPowerL' -r`
[ ! -z "$accumulatedDischargerPowerL" ] && pushMQTTData "accumulatedDischargerPowerL" "$accumulatedDischargerPowerL"

accumulatedBuyPowerH=`echo $INVERTER_DATA | jq '.accumulatedBuyPowerH' -r`
[ ! -z "$accumulatedBuyPowerH" ] && pushMQTTData "accumulatedBuyPowerH" "$accumulatedBuyPowerH"

accumulatedBuyPowerL=`echo $INVERTER_DATA | jq '.accumulatedBuyPowerL' -r`
[ ! -z "$accumulatedBuyPowerL" ] && pushMQTTData "accumulatedBuyPowerL" "$accumulatedBuyPowerL"

accumulatedSellPowerH=`echo $INVERTER_DATA | jq '.accumulatedSellPowerH' -r`
[ ! -z "$accumulatedSellPowerH" ] && pushMQTTData "accumulatedSellPowerH" "$accumulatedSellPowerH"

accumulatedSellPowerL=`echo $INVERTER_DATA | jq '.accumulatedSellPowerL' -r`
[ ! -z "$accumulatedSellPowerL" ] && pushMQTTData "accumulatedSellPowerL" "$accumulatedSellPowerL"

accumulatedLoadPowerH=`echo $INVERTER_DATA | jq '.accumulatedLoadPowerH' -r`
[ ! -z "$accumulatedLoadPowerH" ] && pushMQTTData "accumulatedLoadPowerH" "$accumulatedLoadPowerH"

accumulatedLoadPowerL=`echo $INVERTER_DATA | jq '.accumulatedLoadPowerL' -r`
[ ! -z "$accumulatedLoadPowerL" ] && pushMQTTData "accumulatedLoadPowerL" "$accumulatedLoadPowerL"

accumulatedSelfusePowerH=`echo $INVERTER_DATA | jq '.accumulatedSelfusePowerH' -r`
[ ! -z "$accumulatedSelfusePowerH" ] && pushMQTTData "accumulatedSelfusePowerH" "$accumulatedSelfusePowerH"

accumulatedSelfusePowerL=`echo $INVERTER_DATA | jq '.accumulatedSelfusePowerL' -r`
[ ! -z "$accumulatedSelfusePowerL" ] && pushMQTTData "accumulatedSelfusePowerL" "$accumulatedSelfusePowerL"

accumulatedPvsellPowerH=`echo $INVERTER_DATA | jq '.accumulatedPvsellPowerH' -r`
[ ! -z "$accumulatedPvsellPowerH" ] && pushMQTTData "accumulatedPvsellPowerH" "$accumulatedPvsellPowerH"

accumulatedPvsellPowerL=`echo $INVERTER_DATA | jq '.accumulatedPvsellPowerL' -r`
[ ! -z "$accumulatedPvsellPowerL" ] && pushMQTTData "accumulatedPvsellPowerL" "$accumulatedPvsellPowerL"

accumulatedGridChargerPowerH=`echo $INVERTER_DATA | jq '.accumulatedGridChargerPowerH' -r`
[ ! -z "$accumulatedGridChargerPowerH" ] && pushMQTTData "accumulatedGridChargerPowerH" "$accumulatedGridChargerPowerH"

accumulatedGridChargerPowerL=`echo $INVERTER_DATA | jq '.accumulatedGridChargerPowerL' -r`
[ ! -z "$accumulatedGridChargerPowerL" ] && pushMQTTData "accumulatedGridChargerPowerL" "$accumulatedGridChargerPowerL"

error1=`echo $INVERTER_DATA | jq '.error1' -r`
[ ! -z "$error1" ] && pushMQTTData "error1" "$error1"

error2=`echo $INVERTER_DATA | jq '.error2' -r`
[ ! -z "$error2" ] && pushMQTTData "error2" "$error2"

error3=`echo $INVERTER_DATA | jq '.error3' -r`
[ ! -z "$error3" ] && pushMQTTData "error3" "$error3"

warning1=`echo $INVERTER_DATA | jq '.warning1' -r`
[ ! -z "$warning1" ] && pushMQTTData "warning1" "$warning1"

warning2=`echo $INVERTER_DATA | jq '.warning2' -r`
[ ! -z "$warning2" ] && pushMQTTData "warning2" "$warning2"

battPower=`echo $INVERTER_DATA | jq '.battPower' -r`
[ ! -z "$battPower" ] && pushMQTTData "battPower" "$battPower"

battCurrent=`echo $INVERTER_DATA | jq '.battCurrent' -r`
[ ! -z "$battCurrent" ] && pushMQTTData "battCurrent" "$battCurrent"

battVoltageGrade=`echo $INVERTER_DATA | jq '.battVoltageGrade' -r`
[ ! -z "$battVoltageGrade" ] && pushMQTTData "battVoltageGrade" "$battVoltageGrade"

ratedPowerW=`echo $INVERTER_DATA | jq '.ratedPowerW' -r`
[ ! -z "$ratedPowerW" ] && pushMQTTData "ratedPowerW" "ratedPowerW"

communicationProtocalEdition=`echo $INVERTER_DATA | jq '.communicationProtocalEdition' -r`
[ ! -z "$communicationProtocalEdition" ] && pushMQTTData "communicationProtocalEdition" "$communicationProtocalEdition"

arrowFlag=`echo $INVERTER_DATA | jq '.arrowFlag' -r`
[ ! -z "$arrowFlag" ] && pushMQTTData "arrowFlag" "$arrowFlag"

chrWorkstateNo=`echo $INVERTER_DATA | jq '.chrWorkstateNo' -r`
[ ! -z "$chrWorkstateNo" ] && pushMQTTData "chrWorkstateNo" "$chrWorkstateNo"

mpptStateNo=`echo $INVERTER_DATA | jq '.mpptStateNo' -r`
[ ! -z "$mpptStateNo" ] && pushMQTTData "mpptStateNo" "$mpptStateNo"

chargingStateNo=`echo $INVERTER_DATA | jq '.chargingStateNo' -r`
[ ! -z "$chargingStateNo" ] && pushMQTTData "chargingStateNo" "$chargingStateNo"

pvVoltage=`echo $INVERTER_DATA | jq '.pvVoltage' -r`
[ ! -z "$pvVoltage" ] && pushMQTTData "pvVoltage" "$pvVoltage"

chrBatteryVoltage=`echo $INVERTER_DATA | jq '.chrBatteryVoltage' -r`
[ ! -z "$chrBatteryVoltage" ] && pushMQTTData "chrBatteryVoltage" "$chrBatteryVoltage"

chargerCurrent=`echo $INVERTER_DATA | jq '.chargerCurrent' -r`
[ ! -z "$chargerCurrent" ] && pushMQTTData "chargerCurrent" "$chargerCurrent"

chargerPower=`echo $INVERTER_DATA | jq '.chargerPower' -r`
[ ! -z "$chargerPower" ] && pushMQTTData "chargerPower" "$chargerPower"

radiatorTemp=`echo $INVERTER_DATA | jq '.radiatorTemp' -r`
[ ! -z "$radiatorTemp" ] && pushMQTTData "radiatorTemp" "$radiatorTemp"

externalTemp=`echo $INVERTER_DATA | jq '.externalTemp' -r`
[ ! -z "$externalTemp" ] && pushMQTTData "externalTemp" "$externalTemp"

batteryRelayNo=`echo $INVERTER_DATA | jq '.batteryRelayNo' -r`
[ ! -z "$batteryRelayNo" ] && pushMQTTData "batteryRelayNo" "$batteryRelayNo"

pvRelayNo=`echo $INVERTER_DATA | jq '.pvRelayNo' -r`
[ ! -z "$pvRelayNo" ] && pushMQTTData "pvRelayNo" "$pvRelayNo"

chrError1=`echo $INVERTER_DATA | jq '.chrError1' -r`
[ ! -z "$chrError1" ] && pushMQTTData "chrError1" "$chrError1"

chrWarning1=`echo $INVERTER_DATA | jq '.chrWarning1' -r`
[ ! -z "$chrWarning1" ] && pushMQTTData "chrWarning1" "$chrWarning1"

ratedCurrent=`echo $INVERTER_DATA | jq '.ratedCurrent' -r`
[ ! -z "$ratedCurrent" ] && pushMQTTData "ratedCurrent" "$ratedCurrent"

accumulatedPvPowerH=`echo $INVERTER_DATA | jq '.accumulatedPvPowerH' -r`
[ ! -z "$accumulatedPvPowerH" ] && pushMQTTData "accumulatedPvPowerH" "$accumulatedPvPowerH"

accumulatedPvPowerL=`echo $INVERTER_DATA | jq '.accumulatedPvPowerL' -r`
[ ! -z "$accumulatedPvPowerL" ] && pushMQTTData "accumulatedPvPowerL" "$accumulatedPvPowerL"

accumulatedDay=`echo $INVERTER_DATA | jq '.accumulatedDay' -r`
[ ! -z "$accumulatedDay" ] && pushMQTTData "accumulatedDay" "$accumulatedDay"

accumulatedHour=`echo $INVERTER_DATA | jq '.accumulatedHour' -r`
[ ! -z "$accumulatedHour" ] && pushMQTTData "accumulatedHour" "$accumulatedHour"

accumulatedMinute=`echo $INVERTER_DATA | jq '.accumulatedMinute' -r`
[ ! -z "$accumulatedMinute" ] && pushMQTTData "accumulatedMinute" "$accumulatedMinute"

