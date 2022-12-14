using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace CursoMVC.Models.ViewModels
{
    public class AsesorViewModel
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Nss:")]
        //[StringLength(10,ErrorMessage ="La longitud no puede ser mayor a 10")]
        public int nss { get; set; }
        [Required]
        [Display(Name = "Nombre:")]
        public string nombre { get; set; }
        [Required]
        [Display(Name = "Apellidos:")]
        public string apellido { get; set; }
        [Required]
        [Display(Name = "Fecha de nacimiento:")]
        public DateTime fechan { get; set; }
    }
}