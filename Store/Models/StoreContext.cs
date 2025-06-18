using Microsoft.EntityFrameworkCore;

namespace Store.Models
{
    public class StoreContext: DbContext
    {
        public StoreContext(DbContextOptions options): base(options)
        {

        }

        public DbSet<UserTable> UserTable { get; set; }
        public DbSet<ProductTable> ProductTable { get; set; }
        public DbSet<CartTable> CartTable { get; set; }
    }
}
