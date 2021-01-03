using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Auth.Data.Context
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<LocalContext>
    {
        private IConfiguration Configuration { get; }

        public DesignTimeDbContextFactory(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public LocalContext CreateDbContext(string[] args)
        {
            var connectionString = Configuration.GetConnectionString("LocalDbConnection");

            var builder = new DbContextOptionsBuilder<LocalContext>().UseSqlServer(connectionString);

            return new LocalContext(builder.Options);
        }
    }
}
