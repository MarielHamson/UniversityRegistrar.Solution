using System.Collections.Generic;

namespace UniversityRegistrar.Models
{
  public class Course
  {
    public Course()
    {
      this.Students = new HashSet<StudentCourse>();
    }
    public int CourseId {get; set;}
    public string Name {get; set;}
    public string CourseNumber {get; set;}
    public int DepartmentId { get; set; }
    public virtual Department Department { get; set; }
    public virtual ICollection<StudentCourse> Students {get; set;}
  }
}