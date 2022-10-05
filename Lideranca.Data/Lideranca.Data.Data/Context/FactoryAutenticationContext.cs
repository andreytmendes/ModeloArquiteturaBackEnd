using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lideranca.Data.Data.Context
{
    public class FactoryAutenticationContext : IDesignTimeDbContextFactory<AutenticationContext>
    {
        public AutenticationContext CreateDbContext(string[] args)
        {
            var connectionString = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build()["ConnectionString"];

            var optionsBuilder = new DbContextOptionsBuilder<AutenticationContext>();
            optionsBuilder.UseSqlServer(connectionString);

            return new AutenticationContext(optionsBuilder.Options);
        }
    }
}
