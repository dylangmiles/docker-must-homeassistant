using inverter.Modbus;
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
                    }, 
                    d => { 
                    });
                    var reader = new ModbusReader(wrapper);

                    ushort[] values = null;
                    var modelPc = new Models.Pc1800();


                    //Detection
                    //values = ReadValues(reader, port, 4, 20000, 7);


                    // Pc1800
                    values = ReadValues(reader, port, 4, 10001, 8);
                    ModbusToModelMapper.Map(10001, values, modelPc);
                    
                    values = ReadValues(reader, port, 4, 10103, 10);
                    ModbusToModelMapper.Map(10103, values, modelPc);

                    values = ReadValues(reader, port, 4, 15201, 21);
                    ModbusToModelMapper.Map(15201, values, modelPc);

                    // Ph1800
                    //values = ReadValues(reader, port, 4, 20000, 17);
                    //values = ReadValues(reader, port, 4, 20101, 43);
                    //values = ReadValues(reader, port, 4, 25201, 79);

                    //Changing in a loop
                    //values = ReadValues(reader, port, 4, 15201, 21);
                    //values = ReadValues(reader, port, 4, 25201, 79);
                    
                    port.Close();

                    var json = JsonSerializer.Serialize<Models.Pc1800>(modelPc, new JsonSerializerOptions() { 
                        IgnoreNullValues = true,
                        WriteIndented = true
                    });

                    _console.WriteLine(json);

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

            ushort[] values = new ushort[] { };

            values = reader.Read(deviceId, address, count);

            return values;
        }
    }
}
