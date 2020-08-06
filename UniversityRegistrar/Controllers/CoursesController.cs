using Microsoft.AspNetCore.Mvc;
using UniversityRegistrar.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace UniversityRegistrar.Controllers
{
  public class CoursesController : Controller
  {
    private readonly UniversityRegistrarContext _db;

    public  CoursesController(UniversityRegistrarContext db)
    {
      _db = db;
    } 

    public ActionResult Index(string searchCourse)
    {
      if(!string.IsNullOrEmpty(searchCourse))
      {
        var searchCourses = _db.Courses.Where(courses => courses.CourseNumber.Contains(searchCourse) || courses.Name.Contains(searchCourse)).ToList();                    
        return View(searchCourses);
      }
      return View(_db.Courses.ToList());
    }

    public ActionResult Create()
    {
      ViewBag.DepartmentId = _db.Departments.ToList();
      //ViewBag.DepartmentId = new SelectList(_db.Departments, "DepartmentId", "Name");
      return View();
    }

    [HttpPost]
    public ActionResult Create(Course course, int[] DepartmentId)
    {
      _db.Courses.Add(course);
      if(DepartmentId.Length !=0)
      {
        foreach(int id in DepartmentId)
        {
          _db.CoursesDepartments.Add(new CourseDepartment() { CourseId = course.CourseId, DepartmentId = id });
        }
      }
      /*if(DepartmentId!=0)
      {
        _db.CoursesDepartments.Add(new CourseDepartment() { CourseId = course.CourseId, DepartmentId = DepartmentId});
      }*/
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Details(int id)
    {
      var thisCourse = _db.Courses
        .Include(course => course.Students).ThenInclude(join=> join.Student)
        .Include(course => course.Departments).ThenInclude(join => join.Department)
        .FirstOrDefault(courses => courses.CourseId == id);
      return View(thisCourse);
    }

    public ActionResult Edit(int id)
    {
      var thisCourse = _db.Courses.FirstOrDefault(courses => courses.CourseId == id);
      return View(thisCourse);
    }

    [HttpPost]
    public ActionResult Edit(Course course)
    {
      _db.Entry(course).State = EntityState.Modified;
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult AddStudent(int id)
    {
      var thisCourse = _db.Courses.FirstOrDefault(courses => courses.CourseId == id);
      ViewBag.StudentId = new SelectList(_db.Students, "StudentId", "Name");
      return View(thisCourse);
    }
    [HttpPost]
    public ActionResult AddStudent(Course course, int StudentId)
    {
      if(StudentId != 0)
      {
        _db.StudentsCourses.Add(new StudentCourse() {StudentId = StudentId, CourseId = course.CourseId});
      }
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    [HttpPost]
    public ActionResult DeleteStudent(int joinId)
    {
      var joinEntry = _db.StudentsCourses.FirstOrDefault(entry => entry.StudentCourseId ==joinId);
      _db.StudentsCourses.Remove(joinEntry);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult AddDepartment(int id)
    {
      var thisCourse = _db.Courses.FirstOrDefault(courses => courses.CourseId == id);
      ViewBag.DepartmentId = new SelectList(_db.Departments, "DepartmentId", "Name");
      return View(thisCourse);
    }
    [HttpPost]
    public ActionResult AddDepartment(Course course, int DepartmentId)
    {
      if(DepartmentId != 0)
      {
        _db.CoursesDepartments.Add(new CourseDepartment() {DepartmentId = DepartmentId, CourseId = course.CourseId});
      }
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    [HttpPost]
    public ActionResult DeleteDepartment(int joinId)
    {
      var joinEntry = _db.CoursesDepartments.FirstOrDefault(entry => entry.CourseDepartmentId ==joinId);
      _db.CoursesDepartments.Remove(joinEntry);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Delete(int id)
    {
      var thisCourse = _db.Courses.FirstOrDefault(courses => courses.CourseId == id);
      return View(thisCourse);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      var thisCourse = _db.Courses.FirstOrDefault(courses => courses.CourseId == id);
      _db.Courses.Remove(thisCourse);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
  }
}