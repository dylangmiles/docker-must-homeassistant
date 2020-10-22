using inverter.Modbus;
using McMaster.Extensions.CommandLineUtils;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace inverter
{
    [Command(Name = "poll", Description = "Poll the inverter for all data.")]
    class PollCmd
    {
        protected ILogger _logger;
        protected IConsole _console;

        [Option(CommandOptionType.SingleValue, ShortName = "c", LongName = "count", Description = "The number of times to poll. -1 means continuous.", ValueName = "count", ShowInHelpText = true)]
        public int Count { get; set; }


        public PollCmd(ILogger<PollCmd> logger, IConsole console)
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
                    //Poll and output values as json

                    port.Handshake = Handshake.None;
                    port.DtrEnable = false;
                    port.RtsEnable = false;
                    port.ReadTimeout = 1500;


                    _console.WriteLine($"Opening port {port}");
                    port.Open();

                    var wrapper = new SerialPortWrapper(port, d => { 
                        var renderedBytes = String.Join(" ", d.Select(s => $"{s:X2}"));
                        _console.WriteLine($"< {renderedBytes}");

                    }, 
                    d => { 
                        var renderedBytes = String.Join(" ", d.Select(s => $"{s:X2}"));
                        _console.WriteLine($"> {renderedBytes}");
                    });
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
            //Sleep between reads
            System.Threading.Thread.Sleep(200);

            port.DiscardInBuffer();
            port.DiscardOutBuffer();

            //Set read timeout based on baud rate and count of items
            double timeout = 1.0f / (double) port.BaudRate * 1000.0 * 12.0 * (double) count * 2.0 + (double) (count * 2) + 5.0 + 1000.0;

            port.ReadTimeout = (int)timeout;
            
            _console.WriteLine($"Reading {deviceId}:{address}:{count} ... wait for { port.ReadTimeout }ms .... ");

            ushort[] values = new ushort[] { };

            try {
                
                var start = Environment.TickCount;

                values = reader.Read(deviceId, address, count);

                var end = Environment.TickCount;

                _console.WriteLine($"got {values.Length} values in {end - start} ms");
            } 
            catch (TimeoutException ex)
            {
                _console.WriteLine($"Timeout Exception: {port.BytesToRead} bytes are available to read.");
            }
            catch (InvalidDataException ex)
            {
                _console.WriteLine($"Invalid Data Exception:  {ex.Message}");
            }

            _console.WriteLine("");

            return values;
        }
    }
}
