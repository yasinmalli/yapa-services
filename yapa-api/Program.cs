﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace yapa_api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                // .ConfigureAppConfiguration((hostingContext, config) => {
                //     if (!hostingContext.HostingEnvironment.IsDevelopment()) {
                //         config.AddSecretsManager(configurator: ops => {
                //             ops.KeyGenerator = (secret, name) => name.Replace("__", ":");
                //         });
                //     }                    
                // })
                .ConfigureAppConfiguration((hostinContext, config) => {
                    if (!hostinContext.HostingEnvironment.IsDevelopment()) {
                        config.AddSystemsManager("/yapa-api");
                    }                    
                })
                .UseStartup<Startup>();
    }
}
