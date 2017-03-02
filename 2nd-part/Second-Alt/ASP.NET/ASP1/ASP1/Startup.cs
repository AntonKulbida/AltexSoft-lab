using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ASP1.Startup))]
namespace ASP1
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
