using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace LearnDockerCiCd.Infrastructure.Persistence
{
    public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        public AppDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
            // Set your connection string here (use your real one)
            optionsBuilder.UseNpgsql("Host=localhost;Port=5434;Database=DockerCiCdDb;Username=admin;Password=password");

            return new AppDbContext(optionsBuilder.Options);
        }
    }
}
