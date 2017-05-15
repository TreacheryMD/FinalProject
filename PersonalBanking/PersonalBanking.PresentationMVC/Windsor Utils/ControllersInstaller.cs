using System.Web.Mvc;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using AutoMapper;
using PersonalBanking.BLL;

namespace PersonalBanking.PresentationMVC.Windsor_Utils
{
    public class ControllersInstaller : IWindsorInstaller
   {
      #region IWindsorInstaller Members

      /// <summary>
      /// Installation configuration
      /// </summary>
      /// <param name="container"></param>
      /// <param name="store"></param>
      public void Install(IWindsorContainer container, IConfigurationStore store)
      {
          var mapperConfig = new MapperConfiguration(config => { config.AddProfile<Mapping>();});
          mapperConfig.AssertConfigurationIsValid();
          container.Register(Component.For<IMapper>().Instance(mapperConfig.CreateMapper()).LifestyleSingleton());

            container.Register(FindControllers().LifestyleTransient());
      }

      #endregion

      #region Non-public static members

      /// <summary>
      /// Find Controller classes
      /// </summary>
      /// <returns></returns>
      private static BasedOnDescriptor FindControllers()
      {
         return Classes.FromThisAssembly().BasedOn<IController>()
                       .If(t => t.Name.EndsWith("Controller"));
      }

      #endregion
   }
}