# docker-must-homeassistant

This project is to be able to communicate with a Must Solar Inverter which are manufactured by Must: https://www.mustsolar.com/

Must have developed a tool called SolarPowerMonitor.exe which does allow comunication through a USB to Serial port on the inverter but it only runs on Windows.

I want to develop a light weight command line poller to receive data and send command to the inverter roughtly based on similar work for the Axpert / Voltronic developed by Ned Kelly here: voltronic

I plan to run this poller on a Raspberry Pi and send the data to Home Assistant.

The Must, and in my case specifically the VH1800, uses a different protocol to the Axpert / Voltronic and hence the purpose.


Reference:

https://github.com/ned-kelly/docker-voltronic-homeassistant
https://powerforum.co.za/topic/5120-must-power-ph1800-inverter-odditiesquestions/?tab=comments#comment-84383
