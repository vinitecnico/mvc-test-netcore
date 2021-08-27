
using MvcTest.Models;
using Microsoft.EntityFrameworkCore;
namespace MvcTest.Data
{
  public class ApplicationDbContext : DbContext
  {
    public DbSet<Student> Student { get; set; }
    public DbSet<Teacher> Teacher { get; set; }
    public DbSet<Enrollment> Enrollment { get; set; }
    public DbSet<Subject> Subject { get; set; }
    public DbSet<Course> Course { get; set; }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {

    }
  }
}