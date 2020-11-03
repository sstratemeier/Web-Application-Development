
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Web_Application_Development
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

            // Url rewrite if Content-Type: text/plain and index.txt exists
            // https://weblog.west-wind.com/posts/2020/Mar/13/Back-to-Basics-Rewriting-a-URL-in-ASPNET-Core#summary
            app.Use(async (context, next) =>
            {
                var url = context.Request.Path.Value;
                var acceptHeaders = context.Request.Headers["Accept"];

                // If txt file is requested on a folder then try to resolve a text representation of that folder
                if (acceptHeaders.Contains("text/plain")
                    && Directory.Exists(env.ContentRootPath + "/wwwroot" + url)
                    && File.Exists(env.ContentRootPath + "/wwwroot" + url + "index.txt"))
                {
                    // rewrite and continue processing
                    context.Request.Path = url + "/index.txt";
                }

                await next();
            });


            // Serve default static files like index.html
            // https://docs.microsoft.com/en-us/aspnet/core/fundamentals/static-files?view=aspnetcore-3.1
            app.UseDefaultFiles();

            // Serve static files from wwwroot
            app.UseStaticFiles();
        }
    }
}