using System;
using System.IO;
using System.Text.Encodings.Web;
using System.Text.Unicode;
using GoogleReCaptcha.V3;
using GoogleReCaptcha.V3.Interface;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MarketPlace.Application.Services.Implementations;
using MarketPlace.DataLayer.Repository;
using MarketPlace.Application.Services.Interfaces;
using MarketPlace.DataLayer.Context;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.EntityFrameworkCore;

namespace ServiceHost
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
            #region Config Services

            services.AddControllersWithViews();


            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

            services.AddScoped<ISmsService, SmsService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ISiteService, SiteService>();
            services.AddScoped<ISellerService, SellerService>();
            services.AddScoped<IContactService, ContactService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<ISellerWalletService, SellerWalletService>();

            services.AddScoped<IPasswordHasher, PasswordHasher>();
            services.AddHttpClient<ICaptchaValidator, GoogleReCaptchaValidator>();

            #endregion

            #region Data Protection

            services.AddDataProtection()
                .PersistKeysToFileSystem(new DirectoryInfo(Directory.GetCurrentDirectory() + "\\wwwroot\\Auth\\"))
                .SetApplicationName("MarketPlaceProject")
                .SetDefaultKeyLifetime(TimeSpan.FromDays(30));
            

            #endregion

            #region ConfigDatabase

            var connectionString = Configuration.GetConnectionString("MarketPlaceConnection");

            services.AddDbContext<DatabaseContext>(option =>
                option.UseSqlServer(connectionString));

            #endregion

            #region Authentication

            services.AddAuthentication(options =>
                {
                    options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                    options.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                    options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;

                }).AddCookie(options =>
            {
                options.LoginPath = "/Login";
                options.LogoutPath = "/Logout";
                options.ExpireTimeSpan = TimeSpan.FromMinutes(43200);
            });





            #endregion

            #region Html Encoder

            services.AddSingleton<HtmlEncoder>(
                HtmlEncoder.Create(
                    allowedRanges: new[] { UnicodeRanges.BasicLatin, UnicodeRanges.Arabic }));
            #endregion
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

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "areas",
                    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
                );

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
