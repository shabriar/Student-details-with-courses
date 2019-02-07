using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace StudentPortal.Models
{
    public class StudentWithCourses
    {
        [Key]
        public int Id { get; set; }

        public int? StudentId { get; set; }
        [ForeignKey("StudentId")]
        public virtual Student Students { get; set; }

        public int? CourseId { get; set; }
        [ForeignKey("CourseId")]
        public virtual Course Courses { get; set; }
    }
}