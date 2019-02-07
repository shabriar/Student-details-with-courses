using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StudentPortal.Models
{
    public class Student
    {
        [Key]
        public int Id { get; set; }

        public string StudentName { get; set; }
        public int StudentRoll { get; set; }
        public string StudentDeprtment { get; set; }
        public int StudentBatch { get; set; }

        public virtual ICollection<StudentWithCourses> StudentWithCourses { get; set; }
    }
}