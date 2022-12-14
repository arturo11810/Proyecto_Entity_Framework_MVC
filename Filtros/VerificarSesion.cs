using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CursoMVC.Controllers;
using CursoMVC.Models;

namespace CursoMVC.Filtros
{
    public class VerificarSesion: ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            //var oUser = (Usuario)HttpContext.Current.Session["user"];
            var oUser = 1;
            if (oUser==null)//si no hay sesion
            {
                if(filterContext.Controller is AccesoController == false)//si la direccion que se intenta cargar no es el login
                {
                    filterContext.HttpContext.Response.Redirect("~/Acceso/Index");
                }
            }
            else
            {
                if (filterContext.Controller is AccesoController == true)//si la direccion que se intenta cargar no es el login
                {
                    filterContext.HttpContext.Response.Redirect("~/Home/Index");
                }
            }

            base.OnActionExecuting(filterContext);
        }
    }
}