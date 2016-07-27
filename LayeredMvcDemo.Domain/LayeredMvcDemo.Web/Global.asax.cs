using LayeredMvcDemo.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace LayeredMvcDemo.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            //把MVC框架的預設controller factory換掉
           // var ctrlFactory = new MyControllerFactory();
            //SetControllerFactory 方法就是屬性注入（Property Injection)
            //ControllerBuilder.Current.SetControllerFactory(ctrlFactory);

            var myResolver = new MyDependencyResolver();
            DependencyResolver.SetResolver(myResolver);
        }

        protected void Application_BeginRequest() 
        {
            HttpContext.Current.Items["DbContext"] = new SouthwindContext();
        }

        protected void Application_EndRequest() 
        {
            var db = HttpContext.Current.Items["DbContext"] as SouthwindContext;
            if (db != null) 
            {
                db.Dispose();
            }
        }
    }
}
