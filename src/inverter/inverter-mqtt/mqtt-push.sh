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

workStateNo=`echo $INVERTER_DATA | jq '.workStateNo' -r`

# 0 = Power_On, 1 = SelfTest, 2 = OffGrid, 3 = Grid-Tie, 4 = ByPass, 5 = Stop, 7 = GridCharging

[ ! -z "$workStateNo" ] && pushMQTTData "workStateNo" "$workStateNo"

pInverter=`echo $INVERTER_DATA | jq '.pInverter' -r`
[ ! -z "$pInverter" ] && pushMQTTData "pInverter" "$pInverter"

pLoad=`echo $INVERTER_DATA | jq '.pLoad' -r`
[ ! -z "$pLoad" ] && pushMQTTData "pLoad" "$pLoad"

pGrid=`echo $INVERTER_DATA | jq '.pGrid' -r`
[ ! -z "$pGrid" ] && pushMQTTData "pGrid" "$pGrid"

batteryVoltage=`echo $INVERTER_DATA | jq '.batteryVoltage' -r`
[ ! -z "$batteryVoltage" ] && pushMQTTData "batteryVoltage" "$batteryVoltage"

