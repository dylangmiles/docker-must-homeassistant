using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Text;

namespace inverter.Modbus
{
    public class SerialPortWrapper : ISerialPort
    {
        private SerialPort _serialPort;

        public SerialPortWrapper(SerialPort serialPort)
        {
            _serialPort = serialPort;
        }

        public int Read(byte[] buffer, int offset, int count)
        {
            return _serialPort.Read(buffer, offset, count);
        }

        public void Write(byte[] buffer, int offset, int count)
        {
            _serialPort.Write(buffer, offset, count);
        }
    }
}
