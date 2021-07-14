using System;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
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
                        options.Dsn = Environment.GetEnvironmentVariable("SENTRY_DSN");
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