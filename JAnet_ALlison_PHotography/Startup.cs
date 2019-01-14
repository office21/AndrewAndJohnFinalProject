using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(JAnet_ALlison_PHotography.Startup))]
namespace JAnet_ALlison_PHotography
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
