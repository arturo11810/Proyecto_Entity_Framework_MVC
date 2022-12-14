using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CursoMVC.Models.TablesViewModels
{
    public class ProyectoTableViewModel
    {
        private int id;
        private string nombre;
        private DateTime fechainicio;
        private DateTime fechafin;

        public int Id { get => id; set => id = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public DateTime Fechainicio { get => fechainicio; set => fechainicio = value; }
        public DateTime Fechafin { get => fechafin; set => fechafin = value; }
    }
}