using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HealthForAll.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using HealthForAll.Models;
using System.Reflection;
using System.IO;
using CsvHelper;
using System.Text;

namespace HealthForAll
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

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));
            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            InitializeDatabase(app).GetAwaiter().GetResult();

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
        private async Task InitializeDatabase(IApplicationBuilder app)
        {
            using (var scope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                var rolesManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
                var userManager = scope.ServiceProvider.GetService<UserManager<ApplicationUser>>();

                // Add Patient Role
                var isPatientExists = await rolesManager.RoleExistsAsync("Paitent");
                if (!isPatientExists)
                {
                    var role = new IdentityRole("Patient");
                    await rolesManager.CreateAsync(role);
                }

                // Add Dietian Role
                var isUserExists = await rolesManager.RoleExistsAsync("Dietian");
                if (!isUserExists)
                {
                    var role = new IdentityRole("Dietian");
                    await rolesManager.CreateAsync(role);
                }

                // Add Nurse Role
                var isNurseExists = await rolesManager.RoleExistsAsync("Nurse");
                if (!isNurseExists)
                {
                    var role = new IdentityRole("Nurse");
                    await rolesManager.CreateAsync(role);
                }
            }
        }
        //private void Seed(ApplicationDbContext context)
        //{
        //    Assembly assembly = Assembly.GetExecutingAssembly();
        //    string resourceName = "HealthForAll.Data.Files.Shelter.xlsx";
        //    using (Stream stream = assembly.GetManifestResourceStream(resourceName))
        //    {
        //        using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
        //        {
        //            CsvReader csvReader = new CsvReader(reader);
        //            var shelters = csvReader.GetRecords<Shelter>().ToArray();

        //            foreach (var shelter in shelters)
        //            {
        //                context.Shelters.Add(shelter);
        //            }
        //        }
        //    }
        //}
    }
}
