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

        [Option(CommandOptionType.SingleValue, ShortName = "a", LongName = "address", Description = "The address of the sensor. If not specified all sensor defitionas are returned.", ValueName = "a", ShowInHelpText = true)]
        public short? Address { get; set; } = null;

        [Option(CommandOptionType.SingleValue, ShortName = "n", LongName = "name", Description = "The name of the sensor. If not specified all sensor defintions are returned. The match is case insensitive and will return all sensor definitions whose names contain the specified name.", ValueName = "name", ShowInHelpText = true)]
        public string Name { get; set; } = null;


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

                if (this.Address != null)
                {
                    definitions = definitions.Where(w => w.Address == this.Address.Value);
                }

                if (this.Name != null)
                {
                    definitions = definitions.Where(w => w.Name.ToLower().Contains(this.Name.ToLower()));
                }

                

                var json = JsonSerializer.Serialize<IEnumerable<Models.SensorDefinition>>(definitions, new JsonSerializerOptions() { 
                    IgnoreNullValues = true,
                    WriteIndented = true,
                    //Rather leave as PascalCase.
                    //PropertyNamingPolicy = JsonNamingPolicy.CamelCase
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
