using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.Server.IISIntegration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RehabAid.Data;
using RehabAid.Web.Pages.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using wCyber.Helpers.Identity;
using wCyber.Helpers.Identity.Auth;
using wCyber.Lib.FileStorage;
using wCyber.Lib.FileStorage.Azure;

namespace RehabAid.Web
{
    public class Startup
    {
        public IWebHostEnvironment webHostEnvironment { get; }

        public Startup(IConfiguration configuration,  IWebHostEnvironment environment)
        {
            Configuration = configuration;
            webHostEnvironment = environment;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<RehabAidContext>(options =>
                options.UseNpgsql(
                    Configuration.GetConnectionString("Default")));
            services.AddSingleton<IdentityClient>();
            services.AddDefaultIdentity<User>()
               .AddUserStore<SysExternalLoginUserStore<User, UserExternalLogin, RehabAidContext>>()
               .AddClaimsPrincipalFactory<SysExternalLoginUserStore<User, UserExternalLogin, RehabAidContext>>()
               .AddDefaultTokenProviders();
            services.AddRazorPages();
            if (Configuration["StorageAcc:Uri"] != null)
            {
                services.AddSingleton<IFileStore>(new AzureBlobStore(Configuration["StorageAcc:Uri"], Configuration["StorageAcc:Name"], Configuration["StorageAcc:Key"]));
            }
            else services.AddSingleton<IFileStore>(new FSFileStore(@"c:\pms\files\"));
           
            services.AddMvc().AddRazorPagesOptions(options =>
            {
                options.Conventions.AddPageRoute("/landingpage", "/MyDirectory");
            });

            services.ConfigureApplicationCookie(o =>
            {
                o.ExpireTimeSpan = TimeSpan.FromHours(15);
                o.SlidingExpiration = true;
                o.Events = new Microsoft.AspNetCore.Authentication.Cookies.CookieAuthenticationEvents
                {
                    OnSigningIn = async context => await context.InitUser()
                };
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
            });
        }
    }
}
