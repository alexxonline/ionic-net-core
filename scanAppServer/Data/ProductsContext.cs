using Microsoft.EntityFrameworkCore;
using ScanAppServer.Model;

namespace ScanAppServer.Data
{

    public class ProductsContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("FileName=./products.db");
        }
    }
}