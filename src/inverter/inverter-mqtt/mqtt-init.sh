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

registerTopic "workStateNo"                     ""      "solar-power" # 0 = Power_On, 1 = SelfTest, 2 = OffGrid, 3 = Grid-Tie, 4 = ByPass, 5 = Stop, 6 = GridCharging
registerTopic "acVoltageGrade"                  "V"     "current-ac"
registerTopic "ratedPower"                      "VA"    "lightbulb-outline"
registerTopic "batteryVoltage"                  "V"     "battery-60"
registerTopic "inverterVoltage"                 "V"     "cog-transfer-outline"
registerTopic "gridVoltage"                     "V"     "grid"
registerTopic "busVoltage"                      "V"     "reorder-horizontal"
registerTopic "controlCurrent"                  "A"     "current-dc"
registerTopic "inverterCurrent"                 "A"     "current-dc"
registerTopic "gridCurrent"                     "A"     "current-ac"
registerTopic "loadCurrent"                     "A"     "current-ac"
registerTopic "pInverter"                       "W"     "flash"
registerTopic "pGrid"                           "W"     "flash"
registerTopic "pLoad"                           "W"     "flash"
registerTopic "loadPercent"                     "%"     "speedometer"
registerTopic "sInverter"                       "VA"    "lightbulb-outline"
registerTopic "sGrid"                           "VA"    "lightbulb-outline"
registerTopic "sLoad"                           "VA"    "lightbulb-outline"
registerTopic "qInverter"                       "Var"   "chart-gantt"
registerTopic "qGrid"                           "Var"   "chart-gantt"
registerTopic "qLoad"                           "Var"   "chart-gantt"
registerTopic "inverterFrequency"               "Hz"    "current-ac"
registerTopic "gridFrequency"                   "Hz"    "current-ac"
registerTopic "inverterMaxNumber"               ""      "format-list-numbered"      
registerTopic "combineType"                     ""      "format-list-bulleted-type"
registerTopic "inverterNumber"                  ""      "format-list-numbered"
registerTopic "acRadiatorTemp"                  "oC"    "thermometer"
registerTopic "transformerTemp"                 "oC"    "thermometer"
registerTopic "dcRadiatorTemp"                  "oC"    "thermometer"
registerTopic "inverterRelayStateNo"            ""      "electric-switch"
registerTopic "gridRelayStateNo"                ""      "electric-switch"
registerTopic "loadRelayStateNo"                ""      "electric-switch"
registerTopic "nLineRelayStateNo"               ""      "electric-switch"
registerTopic "dcRelayStateNo"                  ""      "electric-switch"
registerTopic "earthRelayStateNo"               ""      "electric-switch"
registerTopic "accumulatedChargerPowerH"        "W"     "chart-bell-curve-cumulative"
registerTopic "accumulatedChargerPowerL"        "W"     "chart-bell-curve-cumulative"
registerTopic "accumulatedDischargerPowerH"     "W"     "chart-bell-curve-cumulative"
registerTopic "accumulatedDischargerPowerL"     "W"     "chart-bell-curve-cumulative"
registerTopic "accumulatedBuyPowerH"            "W"     "chart-bell-curve-cumulative"
registerTopic "accumulatedBuyPowerL"            "W"     "chart-bell-curve-cumulative"
registerTopic "accumulatedSellPowerH"           "W"     "chart-bell-curve-cumulative"
registerTopic "accumulatedSellPowerL"           "W"     "chart-bell-curve-cumulative"
registerTopic "accumulatedLoadPowerH"           "W"     "chart-bell-curve-cumulative"
registerTopic "accumulatedLoadPowerL"           "W"     "chart-bell-curve-cumulative"
registerTopic "accumulatedSelfusePowerH"        "W"     "chart-bell-curve-cumulative"
registerTopic "accumulatedSelfusePowerL"        "W"     "chart-bell-curve-cumulative"
registerTopic "accumulatedPvsellPowerH"         "W"     "chart-bell-curve-cumulative"
registerTopic "accumulatedPvsellPowerL"         "W"     "chart-bell-curve-cumulative"
registerTopic "accumulatedGridChargerPowerH"    "W"     "chart-bell-curve-cumulative"
registerTopic "accumulatedGridChargerPowerL"    "W"     "chart-bell-curve-cumulative"
registerTopic "error1"                          ""      "alert-circle-outline" 
registerTopic "error2"                          ""      "alert-circle-outline" 
registerTopic "error3"                          ""      "alert-circle-outline" 
registerTopic "warning1"                        ""      "alert-outline" 
registerTopic "warning2"                        ""      "alert-outline" 
registerTopic "battPower"                       "W"     "battery-charging-70"  
registerTopic "battCurrent"                     "A"     "current-dc"  
registerTopic "battVoltageGrade"                "V"     "battery"  
registerTopic "ratedPowerW"                     "W"     "flash"
registerTopic "communicationProtocalEdition"    ""      "barcode"  
registerTopic "arrowFlag"                       ""      "flag"
registerTopic "chrWorkstateNo"                  ""      "cellphone-charging"
registerTopic "mpptStateNo"                     ""      "vector-curve"
registerTopic "chargingStateNo"                 ""      "battery-charging" 
registerTopic "pvVoltage"                       "V"     "solar-panel"
registerTopic "chrBatteryVoltage"               "V"     "battery"
registerTopic "chargerCurrent"                  "A"     "current-dc"
registerTopic "chargerPower"                    "W"     "flash"
registerTopic "radiatorTemp"                    "oC"    "thermometer"
registerTopic "externalTemp"                    "oC"    "thermometer"
registerTopic "batteryRelayNo"                  ""      "electric-switch"
registerTopic "pvRelayNo"                       ""      "electric-switch"
registerTopic "chrError1"                       ""      "alert-circle-outline"
registerTopic "chrWarning1"                     ""      "battery"
registerTopic "ratedCurrent"                    "A"     "current-dc"
registerTopic "accumulatedPvPowerH"             "W"     "chart-bell-curve-cumulative"  
registerTopic "accumulatedPvPowerL"             "W"     "chart-bell-curve-cumulative"  
registerTopic "accumulatedDay"                  "d"     "calendar-day"   
registerTopic "accumulatedHour"                 "h"     "clock-outline"
registerTopic "accumulatedMinute"               "m"     "timer-outline"

# Add in a separate topic so we can send raw commands from assistant back to the inverter via MQTT (such as changing power modes etc)...
registerInverterRawCMD