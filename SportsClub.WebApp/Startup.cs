using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SportsClub.WebApp.Startup))]
namespace SportsClub.WebApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
