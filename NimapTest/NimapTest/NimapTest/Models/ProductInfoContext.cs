using System.Data.Entity;

namespace NimapTest.Models
{
    public class ProductInfoContext : DbContext
    {
        public ProductInfoContext(): base("DefaultConnection")
        {
        }
       
        public DbSet<Product> Products { get; set; }

        public DbSet<Category> Categories { get; set; }



    }
}