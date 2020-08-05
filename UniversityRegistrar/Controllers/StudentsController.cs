/*using Microsoft.AspNetCore.Mvc;
using UniversityRegistrar.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace UniversityRegistrar.Controllers
{
  public class StudentsController : Controller
  {
    private readonly UniversityRegistrarContext _db;

    public  StudentsController(UniversityRegistrarContext db)
    {
      _db = db;
    }

    public ActionResult Index(string searchStudent)
    {
      if(!string.IsNullOrEmpty(searchStudent))
      {
        var searchStudents = _db.Students.Where(students => students.Name.Contains(searchStudent)).ToList();                    
        return View(searchStudents);
      }
      return View(_db.Students.ToList());
    }

    public ActionResult Create()
    {
      ViewBag.CourseId = _db.Courses.ToList();
      ViewBag.DepartmentId = new SelectList(_db.Departments, "DepartmentId", "Name");
      return View();
    }

    [HttpPost]
    public ActionResult Create(Student student, int[] CourseId, int DepartmentId)
    {
      _db.Students.Add(student);
      if(DepartmentId != 0)
      {
        if(CourseId.Length !=0)
        {
          foreach(int id in CourseId)
          {
            _db.StudentCourseDepartment.Add(new StudentCourseDepartment() { CourseId = id, StudentId = student.StudentId, DepartmentId = DepartmentId });
          }
          //_db.StudentCourse.Add(new StudentCourse() { CourseId = CourseId, StudentId = student.StudentId});
        }
        else
        {
          _db.StudentCourseDepartment.Add(new StudentCourseDepartment() { StudentId = student.StudentId, DepartmentId = DepartmentId });
        }
      }
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
    
    public ActionResult Details(int id)
    {
      var thisStudent = _db.Students
        .Include(student => student.Courses).ThenInclude(join => join.Course)
        .Include(student => student.Department).ThenInclude(join => join.Department)        
        .FirstOrDefault(student => student.StudentId ==id);

      return View(thisStudent);
    }

    public ActionResult Edit(int id)
    {
      var thisStudent = _db.Students.FirstOrDefault(students => students.StudentId ==id);
      ViewBag.CourseId = _db.Courses.ToList();
      ViewBag.DepartmentId = new SelectList(_db.Departments, "DepartmentId", "Name");
      return View(thisStudent);
    }

    [HttpPost]
    public ActionResult Edit(Student student, int[] CourseId, int DepartmentId)
    {
      if(DepartmentId != 0)
      {
        if(CourseId.Length !=0)
        {
          foreach(int id in CourseId)
          {
            _db.StudentCourseDepartment.Add(new StudentCourseDepartment() { CourseId = id, StudentId = student.StudentId, DepartmentId = DepartmentId });
          }
        }
        else
        {
          _db.StudentCourseDepartment.Add(new StudentCourseDepartment() { StudentId = student.StudentId, DepartmentId = DepartmentId });
        }
      }
      _db.Entry(student).State = EntityState.Modified;
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
    public ActionResult AddCourse(int id)
    {
      var thisStudent = _db.Students.FirstOrDefault(students => students.StudentId == id);
      ViewBag.CourseId = _db.Courses.ToList();
      return View(thisStudent);
    }

    [HttpPost]
    public ActionResult AddCourse(Student student, int[] CourseId)
    {
      if(CourseId.Length !=0)
      {
        foreach(int id in CourseId)
        {
          _db.StudentCourseDepartment.Add(new StudentCourseDepartment() { CourseId = id, StudentId = student.StudentId});
        }
      }
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    [HttpPost]
    public ActionResult DeleteCourse(int joinId)
    {
      var joinEntry = _db.StudentCourseDepartment.FirstOrDefault(entry => entry.StudentCourseDepartmentId ==joinId);
      _db.StudentCourseDepartment.Remove(joinEntry);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
    
    public ActionResult Delete(int id)
    {
      var thisStudent = _db.Students.FirstOrDefault(students => students.StudentId == id);
      return View(thisStudent);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      var thisStudent = _db.Students.FirstOrDefault(students => students.StudentId == id);
      _db.Students.Remove(thisStudent);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
  }
}
*/
