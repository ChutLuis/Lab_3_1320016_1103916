using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Lab_3_.Startup))]
namespace Lab_3_
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
