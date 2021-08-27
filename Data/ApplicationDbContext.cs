
using MvcTest.Models;
using Microsoft.EntityFrameworkCore;
namespace MvcTest.Data
{
  public class ApplicationDbContext : DbContext
  {
    public DbSet<Student> Students { get; set; }
    public DbSet<Enrollment> Enrollments { get; set; }
    public DbSet<Course> Courses { get; set; }
    public DbSet<Subject> Subjects { get; set; }
    public DbSet<Teacher> Teachers { get; set; }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {

    }
  }
}