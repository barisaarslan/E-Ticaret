using Microsoft.EntityFrameworkCore;
using E_Ticaret.Models;

namespace E_Ticaret.Data
{
    public class ECommerceContext : DbContext
    {
        public ECommerceContext(DbContextOptions<ECommerceContext> options) : base(options) { }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }



        
        // Diğer tablolar burada tanımlanabilir
    }
}
