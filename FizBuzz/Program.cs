using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using FizBuzz.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FizBuzz
{
    public class Program
    {
        public static void Main(string[] args)
        {
            
           var host = CreateHostBuilder(args).Build();
            using (var scope = host.Services.CreateScope())
            {
      
                var services = scope.ServiceProvider;
                try
                {
                    SeedData.Initialize(services);
                }
                catch(Exception e)
                {
                    Console.WriteLine("Farkk");
                    var logger = services.GetRequiredService<ILogger<Program>>();
                    logger.LogError(e, "An error occurred seeding the DB.");
                }
            }
            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
