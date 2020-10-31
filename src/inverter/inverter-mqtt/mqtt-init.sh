#!/bin/bash
#
# Simple script to register the MQTT topics when the container starts for the first time...

MQTT_SERVER=`cat /app/mqtt.json | jq '.server' -r`
MQTT_PORT=`cat /app/mqtt.json | jq '.port' -r`
MQTT_TOPIC=`cat /app/mqtt.json | jq '.topic' -r`
MQTT_DEVICENAME=`cat /app/mqtt.json | jq '.devicename' -r`
MQTT_USERNAME=`cat /app/mqtt.json | jq '.username' -r`
MQTT_PASSWORD=`cat /app/mqtt.json | jq '.password' -r`

registerTopic () {
    mosquitto_pub \
        -h $MQTT_SERVER \
        -p $MQTT_PORT \
        -u "$MQTT_USERNAME" \
        -P "$MQTT_PASSWORD" \
        -t "$MQTT_TOPIC/sensor/"$MQTT_DEVICENAME"_$1/config" \
        -m "{
            \"name\": \""$MQTT_DEVICENAME"_$1\",
            \"unit_of_measurement\": \"$2\",
            \"state_topic\": \"$MQTT_TOPIC/sensor/"$MQTT_DEVICENAME"_$1\",
            \"icon\": \"mdi:$3\"
        }"
}

registerInverterRawCMD () {
    mosquitto_pub \
        -h $MQTT_SERVER \
        -p $MQTT_PORT \
        -u "$MQTT_USERNAME" \
        -P "$MQTT_PASSWORD" \
        -t "$MQTT_TOPIC/sensor/$MQTT_DEVICENAME/config" \
        -m "{
            \"name\": \""$MQTT_DEVICENAME"\",
            \"state_topic\": \"$MQTT_TOPIC/sensor/$MQTT_DEVICENAME\"
        }"
}

registerTopic "workStateNo" "" "solar-power" # 0 = Power_On, 1 = SelfTest, 2 = OffGrid, 3 = Grid-Tie, 4 = ByPass, 5 = Stop, 7 = GridCharging
registerTopic "pInverter" "W" "solar-panel-large"
registerTopic "pLoad" "W" "chart-bell-curve"
registerTopic "pGrid" "W" "chart-bell-curve"
registerTopic "batteryVoltage" "V" "battery-outline"

#"power-plug"
#"current-ac"
#"power-plug"
#"current-ac"
#"solar-panel-large"
#"solar-panel-large"

#"solar-panel-large"
#"current-dc"
#"brightness-percent"

#"chart-bell-curve"
#"chart-bell-curve"
#"details"
#"details"
#"battery-outline"
#"battery-outline"
#"current-dc"
#"current-dc"
#"power"
#"power"
#"power"
#"current-dc"
#"current-dc"
#"current-dc"
#"current-dc"
#"current-ac"
#"current-ac"
#"grid"
#"solar-power"
#"battery-negative"

# Add in a separate topic so we can send raw commands from assistant back to the inverter via MQTT (such as changing power modes etc)...
registerInverterRawCMD