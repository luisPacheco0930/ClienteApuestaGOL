using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebApuestasCliente.Startup))]
namespace WebApuestasCliente
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
