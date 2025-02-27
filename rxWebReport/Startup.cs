using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(rxWebReport.Startup))]
namespace rxWebReport
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            //ConfigureAuth(app);
        }
    }
}
