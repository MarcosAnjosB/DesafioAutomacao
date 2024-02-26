using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Auto
{
    public class RouteConfig
    {
        //Método responsável por "criar" a rota padrão quando o projeto iniciar
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "AutomationWithSelenium", id = UrlParameter.Optional }
            );
        }
    }
}
