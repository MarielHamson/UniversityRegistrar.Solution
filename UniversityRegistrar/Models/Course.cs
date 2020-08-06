using System.Collections.Generic;

namespace UniversityRegistrar.Models
{
  public class Course
  {
    public Course()
    {
      this.Departments = new HashSet<CourseDepartment>();
      this.Students = new HashSet<StudentCourse>();
    }
    public int CourseId {get; set;}
    public string Name {get; set;}
    public string CourseNumber {get; set;}
    public virtual ICollection<CourseDepartment> Departments {get; set;}
    public virtual ICollection<StudentCourse> Students {get; set;}
  }
}
