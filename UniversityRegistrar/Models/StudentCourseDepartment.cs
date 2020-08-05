namespace UniversityRegistrar.Models
{
  public class StudentCourseDepartment
  {
    public int StudentCourseDepartmentId {get; set;}
    public int? StudentId {get; set;}
    public int? CourseId {get; set;}
    public int? DepartmentId{ get; set;}
    public Student Student {get; set;}
    public Course Course {get; set;}
    public Department Department {get; set;}
  }
}

// 1 2 3 - departments
// a b c - students
// c1 c2 c3 - courses

// a 1 c1
// a 1 c3
// b 1 