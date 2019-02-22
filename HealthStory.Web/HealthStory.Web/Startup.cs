﻿using HealthStory.Web.Application.AdminBloodTestInfo;
using HealthStory.Web.Application.AdminSubstance;
using HealthStory.Web.Application.AdminUnits;
using HealthStory.Web.Application.BloodTestValue.User;
using HealthStory.Web.Application.BloodTest.User;
using HealthStory.Web.Application.Dashboard.AvailableTest;
using HealthStory.Web.Application.Units.SelectList;
using HealthStory.Web.Entities;
using HealthStory.Web.Infrastructure;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace HealthStory.Web
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
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddTransient<IAdminUnitService, AdminUnitService>();
            services.AddTransient<IUnitSelectListProvider, UnitSelectListProvider>();
            services.AddTransient<IAdminSubstanceInfoService, AdminSubstanceInfoService>();
            services.AddTransient<IAdminBloodTestInfoService, AdminBloodTestInfoService>();
            services.AddTransient<IAppUserBloodTestValueService, AppUserBloodTestValueService>();
            services.AddTransient<IDashboardAvailableTestsProvider, DashboardAvailableTestsProvider>();
            services.AddTransient<IUserBloodTestProvider, UserBloodTestProvider>();
            services.AddTransient<IUserBloodTestSaver, UserBloodTestSaver>();


            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddDbContext<HealthStoryContext>(options =>
                    options.UseMySql("Server=localhost;Database=HealthStory;User Id=root; Password=admin;"));

            services.AddDefaultIdentity<AppUser>()
                .AddEntityFrameworkStores<HealthStoryContext>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();
            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
