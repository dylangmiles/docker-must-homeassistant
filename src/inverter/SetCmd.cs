using inverter.Modbus;
using inverter.Models;
using McMaster.Extensions.CommandLineUtils;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace inverter
{
    [Command(Name = "set", Description = "Set sensor values.")]
    public class SetCmd
    {
        protected ILogger _logger;
        protected IConsole _console;

        [Option(CommandOptionType.MultipleValue, ShortName = "a", LongName = "address", Description = "Address of sensor to set.", ValueName = "address", ShowInHelpText = true)]
        public ushort[] Addresses { get; set; } = new ushort[] { };

        [Option(CommandOptionType.MultipleValue, ShortName = "v", LongName = "value", Description = "Value of sensor to set.", ValueName = "value", ShowInHelpText = true)]
        public double[] Values { get; set; } = new double[] { };


        public SetCmd(ILogger<SetCmd> logger, IConsole console)
        {
            _logger = logger;
            _console = console;
        }
        private InverterCmd Parent { get; set; }

        protected int OnExecute(CommandLineApplication app)
        {
            try
            {

                var portName = "/dev/ttyUSB0";

                using (var port = new SerialPort(
                    portName,
                    19200,
                    Parity.None,
                    8,
                    StopBits.One
                    )
                )
                {
                    port.Handshake = Handshake.None;
                    port.DtrEnable = false;
                    port.RtsEnable = false;
                    port.ReadTimeout = 1500;

                    var dictionary = ModbusSensorHelper.GetModbusSensorPropertyInfos<Ph1800>();

                    port.Open();

                    var wrapper = new SerialPortWrapper(port, d => { 
                    }, 
                    d => { 
                    });
                    var writer = new ModbusWriter(wrapper);

                    var index = 0;
                    foreach(var address in this.Addresses)
                    {

                        var property = dictionary[address];
                        var attribute = property.GetCustomAttributes(true).Where(y => y.GetType() == typeof(ModbusSensorAttribute)).First() as ModbusSensorAttribute;

                        var coefficient = attribute.Coefficient;
                        var v = (ushort)(this.Values[index] / coefficient);

                        writer.write(4, address,  new ushort[] {v});

                        index++;
                    }

                    port.Close();
                }

                return 0;

            }
            catch (Exception ex)
            {
                _console.WriteLine("EXCEPTION ERROR OCCURED:");
                _console.WriteLine("");

                _console.WriteLine(ex.ToString());

                return 1;
            }
        }

        private ushort[] ReadValues(ModbusReader reader, SerialPort port, byte deviceId, ushort address, ushort count)
        {
            //Sleep between reads
            //System.Threading.Thread.Sleep(200);

            port.DiscardInBuffer();
            port.DiscardOutBuffer();

            //Set read timeout based on baud rate and count of items
            double timeout = 1.0f / (double) port.BaudRate * 1000.0 * 12.0 * (double) count * 2.0 + (double) (count * 2) + 5.0 + 1000.0;

            port.ReadTimeout = (int)timeout;

            ushort[] values = new ushort[] { };

            values = reader.Read(deviceId, address, count);

            return values;
        }
    }
}
