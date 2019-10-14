using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using EF_codefirst_migration.Context;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Steeltoe.Extensions.Configuration.CloudFoundry;

namespace EF_codefirst_migration
{
    public class Program
    {
        public static void Main(string[] args)
        {
            switch (args[0])
            {
                // cf run-task EFCodeFirstMigration "cd /home/vcap/deps/0/dotnet_publish && exec ./EF-codefirst-migration --update-database" --name update-database-task
                case "--update-database":
                    // start task and print to console
                    Console.WriteLine("Getting database ...");
                    var host = CreateWebHostBuilder(args).Build();
                    var context = host.Services.GetService<SchoolContext>();
                    Console.WriteLine("Updating database ...");
                    context.Database.Migrate();
                    Console.WriteLine("Update database done");
                    break;
                default:
                    // normal start from web application
                    CreateWebHostBuilder(args).Build().Run();
                    break;
            }
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .AddCloudFoundry()
                .UseStartup<Startup>();
    }
}
