using Students.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace Students.Controllers
{
    public class StudentController : Controller
    {

        // GET: Student
        public ActionResult listastudenata()
        {

            List<Models.Student> studentList = new List<Models.Student>();

            studentList.Add(new Models.Student { StudentName = "John", Age = 23 });
            studentList.Add(new Models.Student { StudentName = "David", Age = 23 });
            return View(studentList);
        }


        public ActionResult edit()
        {

            var id = Request.QueryString["id"];

            return View();

   
           
        }

        public ActionResult edit1()
        {


            var name = Request["Name"];
            var age = Request["Age"];


            return RedirectToAction("listastudenata"); // ovde je bilo "Index"
        }
        
    }   
}