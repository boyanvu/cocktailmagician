using Microsoft.AspNetCore.Hosting;

[assembly: HostingStartup(typeof(CocktailsMagician.Areas.Identity.IdentityHostingStartup))]
namespace CocktailsMagician.Areas.Identity
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