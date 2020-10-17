using System;
using System.IO;
using System.Threading.Tasks;
using McMaster.Extensions.CommandLineUtils;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Extensions.Logging;

namespace inverter
{
    class Program
    {
        private static async Task<int> Main(string[] args)
        {

            var Configuration = new ConfigurationBuilder()
        .SetBasePath(Directory.GetCurrentDirectory())
        .AddJsonFile(AppDomain.CurrentDomain.BaseDirectory + "\\appsettings.json", optional: true, reloadOnChange: true)
        .AddEnvironmentVariables()
        .Build();

            Log.Logger = new LoggerConfiguration()
                   .ReadFrom.Configuration(Configuration)
                   .Enrich.FromLogContext()
                   .CreateLogger();

            var builder = new HostBuilder()
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddLogging(config =>
                    {
                        config.ClearProviders();
                        config.AddProvider(new SerilogLoggerProvider(Log.Logger));
                        var minimumLevel = Configuration.GetSection("Serilog:MinimumLevel")?.Value;
                        if (!string.IsNullOrEmpty(minimumLevel))
                        {
                            config.SetMinimumLevel(Enum.Parse<LogLevel>(minimumLevel));
                        }
                    });

                    //services.AddSingleton<IFooService, FooService>();
                });

            try
            {
                return await builder.RunCommandLineApplicationAsync<InverterCmd>(args);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return 1;
            }
        }
    }

}
