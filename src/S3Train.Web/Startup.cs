using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(S3Train.Startup))]
namespace S3Train
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
