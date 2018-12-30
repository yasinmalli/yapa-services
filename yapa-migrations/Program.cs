using FluentMigrator.Runner;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO;
using yapa_migrations.Migrations;

namespace yapa_migrations
{
    class Program
    {
        static void Main(string[] args)
        {
            var serviceProvider = CreateServices();

            using(var scope = serviceProvider.CreateScope())
            {
                UpdateDatabase(serviceProvider);
            }
        }

        private static IServiceProvider CreateServices()
        {
            var connectionString = GetConnectionString();

            return new ServiceCollection()
                .AddFluentMigratorCore()
                .ConfigureRunner(rb => rb                    
                    .AddPostgres()
                    .WithGlobalConnectionString(connectionString)
                    .ScanIn(typeof(M30_CreateExpenses).Assembly).For.Migrations())
                .AddLogging(lb => lb.AddFluentMigratorConsole())
                .BuildServiceProvider(false);
        }

        private static void UpdateDatabase(IServiceProvider serviceProvider)
        {
            var runner = serviceProvider.GetRequiredService<IMigrationRunner>();

            runner.MigrateUp();
        }

        private static string GetConnectionString()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            IConfigurationRoot configuration = builder.Build();
            
            return string.Format("Server={0};Port={1};User Id={2};Password={3};Database={4};",
                configuration["db_server"], configuration["db_port"], configuration["db_user_id"],
                configuration["db_password"], configuration["db_name"]);            
        }
    }
}
