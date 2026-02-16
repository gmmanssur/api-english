using ApiEnglish.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ApiEnglish.Infrastructure.Config
{
    public sealed class EpgDbContext(DbContextOptions<EpgDbContext> options) : DbContext(options)
    {
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("epg");
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(EpgDbContext).Assembly);

            base.OnModelCreating(modelBuilder);
        }
    }
}