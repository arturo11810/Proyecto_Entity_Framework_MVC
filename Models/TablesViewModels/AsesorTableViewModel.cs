using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CursoMVC.Models.TablesViewModels
{
    public class AsesorTableViewModel
    {
        private int id;
        private int nss;
        private string nombre;
        private string apellido;
        private DateTime fechaN;

        public int Id { get => id; set => id = value; }
        public int Nss { get => nss; set => nss = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Apellido { get => apellido; set => apellido = value; }
        public DateTime FechaN { get => fechaN; set => fechaN = value; }
    }
}