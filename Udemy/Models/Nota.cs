//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Udemy.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Nota
    {
        public int ID { get; set; }
        public int IDAlumno { get; set; }
        public int IDMateria { get; set; }
        public int Nota1 { get; set; }
        public int Nota2 { get; set; }
    
        public virtual Alumno Alumno { get; set; }
        public virtual Materia Materia { get; set; }
    }
}
