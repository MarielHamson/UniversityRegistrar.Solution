using Microsoft.EntityFrameworkCore;

namespace UniversityRegistrar.Models
{
  public class UniversityRegistrarContext : DbContext
  {
    public virtual DbSet<Course> Courses { get; set; }
    public DbSet<Student> Students { get; set; }
    public DbSet<Department> Departments { get; set; }
    public DbSet<StudentCourse> StudentsCourses {get; set; }
    public DbSet<CourseDepartment> CoursesDepartments {get; set; }

    public UniversityRegistrarContext(DbContextOptions options) : base(options) { }
  }
}