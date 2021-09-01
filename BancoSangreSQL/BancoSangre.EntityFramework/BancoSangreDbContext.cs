using BancoSangre.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace BancoSangre.EntityFramework
{
    public class BancoSangreDbContext : DbContext
    {
        public BancoSangreDbContext(DbContextOptions options) : base(options) { }
        public DbSet<Donante> Donantes { get; set; }
        public DbSet<Donacion> Donaciones { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("bancosangredb");
        }

    }
}
