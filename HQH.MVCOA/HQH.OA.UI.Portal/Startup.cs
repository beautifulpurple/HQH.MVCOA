using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(HQH.OA.UI.Portal.Startup))]
namespace HQH.OA.UI.Portal
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
