using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(EjemploMVC.Startup))]
namespace EjemploMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
