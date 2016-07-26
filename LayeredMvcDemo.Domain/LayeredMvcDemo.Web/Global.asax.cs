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
            var ctrlFactory = new MyControllerFactory();
            //SetControllerFactory 方法就是屬性注入（Property Injection)
            ControllerBuilder.Current.SetControllerFactory(ctrlFactory);
        }
    }
}
