using Microsoft.EntityFrameworkCore;
using QSIT_Task_2.Models;

namespace QSIT_Task_2.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<MapConfigurations> MapConfigurations { get; set; }
        public DbSet<MapType> MapTypes { get; set; }
    }
}
