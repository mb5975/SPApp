using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SPApp.Startup))]
namespace SPApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
