using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Deiba.Areas.Identity.Data;
using Deiba.Controllers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Deiba
{
    public class Startup
    {
        private UserManager userManager;
        private RoleManager<object> roleManager;

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            services.AddAuthentication();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env,UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();
            app.UseAuthentication();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
            InitRoles(userManager, roleManager).Wait();
            
        }

        private async Task InitRoles(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager) 
        {
            List<string> roles = new List<string>{"مدیران" };
            foreach (var x in roles)
            {
                if((await roleManager.RoleExistsAsync(x)) == false)
                {
                    IdentityRole role = new IdentityRole(x);
                    await roleManager.CreateAsync(role);
                }

            }
            ApplicationUser adminuser = await userManager.FindByNameAsync("bordbarabbas21@yahoo.com");
            if (adminuser == null)
            {
                adminuser = new ApplicationUser
                {
                    UserName = "bordbarabbas21@yahoo.com",
                    Email = "bordbarabbas21@yahoo.com",
                    Name = "Admin",
                    EmailConfirmed = true
                };
                await userManager.CreateAsync(adminuser, "010203=Aa");
            }
            if((await userManager.IsInRoleAsync(adminuser, "مدیران"))==false)
            {
                await userManager.AddToRoleAsync(adminuser, "مدیران");

            }
                
            
            
        }
    }
}
