using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;


namespace Students
{
    public partial class Student_PelkaMODEL
    {

        public int ID_studenta { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Adresa { get; set; }
        public string Telefon { get; set; }


      //  [DataType(DataType.Date)]
       // [DisplayFormat(DataFormatString = "0:dd-mm-yyyy", ApplyFormatInEditMode = true)]
        public string Datum_rodjenja { get; set; }
    }
}