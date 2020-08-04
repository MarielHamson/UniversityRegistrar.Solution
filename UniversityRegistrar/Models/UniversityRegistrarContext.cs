using Microsoft.EntityFrameworkCore;

namespace UniversityRegistrar.Models
{
  public class UniversityRegistrarContext : DbContext
  {
    public virtual DbSet<Course> Courses { get; set; }
    public DbSet<Student> Students { get; set; }
    public DbSet<StudentCourse> StudentCourse {get; set; }
    public DbSet<Department> Departments { get; set; }
    public DbSet<StudentCourseDepartment> StudentCourseDepartment {get; set; }
    public UniversityRegistrarContext(DbContextOptions options) : base(options) { }
  }
}