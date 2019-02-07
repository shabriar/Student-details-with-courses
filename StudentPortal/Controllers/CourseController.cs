using StudentPortal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StudentPortal.Controllers
{
    public class CourseController : Controller
    {
        StudentPortalDBContext context = new StudentPortalDBContext();
        // GET: Course
        public ActionResult Index()
        {
            return View(new Course() );
        }
        [HttpPost]
        public ActionResult Index(Course obj)
        {
            context.Courses.Add(obj);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult ShowAllCourses()
        {
            var CourseWithStudents = context.Courses;
            return View(CourseWithStudents);
        }



    }
}