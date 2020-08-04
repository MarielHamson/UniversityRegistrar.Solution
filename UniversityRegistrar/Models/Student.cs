using System;
using System.Collections.Generic;

namespace UniversityRegistrar.Models
{
  public class Student
  {
    public Student()
    {
      this.Courses = new HashSet<StudentCourse>();
    }
    public int DepartmentId { get; set; }
    public virtual Department Department { get; set; }
    public int StudentId {get; set;}
    public string Name {get; set;}
    public DateTime EnrollmentDay {get; set;}
    public string EnrollmentDayInfo {get {return EnrollmentDay.ToString("MM/dd/yyyy");}}
    public ICollection<StudentCourse> Courses {get;}
  }
}