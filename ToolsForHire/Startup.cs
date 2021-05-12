using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ToolsForHire.Startup))]
namespace ToolsForHire
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
