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
    
    public partial class Materia
    {
        public int ID { get; set; }
        public string Nombre { get; set; }
        public int IDMaestro { get; set; }
    
        public virtual Maestro Maestro { get; set; }
    }
}
