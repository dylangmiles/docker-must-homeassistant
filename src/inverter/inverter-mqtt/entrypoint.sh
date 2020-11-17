#!/bin/bash
export TERM=xterm


# Init the mqtt server for the first time, then every 5 minutes
# This will re-create the auto-created topics in the MQTT server if HA is restarted...

watch -n 300 /app/inverter-mqtt/mqtt-vh1800-init.sh > /dev/null 2>&1 &

# Run the MQTT Subscriber process in the background (so that way we can change the configuration on the inverter from home assistant)
/app/inverter-mqtt/mqtt-subscriber.sh &

# execute exactly every 30 seconds...
watch -n 30 /app/inverter-mqtt/mqtt-vh1800-push.sh > /dev/null 2>&1