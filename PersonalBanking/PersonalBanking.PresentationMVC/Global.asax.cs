using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Castle.Windsor;
using Castle.Windsor.Installer;
using PersonalBanking.PresentationMVC.Windsor_Utils;
using PersonalBanking.Infrastructure;

namespace PersonalBanking.PresentationMVC
{
    public class MvcApplication : System.Web.HttpApplication
    {

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            var container = new WindsorContainer().Install(FromAssembly.This());
            IoC.RegisterAll(container.Kernel);
            
            ControllerBuilder.Current.SetControllerFactory(new WindsorControllerFactory(container.Kernel));
        }

    }


}
