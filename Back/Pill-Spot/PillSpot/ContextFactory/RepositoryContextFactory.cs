using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Repository;

namespace PillSpot.ContextFactory
{
    public class RepositoryContextFactory : IDesignTimeDbContextFactory<RepositoryContext>
    {
        public RepositoryContext CreateDbContext(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var builder = new DbContextOptionsBuilder<RepositoryContext>()
                .UseMySql(configuration.GetConnectionString("MySqlConnection"),
                    ServerVersion.AutoDetect(configuration.GetConnectionString("MySqlConnection")),
                    options =>
                    {
                        options.MigrationsAssembly("PillSpot");
                        options.UseNetTopologySuite(); // For spatial support
                    });

            builder.EnableSensitiveDataLogging();

            return new RepositoryContext(builder.Options);
        }
    }   
}
