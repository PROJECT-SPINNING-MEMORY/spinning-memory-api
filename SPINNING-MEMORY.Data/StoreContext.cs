using SPINNING.MEMORY.Domain.Catalog;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using SPINNING.MEMORY.Data;

namespace SPINNING_MEMORY.Data
{
    public class StoreContext : DbContext
    { 
        public StoreContext(DbContextOptions<StoreContext> options) 
            : base(options)
        { }

        public DbSet<Item> Items { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            DbInitializer.Initialize(builder);
        }
    }
    
}