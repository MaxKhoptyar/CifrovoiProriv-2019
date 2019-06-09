using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TheHermes.Startup))]
namespace TheHermes
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
