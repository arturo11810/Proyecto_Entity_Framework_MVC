using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CursoMVC.Models;

namespace CursoMVC.Controllers
{
    public class AccesoController : Controller
    {
        // GET: Acceso
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Entrar(string email, string pass)
        {
            try
            {
                using (modelo_dual_aspEntities db=new modelo_dual_aspEntities())
                {
                    var lst = (from d in db.Usuario
                                join e in db.Estado on d.IdEstado equals e.Id
                                where d.email == email && d.password == pass && d.IdEstado == 1
                                select d);

                    if (lst.Count() > 0)
                    {
                        Session["user"] = lst;
                        return Content("1");
                    }
                    else { return Content("Usuario o contraseña invalidos"); }
                }
                
            }
            catch(Exception ex)
            {
                return Content("Error");
            }
        }
    }
}