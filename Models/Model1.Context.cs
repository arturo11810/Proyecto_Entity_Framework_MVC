﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CursoMVC.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class modelo_dual_aspEntities : DbContext
    {
        public modelo_dual_aspEntities()
            : base("name=modelo_dual_aspEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<alumnos_dual> alumnos_dual { get; set; }
        public virtual DbSet<AlumnoXProyecto> AlumnoXProyecto { get; set; }
        public virtual DbSet<Asesores_dual> Asesores_dual { get; set; }
        public virtual DbSet<AsesorXProyecto> AsesorXProyecto { get; set; }
        public virtual DbSet<Estado> Estado { get; set; }
        public virtual DbSet<Proyecto> Proyecto { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }
    }
}