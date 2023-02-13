using Microsoft.EntityFrameworkCore;
using SqlDependency.Models;

namespace SqlDependency.DATA
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {
                
        }
        public DbSet<Product> Product { get; set; }
    }
}
