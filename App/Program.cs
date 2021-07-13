using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Sentry;

namespace App
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>().UseWebRoot(Path.Combine(Directory.GetCurrentDirectory(), "FrontEnd"));
                    webBuilder.UseSentry(options =>
                    {
                        options.Dsn = "https://7ceb6f89b1a54369af4de126849da0ee@sentry.rayvarz.dev/2";
                        // options.Debug = true;
                        options.TracesSampleRate = 1.0;
                        options.BeforeSend = delegate(SentryEvent sentryEvent)
                        {
                            sentryEvent.User = new User {Username ="Madness-Client"};
                            sentryEvent.SetExtra("Test",".NetCore");
                            sentryEvent.SetTag("App","omega");
                            return sentryEvent;
                        };
                    });
                });
    }
}