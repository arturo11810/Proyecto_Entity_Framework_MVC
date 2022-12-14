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
    public class ProyectoController : Controller
    {
        // GET: Alumno
        public ActionResult Index()
        {
            List<CursoMVC.Models.TablesViewModels.ProyectoTableViewModel> lst = null;
            using (modelo_dual_aspEntities bd = new modelo_dual_aspEntities())
            {
                lst = (from d in bd.Proyecto
                       orderby d.Id
                       select new ProyectoTableViewModel
                       {
                           Id=d.Id,
                           Nombre = d.Nombre,
                           Fechainicio = d.Fecha_Inicio,
                           Fechafin = d.Fecha_Fin
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
        public ActionResult Add(ProyectoViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            using (var bd = new modelo_dual_aspEntities())
            {
                Proyecto al = new Proyecto();
                al.Nombre = model.nombre;
                al.Fecha_Inicio = model.fechainicio;
                al.Fecha_Fin = model.fechafin;

                bd.Proyecto.Add(al);
                bd.SaveChanges();


            }
            return Redirect(Url.Content("~/Proyecto/Index"));
        }
        public ActionResult editar(int id)
        {
            ProyectoViewModel model = new ProyectoViewModel();
            using (var bd = new modelo_dual_aspEntities())
            {
                var oProyecto = bd.Proyecto.Find(id);
                model.Id = oProyecto.Id;
                model.nombre = oProyecto.Nombre;
                model.fechainicio = oProyecto.Fecha_Inicio;
                model.fechafin = oProyecto.Fecha_Fin;
            }

            return View(model);
        }

        [HttpPost]
        public ActionResult editar(ProyectoViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            using (var bd = new modelo_dual_aspEntities())
            {
                var oproyecto = bd.Proyecto.Find(model.Id);
                oproyecto.Nombre = model.nombre;
                oproyecto.Fecha_Inicio = model.fechainicio;
                oproyecto.Fecha_Fin = model.fechafin;

                bd.Entry(oproyecto).State = System.Data.Entity.EntityState.Modified;
                bd.SaveChanges();
            }

            return Redirect(Url.Content("~/Proyecto/Index"));
        }


        [HttpPost]
        public ActionResult borrar(int id)
        {
            using (var bd = new modelo_dual_aspEntities())
            {
                var oproyecto = bd.Proyecto.Find(id);
                //bd.alumnos_dual.Remove(oalumno);

                bd.Entry(oproyecto).State = System.Data.Entity.EntityState.Deleted;
                bd.SaveChanges();
            }

            return Content("1");
        }

        




        public ActionResult admAlumnos(int id)
        {
            List<CursoMVC.Models.TablesViewModels.AlumnoxProyectoTableViewModel> lst = null;
            using (modelo_dual_aspEntities bd = new modelo_dual_aspEntities())
            {
                lst = (from d in bd.AlumnoXProyecto join a in bd.alumnos_dual on d.Id_Alumno equals a.IdAlumno where d.Id_Proyecto==id
                       
                       orderby d.Id

                       select new AlumnoxProyectoTableViewModel
                       {
                           Id = d.Id,
                           Id_alumno = d.Id_Alumno,
                           Nombre=a.Nombre_Alumno,
                           Id_proyecto = d.Id_Proyecto
                       }).ToList();

            }
            return View(lst);
        }

        [HttpPost]
        public ActionResult borrarAXP(int id)
        {
            using (var bd = new modelo_dual_aspEntities())
            {
                var oproyecto = bd.AlumnoXProyecto.Find(id);
                //bd.alumnos_dual.Remove(oalumno);

                bd.Entry(oproyecto).State = System.Data.Entity.EntityState.Deleted;
                bd.SaveChanges();
            }

            return Content("1");
        }


        public ActionResult admAsesores(int id)
        {
            List<CursoMVC.Models.TablesViewModels.AsesoresXProyectoTableViewModel> lst = null;
            using (modelo_dual_aspEntities bd = new modelo_dual_aspEntities())
            {
                lst = (from d in bd.AsesorXProyecto
                       join a in bd.Asesores_dual on d.Id_Asesor equals a.IdAsesor
                       where d.Id_Proyecto == id

                       orderby d.Id

                       select new AsesoresXProyectoTableViewModel
                       {
                           Id = d.Id,
                           Id_asesor = d.Id_Asesor,
                           Nombre = a.Nombre_Asesor,
                           Id_proyecto = d.Id_Proyecto
                       }).ToList();

            }
            return View(lst);
        }

        [HttpPost]
        public ActionResult borrarAsXP(int id)
        {
            using (var bd = new modelo_dual_aspEntities())
            {
                var oproyecto = bd.AsesorXProyecto.Find(id);
                //bd.alumnos_dual.Remove(oalumno);

                bd.Entry(oproyecto).State = System.Data.Entity.EntityState.Deleted;
                bd.SaveChanges();
            }

            return Content("1");
        }
    }
}