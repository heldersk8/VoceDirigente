using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ODirigente.Startup))]
namespace ODirigente
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
