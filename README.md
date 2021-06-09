# docker-must-homeassistant

This project is to be able to communicate with a Must Solar Inverter which are manufactured by Must: 

https://www.mustsolar.com/

Must have developed a tool called SolarPowerMonitor.exe which does allow comunication through a USB to Serial port on the inverter but it only runs on Windows.

I want to develop a light weight command line poller to receive data and send command to the inverter roughtly based on similar work for the Axpert / Voltronic developed by Ned Kelly here:

https://github.com/ned-kelly/docker-voltronic-homeassistant

I plan to run this poller on a Raspberry Pi and send the data to Home Assistant.

The Must, and in my case specifically the VH1800, uses a different protocol to the Axpert / Voltronic and hence the purpose.


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
    docker-compose run --rm inverter test


    ```


This queries the /dev/ttyUSB0 port for the Vc1800 and Vh1800 values. This is a test to check for communication with the inverter.


## Scratch

Looks like the the inverter uses the ModBus protocol: https://www.codeproject.com/Articles/20929/Simple-Modbus-Protocol-in-C-NET-2-0

19200 573 char time

19200 baud rate with say 11 bits per byte = 19200 / 11 = 1745 bytes per second

Each char is approx imately 573 us to send.

count * (1000 / 19200 / 11) 


## Reference:

https://minimalmodbus.readthedocs.io/en/stable/modbusdetails.html
https://github.com/ned-kelly/docker-voltronic-homeassistant
https://powerforum.co.za/topic/5120-must-power-ph1800-inverter-odditiesquestions/?tab=comments#comment-84383

## cli
https://medium.com/swlh/build-a-command-line-interface-cli-program-with-net-core-428c4c85221


# Solar
dotnet inverter.dll set -a 20109 -v 4

# Utility 
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