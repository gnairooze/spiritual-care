using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SpiritualCare.TempWWW.Startup))]
namespace SpiritualCare.TempWWW
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
