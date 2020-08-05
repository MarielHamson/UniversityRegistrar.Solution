using System;
using System.Collections.Generic;

namespace UniversityRegistrar.Models
{
  public class Student
  {
    public Student()
    {
      this.Courses = new HashSet<StudentCourseDepartment>();
    }
    public int StudentId {get; set;}
    public string Name {get; set;}
    public DateTime EnrollmentDay {get; set;}
    public string EnrollmentDayInfo {get {return EnrollmentDay.ToString("MM/dd/yyyy");}}
    public virtual ICollection<StudentCourseDepartment> Courses {get; set;}  
    public virtual StudentCourseDepartment Department {get; set;}  
  }
}