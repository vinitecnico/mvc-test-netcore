  
using MvcTest.Models;
using Microsoft.EntityFrameworkCore;

namespace MvcTest.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Book> Books {get;set;}
        
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }
    }
}