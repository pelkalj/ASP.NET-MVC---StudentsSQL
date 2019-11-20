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

        public ActionResult Create ([Bind(Include = "ID studenta, Ime, Prezime, Adresa, Telefon, DatumRodjenja")] Student_Pelka student)
        {
            if (ModelState.IsValid)
            {

                db.Student_Pelka.Add(student);
                db.SaveChanges();
                return RedirectToAction("Index");

            }
            return View(student);

        }

        [HttpGet]

        public ActionResult Edit ( int id) 
        {
                Praksa_Nov_2019Entities db = new Praksa_Nov_2019Entities();
                Student_Pelka student = db.Student_Pelka.SingleOrDefault(s => s.ID_studenta == id);
                return View(student);
           
        }

        [HttpPost]
        public ActionResult Edit(Student_Pelka student)
        {
            if (ModelState.IsValid)
            {
                using (db)
                { 

                    var student_to_update = db.Student_Pelka.SingleOrDefault(s => s.ID_studenta == student.ID_studenta);

                    student_to_update.Ime = student.Ime;
                    student_to_update.Prezime = student.Prezime;
                    student_to_update.Adresa = student.Adresa;
                    student_to_update.Telefon = student.Telefon;
                    student_to_update.Datum_rodjenja = student.Datum_rodjenja;
                    db.SaveChanges();
                    
                }
                return RedirectToAction("Index");
               

            }return View(student);
        }



        public ActionResult Details (int id)
        {

            Praksa_Nov_2019Entities db = new Praksa_Nov_2019Entities();

            var student = db.Student_Pelka.Single(s => s.ID_studenta == id);


            return View(student);
   
        }



        public ActionResult Delete (int id)
        {

            var deleteStudent = db.Student_Pelka.Find(id);
            return View(deleteStudent);


        }

        [HttpPost]
        public ActionResult Delete (Student_Pelka student)
        {
            using (db)
            {

                var deleteStudent = db.Student_Pelka.Find(student.ID_studenta);
                db.Student_Pelka.Remove(deleteStudent);
                db.SaveChanges();
                return RedirectToAction("Index");
                
            }


        }

    }
}