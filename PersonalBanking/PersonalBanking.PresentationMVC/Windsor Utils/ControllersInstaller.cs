using System.Web.Mvc;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

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
         container.Register(FindControllers().LifestyleSingleton());
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