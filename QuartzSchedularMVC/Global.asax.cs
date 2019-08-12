using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using QuartzSchedularMVC.Models;

namespace QuartzSchedularMVC
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            //The Schedular Class
            SchedulerService.StartAsync().GetAwaiter().GetResult();
        }
    }
}
