using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BasketBallApp.Startup))]
namespace BasketBallApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
