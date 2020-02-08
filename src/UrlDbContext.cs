using Microsoft.EntityFrameworkCore;
using Bitly.Models;


namespace Bitly
{
    public class UrlDbContext : DbContext
    {

        public DbSet<Url> Urls { get; set; }

        public UrlDbContext(DbContextOptions<UrlDbContext> options) : base(options) {}

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Url>().ToTable("url");
            builder.Entity<Url>().HasKey(p => p.Id);
            builder.Entity<Url>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Url>().Property(p => p.LongUrl).IsRequired();
            builder.Entity<Url>().Property(p => p.ShortUrl).IsRequired().HasMaxLength(8).IsFixedLength();
            builder.Entity<Url>().Property(p => p.GeneratedAt).IsRequired();
        }

    }
}
