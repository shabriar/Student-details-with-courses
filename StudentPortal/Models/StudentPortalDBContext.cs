using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace StudentPortal.Models
{
    public class StudentPortalDBContext:DbContext
    {
        public StudentPortalDBContext()
            : base("StudentPortalConnString")
        {

        }
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<StudentWithCourses> StudentWithCourses { get; set; }
    }
}