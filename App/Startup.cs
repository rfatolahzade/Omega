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
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            app.UseSentryTracing();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context =>
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
                    var transaction = SentrySdk.StartTransaction(
                        "PowTra",
                        "PowTra-operation"
                    );
                    var span = transaction.StartChild("PowTra-child-operation");
                    SentrySdk.GetTraceHeader();
                    var queryCollection = context.Request.Query;
                    var a = Convert.ToInt32(queryCollection["a"]);
                    var b = Convert.ToInt32(queryCollection["b"]);
                    await context.Response.WriteAsync(Math.Pow(a,b).ToString());
                    span.Finish();
                    transaction.Finish();
                });	
                var transaction = SentrySdk.StartTransaction(
                    "ExceptionTra",
                    "Exception-operation"
                );
                var span = transaction.StartChild("ExceptionTra-child-operation");
                SentrySdk.GetTraceHeader();
                endpoints.MapGet("/Exception", async context =>
                {
                    throw new ApplicationException("An Exception Occured!");
                });
                span.Finish();
                transaction.Finish();
            });
        }
    }
}
