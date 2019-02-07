using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StudentPortal.Models
{
    public class Course
    {
        [Key]
        public int Id { get; set; }

        public string CourseName { get; set; }
        public string CourseCode { get; set; }

        public virtual ICollection<StudentWithCourses> StudentWithCourses{get; set;}

    }
}