using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(RVAS_Kosarka.Startup))]
namespace RVAS_Kosarka
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
