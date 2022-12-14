using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CursoMVC.Models;
using CursoMVC.Models.ViewModels;
using CursoMVC.Models.TablesViewModels;

namespace CursoMVC.Controllers
{
    public class AlumnoController : Controller
    {
        // GET: Alumno
        public ActionResult Index()
        {
            List<CursoMVC.Models.TablesViewModels.AlumnoTableViewModel> lst = null;
            using (modelo_dual_aspEntities bd = new modelo_dual_aspEntities())
            {
                lst = (from d in bd.alumnos_dual
                       orderby d.Matricula
                       select new AlumnoTableViewModel
                       {
                           Id = d.IdAlumno,
                           Matricula = d.Matricula,
                           Nombre = d.Nombre_Alumno,
                           Apellido = d.Apellido_Alumno,
                           FechaN = d.Fecha_Nacimiento_Alumno
                       }).ToList();

            }
            return View(lst);
        }
        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Add(AlumnoViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            using (var bd = new modelo_dual_aspEntities())
            {
                alumnos_dual al = new alumnos_dual();
                al.Matricula = model.matricula;
                al.Nombre_Alumno = model.nombre;
                al.Apellido_Alumno = model.apellido;
                al.Fecha_Nacimiento_Alumno = model.fechan;

                bd.alumnos_dual.Add(al);
                bd.SaveChanges();

              
            }
            return Redirect(Url.Content("~/Alumno/Index"));
        }
        public ActionResult editar(int id)
        {
            AlumnoViewModel model = new AlumnoViewModel();
            using (var bd = new modelo_dual_aspEntities())
            {
                var oalumno = bd.alumnos_dual.Find(id);
                model.Id = oalumno.IdAlumno;
                model.matricula = oalumno.Matricula;
                model.nombre = oalumno.Nombre_Alumno;
                model.apellido = oalumno.Apellido_Alumno;
                model.fechan = oalumno.Fecha_Nacimiento_Alumno;
            }

            return View(model);
        }

        [HttpPost]
        public ActionResult editar(AlumnoViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            using (var bd = new modelo_dual_aspEntities())
            {
                var oalumno = bd.alumnos_dual.Find(model.Id);
                oalumno.Matricula = model.matricula;
                oalumno.Nombre_Alumno = model.nombre;
                oalumno.Apellido_Alumno = model.apellido;
                oalumno.Fecha_Nacimiento_Alumno = model.fechan;

                bd.Entry(oalumno).State = System.Data.Entity.EntityState.Modified;
                bd.SaveChanges();
            }
            return Redirect(Url.Content("~/Alumno/Index"));
        }

        [HttpPost]
        public ActionResult borrar(int id)
        {
            using (var bd = new modelo_dual_aspEntities())
            {
                var oalumno = bd.alumnos_dual.Find(id);
                //bd.alumnos_dual.Remove(oalumno);

                bd.Entry(oalumno).State = System.Data.Entity.EntityState.Deleted;
                bd.SaveChanges();
            }

            return Content("1");
        }
    }
}