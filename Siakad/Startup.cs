using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Siakad.Startup))]
namespace Siakad
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
