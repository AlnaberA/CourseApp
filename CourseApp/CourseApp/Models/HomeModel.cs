using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CourseApp.Models
{
    public class HomeModel
    {
        public List<CourseApp.Student> Students { get; set; }
        public List<CourseApp.Course> Courses{ get; set; }
        public List<CourseApp.StudentXCourse> StudentsAssignedCourses { get; set; }
    }
}