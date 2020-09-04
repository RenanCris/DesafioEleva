using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace ElevaEducacao.Infra.EFCore.Extensions
{
    public static class CustomDbContextOptionsBuilder
    {
        public static DbContextOptionsBuilder<TDbContext> BuildOptions<TDbContext>(string connectionStringName) where TDbContext : DbContext
        {
            var optionsBuilder = new DbContextOptionsBuilder<TDbContext>();

            var env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

            var configuration = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env}.json", optional: true)
                .Build();

            optionsBuilder.UseMySql(configuration.GetConnectionString(connectionStringName));

            return optionsBuilder;
        }
    }
}
