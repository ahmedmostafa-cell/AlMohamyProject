
using BL;
using AlMohamyProject.Models;
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
using EmailService;
using Microsoft.AspNetCore.Authorization;
using AlMohamyProject.Controllers;

namespace AlMohamyProject
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var emailConfig = Configuration
         .GetSection("EmailConfiguration")
         .Get<EmailConfiguration>();
            services.AddSingleton(emailConfig);
            services.AddScoped<IEmailSender, EmailSender>();
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
            services.AddScoped<AboutAppService, ClsAboutApp>();
            services.AddScoped<ApprovedOfficeService, ClsApprovedOffice>();
            services.AddScoped<ChargeService, ClsCharge>();
            services.AddScoped<ConsultingEstablishService, ClsConsultingEstablish>();
            services.AddScoped<ConsultingTypeService, ClsConsultingType>();
            services.AddScoped<DocumentationOfContractService, ClsDocumentationOfContract>();
            services.AddScoped<EvaluationService, ClsEvaluation>();
            services.AddScoped<MainConsultingService, ClsMainConsulting>();
            services.AddScoped<NotificationService, ClsNotification>();
            services.AddScoped<OfferService, ClsOffer>();
            services.AddScoped<PoliciesAndPrivacyService, ClsPoliciesAndPrivacy>();
            services.AddScoped<PromocodeService, ClsPromocode>();
            services.AddScoped<SettingService, ClsSetting>();
            services.AddScoped<SubMainConsultingService, ClsSubMainConsulting>();
            services.AddScoped<TermAndConditionService, ClsTermAndCondition>();
            services.AddScoped<ComplainsAndSuggestionsService, ClsComplainsAndSuggestions>();
            services.AddScoped<IAccountRepository, AccountRepository>();
            services.AddControllersWithViews();
            services.AddMvc().AddSessionStateTempDataProvider();
            services.AddSession();
            services.AddDbContext<AlMohamyDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddIdentity<ApplicationUser, IdentityRole>(options =>
            {
                options.Password.RequiredLength = 1;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.User.RequireUniqueEmail = false;
                options.SignIn.RequireConfirmedEmail = false;
                options.User.AllowedUserNameCharacters = "";
                options.Password.RequireDigit = false;
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromSeconds(30);
                options.Lockout.MaxFailedAccessAttempts = 5;

                options.User.AllowedUserNameCharacters = string.Empty;

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
            app.UseCookiePolicy();
            app.UseCors(MyAllowSpecificOrigins);
            app.UseRouting();
            app.UseSession();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseSession();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(

              name: "areas",
              pattern: "{area:exists}/{controller=Home}/{action=Index}");
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
