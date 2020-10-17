using McMaster.Extensions.CommandLineUtils;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
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
            //if (string.IsNullOrEmpty(Username) || string.IsNullOrEmpty(Password))
            //{
            //    Username = Prompt.GetString("iStrada Username:", Username);
            //    Password = SecureStringToString(Prompt.GetPasswordAsSecureString("iStrada Password:"));
            //    Staging = Prompt.GetYesNo("iStrada Staging?   ", Staging);
            //    Profile = Prompt.GetString("User profile name:", Profile);
            //    OutputFormat = Prompt.GetString("Output format (json|xml|text|table):", OutputFormat);
            //}

            try
            {                
                //var userProfile = new UserProfile()
                //{
                //    Username = Username,
                //    Password = Encrypt(Password),
                //    Staging = Staging,
                //    OutputFormat = OutputFormat
                //};

                //if (!Directory.Exists(ProfileFolder))
                //{
                //    Directory.CreateDirectory(ProfileFolder);
                //}

                //await File.WriteAllTextAsync($"{ProfileFolder}{Profile}", JsonConvert.SerializeObject(userProfile, Formatting.Indented), UTF8Encoding.UTF8);

                //var token = await iStradaClient.GetTokenAsync();

                return 0;

            }
            catch (Exception ex)
            {
                //OnException(ex);
                return 1;
            }
        }        
    }
}
