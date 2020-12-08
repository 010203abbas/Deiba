using System;
using System.Threading.Tasks;
using Deiba.Areas.Identity.Data;
using Deiba.Data;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(Deiba.Areas.Identity.IdentityHostingStartup))]
namespace Deiba.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<DBDeiba>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("DBDeibaConnection")));

                services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
                    .AddRoles<IdentityRole>()
                    .AddEntityFrameworkStores<DBDeiba>();
                services.AddAuthorization(x =>
                {
                    x.AddPolicy("adminpolicy", p => p.RequireRole("مدیران"));

                });
                services.ConfigureApplicationCookie(x =>
                {
                    x.Events = new CookieAuthenticationEvents()
                    {
                        OnRedirectToLogin = y =>
                        {
                            y.Response.Redirect("/Panel/PanelManager");
                            return Task.CompletedTask;
                        }
                    };
                });

            });
        }
    }
}