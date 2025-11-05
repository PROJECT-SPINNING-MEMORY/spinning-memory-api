using SPINNING_MEMORY.Domain.Catalog;
using Microsoft.EntityFrameworkCore;

namespace SPINNING_MEMORY.Data
{
    public class StoreContext : DbContext
    { 
        public StoreContext(DbContextOptions<StoreContext> options) 
            : base(options)
        { }

        public DbSet<Item> Items { get; set; }
    }
    
}