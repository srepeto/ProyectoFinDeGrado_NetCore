using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace BancoSangre.EntityFramework
{
    public class BancoSangreDbContextFactory : IDesignTimeDbContextFactory<BancoSangreDbContext>
    {
        public BancoSangreDbContext CreateDbContext(string[] args = null)
        {
            var options = new DbContextOptionsBuilder<BancoSangreDbContext>();
            options.UseSqlServer(@"Server=localhost;Database=bancosangredb;Trusted_Connection=True;");

            return new BancoSangreDbContext(options.Options);
        }
    }
}
