using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TestIdentity.Models;

[assembly: HostingStartup(typeof(TestIdentity.Areas.Identity.IdentityHostingStartup))]
namespace TestIdentity.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<TestIdentityContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("TestIdentityContextConnection")));

                services.AddDefaultIdentity<IdentityUser>()
                    .AddEntityFrameworkStores<TestIdentityContext>();
            });
        }
    }
}