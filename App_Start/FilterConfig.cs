using System.Web;
using System.Web.Mvc;

namespace CursoMVC
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new Filtros.VerificarSesion());//siempre que se intente cargar una pagina del sitio verificara e filtro
        }
    }
}
