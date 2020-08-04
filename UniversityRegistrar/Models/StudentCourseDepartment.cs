namespace UniversityRegistrar.Models
{
  public class StudentCourseDepartment
  {
    public int StudentCourseDepartmentId {get; set;}
    public int StudentId {get; set;}
    public int CourseId {get; set;}
    public int DepartmentId{ get; set;}
    public Student Student {get; set;}
    public Course Course {get; set;}
    public Department Department {get; set;}
  }
}