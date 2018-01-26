using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CourseApp.Models;

namespace CourseApp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            HomeModel model = new HomeModel();
            
            using(CoursesAppEntities context = new CoursesAppEntities())
            {
                model.Students = context.Students.ToList();
                model.Courses = context.Courses.ToList();
                model.StudentsAssignedCourses = context.StudentXCourses.ToList();
            }
            
            return View(model);
        }
        //id and selected variable name have to match passed variable name if you are to pass a Jsonresult
        public JsonResult AssignStudent(int id, int selected)
        {
            bool success = true;
            string message = "";

            try
            {
                using (CoursesAppEntities context = new CoursesAppEntities())
                {
                    CourseApp.StudentXCourse assignStudentToClass = new CourseApp.StudentXCourse();
                    assignStudentToClass.STUDENT_ID = id;
                    assignStudentToClass.COURSE_ID = selected;

                    context.StudentXCourses.Add(assignStudentToClass);
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                success = false;
                message = e.Message;
            }

            return Json(new { success = success, message = message });
        }

            /*
                    public ActionResult About()
                    {
                        ViewBag.Message = "Your application description page.";

                        return View();
                    }

                    public ActionResult Contact()
                    {
                        ViewBag.Message = "Your contact page.";

                        return View();
                    }
            */
        }
}