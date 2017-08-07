using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MoodWave.Startup))]
namespace MoodWave
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
