//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Students.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class UpisStudenataNaPredmet_Pelka
    {
        public int ID_studenta { get; set; }
        public int ID_predavanja { get; set; }
        public Nullable<int> Ocjena { get; set; }
    
        public virtual Student_Pelka Student_Pelka { get; set; }
    }
}