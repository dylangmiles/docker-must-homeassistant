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
    [Command(Name = "definition", Description = "Get details about sensor definitions.")]
    class DefinitionCmd
    {
        protected ILogger _logger;
        protected IConsole _console;

        //[Option(CommandOptionType.SingleValue, ShortName = "c", LongName = "count", Description = "The number of times to poll. Default is 1.", ValueName = "count", ShowInHelpText = true)]
        //public int Count { get; set; } = 1;

        //[Option(CommandOptionType.SingleValue, ShortName = "a", LongName = "all", Description = "Returns all values sensor values if true. Default is true. If false only returns a subset of values most likely to have changed.", ValueName = "all", ShowInHelpText = true)]
        //public bool All { get; set; } = true;


        public DefinitionCmd(ILogger<DefinitionCmd> logger, IConsole console)
        {
            _logger = logger;
            _console = console;
        }
        private InverterCmd Parent { get; set; }

        protected int OnExecute(CommandLineApplication app)
        {
            try
            {

               var definitions = SensorDefinitionQuery.Get<Models.Ph1800>();

                var json = JsonSerializer.Serialize<IEnumerable<Models.SensorDefinition>>(definitions, new JsonSerializerOptions() { 
                    IgnoreNullValues = true,
                    WriteIndented = true,
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                });

                _console.WriteLine(json);


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
    }
}
