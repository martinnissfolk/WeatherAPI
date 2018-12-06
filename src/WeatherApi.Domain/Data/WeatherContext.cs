using Microsoft.EntityFrameworkCore;
using WeatherApi.Domain.Entities;

namespace WeatherApi.Domain.Data
{
    public class WeatherContext : DbContext
    {
        public WeatherContext(DbContextOptions<WeatherContext> options)
           : base(options)
        {
        }

        public DbSet<Location> Locations { get; set; }
        public DbSet<WeatherItem> WeatherItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Location>()
                .HasKey(ci => ci.Id);
            modelBuilder.Entity<WeatherItem>()
                .HasOne(pt => pt.Location)
                .WithMany(u => u.WeatherItems);
        }
    }
}
