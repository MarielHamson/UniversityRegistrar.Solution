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
      return View();
    }

    [HttpPost]
    public ActionResult Create(Course course)
    {
      _db.Courses.Add(course);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Details(int id)
    {
      Course thisCourse = _db.Courses
        .Include(course => course.Students)
        .ThenInclude(join => join.Student)
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
        _db.StudentCourse.Add(new StudentCourse() {StudentId = StudentId, CourseId = course.CourseId});
      }
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

    [HttpPost]
    public ActionResult DeleteStudent(int joinId)
    {
      var joinEntry = _db.StudentCourse.FirstOrDefault(entry => entry.StudentCourseId ==joinId);
      _db.StudentCourse.Remove(joinEntry);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
  }
}