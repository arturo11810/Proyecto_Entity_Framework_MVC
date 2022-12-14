using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CursoMVC.Models.TablesViewModels
{
    public class AsesoresXProyectoTableViewModel
    {
        private int id;
        private int id_asesor;
        private string nombre;
        private int id_proyecto;

        public int Id { get => id; set => id = value; }
        public int Id_asesor { get => id_asesor; set => id_asesor = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public int Id_proyecto { get => id_proyecto; set => id_proyecto = value; }
    }
}