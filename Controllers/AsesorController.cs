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
    public class AsesorController : Controller
    {
        // GET: Alumno
        public ActionResult Index()
        {
            List<CursoMVC.Models.TablesViewModels.AsesorTableViewModel> lst = null;
            using (modelo_dual_aspEntities bd = new modelo_dual_aspEntities())
            {
                lst = (from d in bd.Asesores_dual
                       orderby d.NSS
                       select new AsesorTableViewModel
                       {
                           Id = d.IdAsesor,
                           Nss = d.NSS,
                           Nombre = d.Nombre_Asesor,
                           Apellido = d.Apellido_Asesor,
                           FechaN = d.Fecha_Nacimiento_Asesor
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
        public ActionResult Add(AsesorViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            using (var bd = new modelo_dual_aspEntities())
            {
                Asesores_dual al = new Asesores_dual();
                al.NSS = model.nss;
                al.Nombre_Asesor = model.nombre;
                al.Apellido_Asesor = model.apellido;
                al.Fecha_Nacimiento_Asesor = model.fechan;

                bd.Asesores_dual.Add(al);
                bd.SaveChanges();


            }
            return Redirect(Url.Content("~/Asesor/Index"));
        }
        public ActionResult editar(int id)
        {
            AsesorViewModel model = new AsesorViewModel();
            using (var bd = new modelo_dual_aspEntities())
            {
                var oasesor = bd.Asesores_dual.Find(id);
                model.Id = oasesor.IdAsesor;
                model.nss = oasesor.NSS;
                model.nombre = oasesor.Nombre_Asesor;
                model.apellido = oasesor.Apellido_Asesor;
                model.fechan = oasesor.Fecha_Nacimiento_Asesor;
            }

            return View(model);
        }

        [HttpPost]
        public ActionResult editar(AsesorViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            using (var bd = new modelo_dual_aspEntities())
            {
                var oasesor = bd.Asesores_dual.Find(model.Id);
                oasesor.NSS = model.nss;
                oasesor.Nombre_Asesor = model.nombre;
                oasesor.Apellido_Asesor = model.apellido;
                oasesor.Fecha_Nacimiento_Asesor = model.fechan;

                bd.Entry(oasesor).State = System.Data.Entity.EntityState.Modified;
                bd.SaveChanges();
            }

            return Redirect(Url.Content("~/Asesor/Index"));
        }


        [HttpPost]
        public ActionResult borrar(int id)
        {
            using (var bd = new modelo_dual_aspEntities())
            {
                var oasesor = bd.Asesores_dual.Find(id);
                //bd.alumnos_dual.Remove(oalumno);

                bd.Entry(oasesor).State = System.Data.Entity.EntityState.Deleted;
                bd.SaveChanges();
            }

            return Content("1");
        }
    }
}