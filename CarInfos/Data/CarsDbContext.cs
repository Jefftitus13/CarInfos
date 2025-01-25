using CarInfos.Models.Entity;
using Microsoft.EntityFrameworkCore;

namespace CarInfos.Data
{
    public class CarsDbContext : DbContext
    {
        public CarsDbContext(DbContextOptions<CarsDbContext> options) : base(options)
        {
        }
        public DbSet<Cars> Cars { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Favorite> Favorites { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Favorite>()
                .HasKey(f => new { f.UserId, f.CarId });

            modelBuilder.Entity<Favorite>()
                .HasOne(f => f.User)
                .WithMany(u => u.Favorites)
                .HasForeignKey(f => f.UserId);

            modelBuilder.Entity<Favorite>()
                .HasOne(f => f.Car)
                .WithMany(c => c.Favorites)
                .HasForeignKey(f => f.CarId);
        }


    }
}
