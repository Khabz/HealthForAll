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
            Seed(app).GetAwaiter().GetResult();

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
        private async Task Seed(IApplicationBuilder app)
        {
            using (var scope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

                if (!context.Shelters.Any())
                {
                    var path = $"{Path.Combine(Directory.GetCurrentDirectory(), "Data", "Files", "Shelter.csv")}";
                    using (Stream stream = new FileStream(path, FileMode.Open, FileAccess.Read))
                    {
                        using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
                        {
                            CsvReader csvReader = new CsvReader(reader);
                            csvReader.Configuration.Delimiter = ";";
                            csvReader.Configuration.BadDataFound = x => { Console.WriteLine($"{x.RawRecord}"); };
                            while (csvReader.Read())
                            {
                                try
                                {
                                    var shelter = csvReader.GetRecord<ShelterCsvModel>();
                                    Console.WriteLine(shelter.name);
                                    var name = csvReader.GetField<string>("name");
                                    var classification = csvReader.GetField<string>("classification");
                                    var province = csvReader.GetField<string>("province");
                                    var longitude = csvReader.GetField<string>("longitude");
                                    var latitude = csvReader.GetField<string>("latitude");
                                    var area_type = csvReader.GetField<string>("area_type");
                                    var ownership = csvReader.GetField<string>("ownership");
                                    var district = csvReader.GetField<string>("district");
                                    var sub_district = csvReader.GetField<string>("sub_district");
                                    var postal_area = csvReader.GetField<string>("postal_area");
                                    var postal_address = csvReader.GetField<string>("postal_address");
                                    var street_address = csvReader.GetField<string>("street_address");

                                    var shelterModel = new Shelter
                                    {
                                        Name = shelter.name,
                                        Classification = shelter.classification,
                                        Province = shelter.province,
                                        Longitude = decimal.Parse(shelter.longitude),
                                        Latitude = decimal.Parse(shelter.latitude),
                                        AreaType = shelter.area_type,
                                        Ownership = shelter.ownership,
                                        District = shelter.district,
                                        SubDistrict = shelter.sub_district,
                                        PostalAddress = shelter.postal_address,
                                        PostalArea = shelter.postal_area,
                                        PostalStreet = shelter.street_address
                                    };


                                    context.Add(shelterModel);
                                }
                                catch (Exception e)
                                {

                                }
                            }
                            await context.SaveChangesAsync();
                        }
                    }
                }
            }
        }
    }
}
