
using BL;
using EibtekSystemProject.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlMohamyProject
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAuthentication()
            .AddGoogle(options =>
            {
                options.ClientId = "975214719409-pp37jcmifi7bg33254ve18ku83telt9r.apps.googleusercontent.com";
                options.ClientSecret = "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";


            });



            services.AddAuthentication().AddFacebook(options =>
            {
                options.AppId = "1387677424973135";
                options.AppSecret = "de6fc7e479121219c97a2e079eee1b3e";
            });
            services.AddControllersWithViews();
            services.AddDbContext<AlMohamyDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddIdentity<ApplicationUser, IdentityRole>(options =>
            {
                options.Password.RequiredLength = 5;
                options.Password.RequireLowercase = true;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.User.RequireUniqueEmail = true;
                options.Password.RequireDigit = false;
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromSeconds(30);
                options.Lockout.MaxFailedAccessAttempts = 5;
                //options.SignIn.RequireConfirmedEmail = true;

            }).AddErrorDescriber<CustomIdentityErrorDescriber>().AddEntityFrameworkStores<AlMohamyDbContext>().AddDefaultTokenProviders();    ///.AddDefaultUI();


            services.ConfigureApplicationCookie(opt =>
            {
                opt.AccessDeniedPath = new Microsoft.AspNetCore.Http.PathString("/Home/Accessdenied");
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
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

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
