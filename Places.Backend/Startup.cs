using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Places.Backend.Startup))]
namespace Places.Backend
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
