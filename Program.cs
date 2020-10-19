using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Web_Application_Development
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }


        public static IHostBuilder CreateHostBuilder(string[] args)
        {
            Action<IWebHostBuilder> configure = (webBuilder) => webBuilder.UseStartup<Startup>();
            IHostBuilder hostBuilder = Host
                .CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(configure);
            return hostBuilder;
        }
    }
}
