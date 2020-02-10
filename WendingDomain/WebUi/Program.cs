using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AppServices.Tools;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace WebUi
{
    public class Program
    {
        //public static void Main(string[] args)
        //{
        //    BuildWebHost(args).Run();
        //    using (var scope = host.Services.CreateScope())
        //    {
        //        var services = scope.ServiceProvider;
        //        DbSeeder.Seed(services);
        //    }

        //}

        //public static IWebHost BuildWebHost(string[] args) =>
        //    WebHost.CreateDefaultBuilder(args)
        //        .UseStartup<Startup>()
        //        .Build();
        public static void Main(string[] args)
        {
            var host = CreateWebHostBuilder(args).Build();
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                //DbSeeder.Seed(services);
            }

            host.Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
