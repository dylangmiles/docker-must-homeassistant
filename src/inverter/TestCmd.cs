using inverter.Modbus;
using McMaster.Extensions.CommandLineUtils;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Text;
using System.Threading.Tasks;

namespace inverter
{
    [Command(Name = "test", Description = "Test the inverter communications.")]
    class TestCmd
    {
        protected ILogger _logger;
        protected IConsole _console;

        //[Option(CommandOptionType.SingleValue, ShortName = "u", LongName = "username", Description = "istrada login username", ValueName = "login username", ShowInHelpText = true)]       
        //public string Username { get; set; }


        public TestCmd(ILogger<TestCmd> logger, IConsole console)
        {
            _logger = logger;
            _console = console;
        }
        private InverterCmd Parent { get; set; }

        protected async Task<int> OnExecute(CommandLineApplication app)
        {

            try
            {

                var portName = "/dev/ttyUSB0";

                _console.WriteLine($"Creating port {portName}");

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


                    _console.WriteLine($"Opening port {port}");
                    port.Open();

                    var wrapper = new SerialPortWrapper(port);
                    var reader = new ModbusReader(wrapper);

                    ushort[] values = null;


                    // Pc1800
                    values = ReadValues(reader, port, 4, 20000, 7);
                    values = ReadValues(reader, port, 4, 10001, 8);
                    values = ReadValues(reader, port, 4, 10103, 10);
                    values = ReadValues(reader, port, 4, 15201, 21);

                    // Ph1800
                    values = ReadValues(reader, port, 4, 20000, 17);
                    values = ReadValues(reader, port, 4, 20101, 43);
                    values = ReadValues(reader, port, 4, 25201, 79);

                    //Changing in a loop
                    values = ReadValues(reader, port, 4, 15201, 21);
                    values = ReadValues(reader, port, 4, 25201, 79);
                    
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
            //Sleep between commands1
            System.Threading.Thread.Sleep(500);

            _console.Write($"Reading {deviceId}:{address}:{count} ... ");

            ushort[] values = null;

            try {
                values = reader.Read(deviceId, address, count);
                _console.WriteLine($"got {values.Length} values.");
            } 
            catch (TimeoutException ex)
            {
                _console.WriteLine($"Timeout Exception. {port.BytesToRead} Bytes are available to read.");
            }

            return values;
        }
    }
}
