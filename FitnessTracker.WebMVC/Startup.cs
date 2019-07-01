using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FitnessTracker.WebMVC.Startup))]
namespace FitnessTracker.WebMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
