using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(HotelBooking.App.Startup))]
namespace HotelBooking.App
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
