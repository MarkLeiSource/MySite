using MyDataFX;
using System;
using System.Web.Http;
using System.Web.Mvc;

namespace MyAliSite
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            GlobalConfiguration.Configure(WebApiConfig.Register);
            //BundleConfig.RegisterBundles(BundleTable.Bundles);
            DBContextSetup.Setup();
            ContainerSetup.Setup();
        }

        protected void Application_End()
        {
            var container = AppDomain.CurrentDomain.GetData("Container");
            if (container != null)
            {
                ((IDisposable)container).Dispose();
            }
        }
    }
}
