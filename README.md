# docker-must-homeassistant

This project is to be able to communicate with a Must Solar Inverter which are manufactured by Must: 

https://www.mustsolar.com/

Must have developed a tool called SolarPowerMonitor.exe which does allow comunication through a USB to Serial port on the inverter but it only runs on Windows.

This project is light weight command line poller to receive data and send command to the inverter roughtly based on similar work for the Axpert / Voltronic developed by Ned Kelly here:

https://github.com/ned-kelly/docker-voltronic-homeassistant

I am running this poller on a Raspberry Pi and send the data to Home Assistant.

The Must inverters use a ModBus protocol for reading and writing sensoror values. This is a differetn protocol than what Axpert / Voltronic inverters use and hence the reason for this project.

## Setting up

I am setting up on a Raspberry Pi running Raspberry OS

1. Install Docker and Docker Compose.

2. Clone respository and run communication tests.
    ```

    # Clone the source code
    sudo git clone https://github.com/dylangmiles/docker-must-homeassistant.git /opt/must-inverter-mqtt-agent
    cd /opt/must-inverter-mqtt-agent

    #Build the Docker images
    docker-compose build --build-arg MACHINE_ARCH="-arm32v7"

    # Run the communication tests.
    # This queries the /dev/ttyUSB0 port for the Vc1800 and Vh1800 values. This is a test to check for communication with the inverter.
    docker-compose run --rm inverter test

    # Run the the application in polling mode values and submit readings to MQTT queue.
    docker-compose up -d

    ```



## Reference:

https://minimalmodbus.readthedocs.io/en/stable/modbusdetails.html
https://github.com/ned-kelly/docker-voltronic-homeassistant
https://powerforum.co.za/topic/5120-must-power-ph1800-inverter-odditiesquestions/?tab=comments#comment-84383

## cli
https://medium.com/swlh/build-a-command-line-interface-cli-program-with-net-core-428c4c85221


# Example command to set the inveter in to Solar mode
dotnet inverter.dll set -a 20109 -v 4

# Example command to set the inverter into Utility mode. 
dotnet inverter.dll set -a 20109 -v 3


# Publish on mqtt topic from HA
homeassistant/sensor/must-inverter
-a 20109 -v 3

# Set BatteryStopDischargingVoltage to 24
homeassistant/sensor/must-inverter
-a 20118 -v 24.2

# Set GridMaxChargerCurrentSet to 24
homeassistant/sensor/must-inverter
-a 20125 -v 15