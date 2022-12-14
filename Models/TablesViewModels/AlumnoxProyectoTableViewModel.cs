using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CursoMVC.Models.TablesViewModels
{
    public class AlumnoxProyectoTableViewModel
    {
        private int id;
        private int id_alumno;
        private string nombre;
        private int id_proyecto;

        public int Id { get => id; set => id = value; }
        public int Id_alumno { get => id_alumno; set => id_alumno = value; }
        public int Id_proyecto { get => id_proyecto; set => id_proyecto = value; }
        public string Nombre { get => nombre; set => nombre = value; }
    }
}