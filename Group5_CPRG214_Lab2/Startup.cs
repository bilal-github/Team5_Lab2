using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Group5_CPRG214_Lab2.Startup))]
namespace Group5_CPRG214_Lab2
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
