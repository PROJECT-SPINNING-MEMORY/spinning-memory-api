using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace SPINNING_MEMORY.Data
{
    public class StoreContextFactory : IDesignTimeDbContextFactory<StoreContext>
    {
        public StoreContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<StoreContext>();

            optionsBuilder.UseSqlite("Data Source=/Users/chloeporter/spinning-memory-api-4/Registrar.sqlite");

            return new StoreContext(optionsBuilder.Options);
        }
    }
}
