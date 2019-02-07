using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace StudentPortal.Models
{
    [NotMapped]
    public class CourseIdWithCourses : Student
    {
        public List<int> CourseIdList { get; set; }
    }
}