using McMaster.Extensions.CommandLineUtils;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace inverter
{

    [Command(Name = "inverter", /*ThrowOnUnexpectedArgument = false,*/ OptionsComparison = System.StringComparison.InvariantCultureIgnoreCase)]
    [VersionOptionFromMember("--version", MemberName = nameof(GetVersion))]
    [Subcommand(typeof(TestCmd))]
    [Subcommand(typeof(PollCmd))]
    class InverterCmd
    {
        protected ILogger _logger;  
        protected IConsole _console;

        public InverterCmd(ILogger<InverterCmd> logger, IConsole console)
        {
            _logger = logger;
            _console = console;
        }

        protected Task<int> OnExecute(CommandLineApplication app)
        {
            // this shows help even if the --help option isn't specified
            app.ShowHelp();
            return Task.FromResult(0);
        }

        private static string GetVersion()
            => typeof(InverterCmd).Assembly.GetCustomAttribute<AssemblyInformationalVersionAttribute>().InformationalVersion;
    }

}
