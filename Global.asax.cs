using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using UserManagement.Business.CrossCuttingConcern.DependencyInjection.Ninject;

namespace UserManagement
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            ControllerBuilder.Current.SetControllerFactory(new NinjectControllerFactory());
        }
        protected void Session_Start()
        {
            Session.Timeout = 365;
            //if (Application["ActiveUser"] == null)
            //{
            //    int counter = 1;
            //    Application["ActiveUser"] = counter;
            //}
            //else
            //{
            //    int counter = (int)Application["ActiveUser"];
            //    counter++;
            //    Application["ActiveUser"] = counter;
            //}

            //if (Application["TotalUser"] == null)
            //{
            //    int counter = 1;
            //    Application["TotalUser"] = counter;
            //}
            //else
            //{
            //    int counter = (int)Application["TotalUser"];
            //    counter++;
            //    Application["TotalUser"] = counter;
            //}
        }
        protected void Session_End()
        {
            //int counter = (int)Application["ActiveUser"];
            //counter--;
            //Application["TotalUser"] = counter;
        }
    }
}
