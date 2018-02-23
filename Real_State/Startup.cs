using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Real_State.Startup))]
namespace Real_State
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
