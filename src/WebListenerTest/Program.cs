using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;

namespace WebListenerTest
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var hostBuilder = new WebHostBuilder()
                .UseKestrel()
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseIISIntegration()
                .UseStartup<Startup>();

            //Using UseWebListener doesn't agree with trying to run in IISExpress
            var wlEnv = Environment.GetEnvironmentVariable("WEB_LISTENER");
            if (!string.IsNullOrEmpty(wlEnv) && wlEnv == "1")
            {
                hostBuilder = hostBuilder.UseWebListener(options =>
                {
                    options.ListenerSettings.Authentication.AllowAnonymous = false;
                    options.ListenerSettings.Authentication.Schemes = Microsoft.Net.Http.Server.AuthenticationSchemes.NTLM;
                });
            }

            hostBuilder.Build().Run();
        }
    }
}
