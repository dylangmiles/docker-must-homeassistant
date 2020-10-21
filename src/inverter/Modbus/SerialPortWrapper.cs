using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Text;

namespace inverter.Modbus
{
    public class SerialPortWrapper : ISerialPort
    {
        private SerialPort _serialPort;
        private Action<byte[]> _dataInFunc;
        private Action<byte[]> _dataOutFunc;

        public SerialPortWrapper(SerialPort serialPort, Action<byte[]> dataIn, Action<byte[]> dataOut)
        {
            _serialPort = serialPort;
            _dataInFunc = dataIn;
            _dataOutFunc = dataOut;
        }

        public int Read(byte[] buffer, int offset, int count)
        {
            var read = _serialPort.Read(buffer, offset, count);
            
            _dataInFunc(buffer);

            return read;
        }

        public void Write(byte[] buffer, int offset, int count)
        {
            _dataOutFunc(buffer);

            _serialPort.Write(buffer, offset, count);
        }
    }
}
