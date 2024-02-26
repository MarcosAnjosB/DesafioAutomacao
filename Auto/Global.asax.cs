using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Auto
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            //Inserção da classe Bootstrapper e método Initialize para setar as configurações iniciais do projeto
            Bootstrapper.Initialize();
        }
    }
}
