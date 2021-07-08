using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Sentry;
using Sentry.AspNetCore;

namespace App
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
        }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            
            app.UseDefaultFiles();
            app.UseStaticFiles();
            
            app.UseSentryTracing();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/Hello", async context =>
                {
                    
                    var transaction = SentrySdk.StartTransaction(
                        "MyIndexTra",
                        "MyIndexTra-operation"
                    );
                    var span = transaction.StartChild("MyIndexTra-child-operation");
                    SentrySdk.GetTraceHeader();
                    await context.Response.WriteAsync("Hello World!");
                    span.Finish();
                    transaction.Finish();
                });
                endpoints.MapGet("/POW", async context =>
                {
                    var queryCollection = context.Request.Query;
                    var a = Convert.ToInt32(queryCollection["a"]);
                    var b = Convert.ToInt32(queryCollection["b"]);
                    if (a == 2 && b == 3)
                        System.Threading.Thread.Sleep(5000);
                    await context.Response.WriteAsync(Math.Pow(a, b).ToString());
                });	
                endpoints.MapGet("/Exception", async context =>
                {
                    throw new ApplicationException("An Exception Occured!");
                });
            });
        }
    }
}
