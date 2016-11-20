using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(EPM.Startup))]
namespace EPM
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
