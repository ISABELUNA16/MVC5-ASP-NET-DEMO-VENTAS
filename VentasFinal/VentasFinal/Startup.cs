using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(VentasFinal.Startup))]
namespace VentasFinal
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
