using System.Collections.Generic;

namespace UniversityRegistrar.Models
{
  public class Course
  {
    public Course()
    {
      this.StudentsDepartments = new HashSet<StudentCourseDepartment>();
      //this.Departments = new HashSet<StudentCourseDepartment>();
    }
    public int CourseId {get; set;}
    public string Name {get; set;}
    public string CourseNumber {get; set;}
    public virtual ICollection<StudentCourseDepartment> StudentsDepartments {get; set;}
    //public virtual ICollection<StudentCourseDepartment> Departments {get; set;}
  }
}
