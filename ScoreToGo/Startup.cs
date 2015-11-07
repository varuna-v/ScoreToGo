using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ScoreToGo.Startup))]
namespace ScoreToGo
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
