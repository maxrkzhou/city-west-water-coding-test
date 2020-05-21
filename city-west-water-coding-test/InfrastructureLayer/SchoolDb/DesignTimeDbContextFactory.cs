using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace city_west_water_coding_test.InfrastructureLayer.SchoolDb
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<SchoolDbContext>
    {
        public SchoolDbContext CreateDbContext(string[] args)
        {
            IConfiguration configuration = new ConfigurationBuilder()
                                            .SetBasePath(Directory.GetCurrentDirectory())
                                            .AddJsonFile("appsettings.json")
                                            .Build();
            var builder = new DbContextOptionsBuilder<SchoolDbContext>();
            var connectionString = configuration.GetConnectionString("Primary");
            builder.UseSqlServer(connectionString);
            return new SchoolDbContext(builder.Options);
        }
    }
}
