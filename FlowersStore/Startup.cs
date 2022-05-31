using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FlowersStore.Startup))]
namespace FlowersStore
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
