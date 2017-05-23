using System.Web.Mvc;
using System.Web.Routing;
using Castle.Windsor;
using Castle.Windsor.Installer;
using PersonalBanking.PresentationMVC.Windsor_Utils;
using PersonalBanking.Infrastructure;
using PersonalBanking.PresentationMVC.Mapping;

namespace PersonalBanking.PresentationMVC
{
    public class MvcApplication : System.Web.HttpApplication
    {

        protected void Application_Start()
        {
            HtmlHelper.ClientValidationEnabled = true;
            HtmlHelper.UnobtrusiveJavaScriptEnabled = true;

            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            var container = new WindsorContainer().Install(FromAssembly.This());
            var ioc = new IoC("PersonalBankingW");
            ioc.RegisterAll(container.Kernel);
            ControllerBuilder.Current.SetControllerFactory(new WindsorControllerFactory(container.Kernel));

            ControllerBuilder.Current.SetControllerFactory(new WindsorControllerFactory(container.Kernel));

            AutoMapper.Mapper.Initialize(c =>
            {
                //c.CreateMap<User, UserDTO>();
                c.AddProfile(typeof(PresentationMapping));
                c.AddProfile(typeof(BLL.Mapping));
            });
        }

    }


}
