using SPINNING_MEMORY.Domain.Catalog;
using Microsoft.EntityFrameworkCore;
using SPINNING_MEMORY.Domain.Orders;
using SPINNING_MEMORY.Data;

namespace SPINNING_MEMORY.Data
{
    public class StoreContext : DbContext
    { 
        public StoreContext(DbContextOptions<StoreContext> options) 
            : base(options)
        { }

        public DbSet<Item> Items { get; set; }

        public DbSet<Order> Orders { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            DbInitializer.Initialize(builder);
        }
    }
    
}