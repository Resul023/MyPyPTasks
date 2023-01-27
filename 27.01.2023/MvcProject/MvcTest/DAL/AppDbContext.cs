using Microsoft.EntityFrameworkCore;
using MvcTest.Models;
namespace MvcTest.DAL;

public class AppDbContext:DbContext{
    public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
    {
        
    }
    public DbSet<Movie> Movie {get;set;}
}