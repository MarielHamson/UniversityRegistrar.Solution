namespace UniversityRegistrar.Models
{
  public class Student
  {
    public Student()
    {
      this.Courses = new HashSet<StudentCourse>();
    }
    public int StudentId {get; set;}
    public string Name {get; set;}
    public DateTime EnrollmentDay {get; set;}

    public ICollection<StudentCourse> Courses {get;}
  }
}