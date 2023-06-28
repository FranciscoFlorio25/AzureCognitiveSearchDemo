using AzureCognitiveSearchDemo.Entities;
using Microsoft.EntityFrameworkCore;

namespace AzureCognitiveSearchDemo.Data
{
    public class DemoContext :  DbContext
    {
        public DemoContext (DbContextOptions options): base(options) { }
        public DbSet<Products> Products => Set<Products>();
    }
}
