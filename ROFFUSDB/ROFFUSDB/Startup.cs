using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ROFFUSDB.Startup))]
namespace ROFFUSDB
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
