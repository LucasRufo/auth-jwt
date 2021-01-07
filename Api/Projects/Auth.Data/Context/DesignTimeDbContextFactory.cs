using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace Auth.Data.Context
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<LocalContext>
    {
        public DesignTimeDbContextFactory() { }

        public LocalContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile(@Directory.GetCurrentDirectory() + "/../../../Projects/Auth.API/appsettings.json")
                .Build();

            var connectionString = configuration.GetConnectionString("LocalDbConnection");

            var builder = new DbContextOptionsBuilder<LocalContext>().UseSqlServer(connectionString);

            return new LocalContext(builder.Options);
        }
    }
}
