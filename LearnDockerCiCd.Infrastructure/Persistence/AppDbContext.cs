using Microsoft.EntityFrameworkCore;
using LearnDockerCiCd.Domain.Entities;

namespace LearnDockerCiCd.Infrastructure.Persistence
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }  // Example DbSet for User entity

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Fluent API configurations if any
        }
    }
}
