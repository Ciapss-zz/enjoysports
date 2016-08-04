using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TeamSports.Startup))]
namespace TeamSports
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
