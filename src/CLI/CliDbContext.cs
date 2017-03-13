using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CLI
{
    public class CliDbContext : DbContext
    {
        public CliDbContext(DbContextOptions<CliDbContext> options) : base(options)
        { }
    }

    public class MyDbContextFactory : IDbContextFactory<CliDbContext>
    {
        IConfigurationRoot Configuration;

        public MyDbContextFactory()
        {
            var builder = new ConfigurationBuilder()
             .SetBasePath(Directory.GetCurrentDirectory())
             .AddJsonFile("appsettings.json");

            Configuration = builder.Build();
        }

        public CliDbContext Create(DbContextFactoryOptions options)
        {
            var builder = new DbContextOptionsBuilder<CliDbContext>();

            builder.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));

            return new CliDbContext(builder.Options);
        }
    }
}
