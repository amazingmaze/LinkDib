using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(LinkDib.Startup))]
namespace LinkDib
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
