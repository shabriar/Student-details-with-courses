using StudentPortal.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StudentPortal.Controllers
{
    public class StudentController : Controller
    {
        StudentPortalDBContext context = new StudentPortalDBContext();
        // GET: Student
        public ActionResult Index()
        {
            ViewBag.CourseList = context.Courses.ToList();
            return View();
        }

        [HttpPost]
        public ActionResult Index(CourseIdWithCourses student)
        {
            var StudentWithCourses = new Student()
            {
                StudentName = student.StudentName,
                StudentRoll = student.StudentRoll,
                StudentBatch = student.StudentBatch,
                StudentDeprtment = student.StudentDeprtment

            };
            context.Students.Add(StudentWithCourses);
            context.SaveChanges();
            foreach (var item in student.CourseIdList)
            {
                var newStudentCourse = new StudentWithCourses()
                {
                    StudentId = StudentWithCourses.Id,
                    CourseId = item,
                };
                context.StudentWithCourses.Add(newStudentCourse);
                context.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult ShowAllStudent()
        {
            var StudentList = context.Students;
            return View(StudentList);
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            var studentDetails = context.Students.Find(id);
            context.Students.Remove(studentDetails);
            context.SaveChanges();
            return RedirectToAction("ShowAllStudent");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var studentDetails = context.Students.Find(id);
            var courseIdwithcourses = new CourseIdWithCourses()
            {
                CourseIdList = studentDetails.StudentWithCourses.Select(x => x.Id).ToList(),
                StudentName=studentDetails.StudentName,
                StudentRoll=studentDetails.StudentRoll,
                StudentDeprtment=studentDetails.StudentDeprtment,
                StudentBatch=studentDetails.StudentBatch,
            };
            ViewBag.CourseIdlistFromController = context.Courses.ToList();
              return View(courseIdwithcourses);
        }
        [HttpPost]
        public ActionResult Edit(CourseIdWithCourses EditedEntry)
        {
            var userEntryFromDB = context.Students.Find(EditedEntry.Id);
            userEntryFromDB.StudentName = EditedEntry.StudentName;
            userEntryFromDB.StudentRoll = EditedEntry.StudentRoll;
            userEntryFromDB.StudentDeprtment = EditedEntry.StudentDeprtment;
            userEntryFromDB.StudentBatch = EditedEntry.StudentBatch;

            context.Entry(userEntryFromDB).State = EntityState.Modified;
            context.SaveChanges();


            foreach(var DeletedItem in userEntryFromDB.StudentWithCourses.ToList())
            {
                context.StudentWithCourses.Remove(DeletedItem);
                context.SaveChanges();
            }


            foreach(var courseId in EditedEntry.CourseIdList)
            {
                var EditedCourses = new StudentWithCourses()
                {
                    CourseId = courseId,
                    StudentId = userEntryFromDB.Id,

                };
                context.StudentWithCourses.Add(EditedCourses);
                context.SaveChanges();
            }

            return RedirectToAction("ShowAllStudent");
        }
        
        
          

          
    }

        
    
}


           
    




    
