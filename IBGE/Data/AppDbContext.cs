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
            optionsBuilder.UseSqlServer("Server=tcp:desafioservidor.database.windows.net,1433;Initial Catalog=DesafioDataBase;Persist Security Info=False;User ID=quieladmin;Password=Quiel@2021#;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new IbgeMap());
            modelBuilder.ApplyConfiguration(new UserMap());
        }
    }
}
