using IBGE.Data.Mappings;
using IBGE.Models;
using Microsoft.EntityFrameworkCore;

namespace IBGE.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Ibge> Ibges { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-HP2UQRQ\\SQLEXPRESS; Database=myDataBase; Trusted_Connection=True; Encrypt = False");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new IbgeMap());
            modelBuilder.ApplyConfiguration(new UserMap());
        }
    }
}
