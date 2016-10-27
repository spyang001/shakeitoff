using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ShakeitOff.Startup))]
namespace ShakeitOff
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
