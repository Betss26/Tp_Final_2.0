//------------------------------------------------------------------------------
// <auto-generated>
//    Este código se generó a partir de una plantilla.
//
//    Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//    Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Final_Master_Page.Datos
{
    using System;
    using System.Collections.Generic;
    
    public partial class Estudiante
    {
        public int Id { get; set; }
        public string name { get; set; }
        public Nullable<int> age { get; set; }
        public int userid { get; set; }
        public string doctype { get; set; }
        public string lastname { get; set; }
        public string docnumber { get; set; }
        public string phone { get; set; }
        public Nullable<System.DateTime> created { get; set; }
        public string birthdate { get; set; }
        public string status { get; set; }
        public string address { get; set; }
        public Nullable<int> subjectQuantity { get; set; }
        public string numberFile { get; set; }
    
        public virtual Documento_Tipo Documento_Tipo { get; set; }
        public virtual Usuario Usuario { get; set; }
    }
}
