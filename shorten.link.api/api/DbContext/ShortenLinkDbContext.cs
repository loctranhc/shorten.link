using api.Entities;
using Microsoft.EntityFrameworkCore;

namespace api.DbContext
{
    public class ShortenLinkDbContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public DbSet<ShortenLink> ShortenLinks { get; set; }

        public ShortenLinkDbContext(DbContextOptions<ShortenLinkDbContext> options) : base(options) {}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}