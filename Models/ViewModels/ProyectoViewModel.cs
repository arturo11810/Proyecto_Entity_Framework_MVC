using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CursoMVC.Models.ViewModels
{
    public class ProyectoViewModel
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Nombre:")]
        public string nombre { get; set; }

        [Required]
        [Display(Name = "Fecha de inicio:")]
        public DateTime fechainicio { get; set; }

        [Required]
        [Display(Name = "Fecha de finalización:")]
        public DateTime fechafin { get; set; }
    }
}