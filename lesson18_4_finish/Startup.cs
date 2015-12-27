using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(lesson18_4_finish.Startup))]
namespace lesson18_4_finish
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
