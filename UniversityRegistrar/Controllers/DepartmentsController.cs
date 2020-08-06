using Microsoft.AspNetCore.Mvc;
using UniversityRegistrar.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace UniversityRegistrar.Controllers
{
  public class DepartmentsController : Controller
  {
    private readonly UniversityRegistrarContext _db;

    public  DepartmentsController(UniversityRegistrarContext db)
    {
      _db = db;
    }

    public ActionResult Index(string searchDepartment)
    {
      if(!string.IsNullOrEmpty(searchDepartment))
      {
        var searchDepartments = _db.Departments.Where(departments => departments.Name.Contains(searchDepartment)).ToList();                    
        return View(searchDepartments);
      }
      return View(_db.Departments.ToList());
    }

    public ActionResult Create()
    {
      return View();
    }

    [HttpPost]
    public ActionResult Create(Department department)
    {
      _db.Departments.Add(department);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
    
    public ActionResult Details(int id)
    {
      var thisDepartment = _db.Departments.FirstOrDefault(department => department.DepartmentId ==id);
      return View(thisDepartment);
    }

    public ActionResult CoursesList(int id)
    {
      var thisDepartment = _db.Departments
                          .Include(department => department.Courses)
                          .ThenInclude(join => join.Course)
                          .FirstOrDefault(department => department.DepartmentId ==id);
      return View(thisDepartment);
    }

    /*[HttpPost]
    public ActionResult DeleteCourse(int joinId)
    {
      var joinEntry = _db.CoursesDepartments.FirstOrDefault(entry => entry.CourseDepartmentId ==joinId);
      _db.CoursesDepartments.Remove(joinEntry);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }*/

    public ActionResult StudentsList(int id)
    {
      var thisDepartment = _db.Departments
                          .Include(department => department.Students)
                          .FirstOrDefault(department => department.DepartmentId ==id);
      return View(thisDepartment);
    }

    /*[HttpPost]
    public ActionResult DeleteStudent(int studentId)
    {
      var joinEntry = _db.CoursesDepartments.FirstOrDefault(entry => entry.CourseDepartmentId ==joinId);
      _db.CoursesDepartments.Remove(joinEntry);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }*/
    public ActionResult Edit(int id)
    {
      var thisDepartment = _db.Departments.FirstOrDefault(department => department.DepartmentId ==id);
      return View(thisDepartment);
    }

    [HttpPost]
    public ActionResult Edit(Department department)
    {
      _db.Entry(department).State = EntityState.Modified;
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
    
    public ActionResult Delete(int id)
    {
      var thisDepartment = _db.Departments.FirstOrDefault(department => department.DepartmentId ==id);
      return View(thisDepartment);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      var thisDepartment = _db.Departments.FirstOrDefault(department => department.DepartmentId ==id);
      _db.Departments.Remove(thisDepartment);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
  }
}