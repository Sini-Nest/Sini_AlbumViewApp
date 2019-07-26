using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AlbumViewApp.Startup))]
namespace AlbumViewApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
