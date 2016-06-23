using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(OldBooks.Startup))]
namespace OldBooks
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
