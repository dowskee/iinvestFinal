using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(iinvest.Startup))]
namespace iinvest
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
