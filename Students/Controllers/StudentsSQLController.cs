using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using Students.Models;
using System.Data.Entity;
using System.Globalization;

namespace Students.Controllers
{
    public class StudentsSQLController : Controller

    {
        public Praksa_Nov_2019Entities db = new Praksa_Nov_2019Entities();

        // GET: StudentsSQL
       

        public ActionResult Index(string searchby, string search)
        {

            if (search == null)
            {
                using (db)
                {
                    var studentlist = db.Student_Pelka.OrderBy(s => s.Ime).ToList();
                    return View(studentlist);
                }

            } else if (search == "Name") {

                return View(db.Student_Pelka.Where(s => s.Ime == search || search == null).ToList());
            } else {

               return View(db.Student_Pelka.Where(s => s.Ime.StartsWith(search) || search == null).ToList());

            } 

     
        }


        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public JsonResult Create (Student_PelkaMODEL student)
        {
            //if (ModelState.IsValid)
            // {
            var model = new Student_Pelka();
            model.Adresa = student.Adresa;
            model.Datum_rodjenja = DateTime.ParseExact(student.Datum_rodjenja, "MM/dd/yyyy", CultureInfo.InvariantCulture);
            model.Ime = student.Ime;
            model.Prezime = student.Prezime;
            model.Telefon = student.Telefon;
            model.ID_studenta = student.ID_studenta;

             db.Student_Pelka.Add(model);
             db.SaveChanges();
            return Json("OK");

          

        }

        [HttpGet]

        public ActionResult Edit ( int id) 
        {
                Praksa_Nov_2019Entities db = new Praksa_Nov_2019Entities();
                Student_Pelka student = db.Student_Pelka.Where(s => s.ID_studenta == id).SingleOrDefault();
                return View(student);
           
        }

        [HttpPost]
        public ActionResult Edit(Student_Pelka student)
        {
            if (ModelState.IsValid)
            {
                using (db)
                { 

                    var studenUpdate = db.Student_Pelka.Where(s => s.ID_studenta == student.ID_studenta).SingleOrDefault();

                    studenUpdate.Ime = student.Ime;
                    studenUpdate.Prezime = student.Prezime;
                    studenUpdate.Adresa = student.Adresa;
                    studenUpdate.Telefon = student.Telefon;
                    studenUpdate.Datum_rodjenja = student.Datum_rodjenja;
                    db.SaveChanges();
                    
                }
                return RedirectToAction("Index");
               

            }return View(student);
        }



        public ActionResult Details (int id)
        {

            Praksa_Nov_2019Entities db = new Praksa_Nov_2019Entities();

            var student = db.Student_Pelka.SingleOrDefault(s => s.ID_studenta == id);


            return View(student);
   
        }



        public ActionResult Delete (string id)
        {
            int studentId = Convert.ToInt32(id);
            using (db)
            {
                var deleteStudent = db.Student_Pelka.Where(s => s.ID_studenta == studentId).FirstOrDefault();
                return View(deleteStudent);
            }

        }

        [HttpPost]
        public ActionResult Delete (int id)
        {
            using (db)
            {

              
                db.Student_Pelka.Remove(db.Student_Pelka.Find(id));
                db.SaveChanges();
               
                
            } return RedirectToAction("Index");


        } 

    }
}