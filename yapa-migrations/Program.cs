using FluentMigrator.Runner;
using Microsoft.Extensions.DependencyInjection;
using System;
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
            return new ServiceCollection()
                .AddFluentMigratorCore()
                .ConfigureRunner(rb => rb                    
                    .AddPostgres()
                    .WithGlobalConnectionString("Server=localhost;Port=5432;User Id=postgres;Password=Password1;Database=users;")
                    .ScanIn(typeof(M10_CreateExpenses).Assembly).For.Migrations())
                .AddLogging(lb => lb.AddFluentMigratorConsole())
                .BuildServiceProvider(false);
        }

        private static void UpdateDatabase(IServiceProvider serviceProvider)
        {
            var runner = serviceProvider.GetRequiredService<IMigrationRunner>();

            runner.MigrateUp();
        }
    }
}
