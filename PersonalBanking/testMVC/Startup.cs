using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(testMVC.Startup))]
namespace testMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
