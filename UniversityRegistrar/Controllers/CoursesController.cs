using Microsoft.AspNetCore.Mvc;
using UniversityRegistrar.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace UniversityRegistrar.Controllers
{
  public class CoursesController : Controller
  {
    private readonly UniversityRegistrarContext _db;

    public  CoursesController(UniversityRegistrarContext db)
    {
      _db = db;
    } 

    public ActionResult Index()
    {
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