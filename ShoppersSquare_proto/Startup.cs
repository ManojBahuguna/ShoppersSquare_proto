using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ShoppersSquare_proto.Startup))]
namespace ShoppersSquare_proto
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
