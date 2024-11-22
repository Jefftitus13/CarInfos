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
    }
}
