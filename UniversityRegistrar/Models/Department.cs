using System.Collections.Generic;

namespace UniversityRegistrar.Models
{
  public class Department
  {
    public Department()
    {
      this.StudentsCourses = new HashSet<StudentCourseDepartment>();
    }
    public int DepartmentId {get; set;}
    public string Name {get; set;}
    public virtual ICollection<StudentCourseDepartment> StudentsCourses {get; set;}
  }
}