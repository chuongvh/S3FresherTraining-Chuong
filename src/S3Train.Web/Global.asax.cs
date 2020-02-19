using System.Security.Claims;
using System.Web.Helpers;
using S3Train.App_Start;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace S3Train
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            DependencyConfig.RegisterDependencyResolvers();

            IViewEngine razorEngine = new RazorViewEngine()
            {
                FileExtensions = new[] { "cshtml" }
            };

            ViewEngines.Engines.Add(razorEngine);

            AntiForgeryConfig.UniqueClaimTypeIdentifier = ClaimTypes.NameIdentifier;

            MvcHandler.DisableMvcResponseHeader = true;
        }
    }
}
