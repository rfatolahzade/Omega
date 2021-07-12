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
                        options.Dsn = "https://d84018cdc2bb4879a7d6b23d29fed5f5@sentry.rayvarz.cloud/7";
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