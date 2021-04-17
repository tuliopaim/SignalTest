using Microsoft.AspNetCore.Hosting;

[assembly: HostingStartup(typeof(SignalTest.MVC.Areas.Identity.IdentityHostingStartup))]
namespace SignalTest.MVC.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
            });
        }
    }
}