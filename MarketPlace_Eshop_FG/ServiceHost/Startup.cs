using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Encodings.Web;
using System.Text.Unicode;
using GoogleReCaptcha.V3;
using GoogleReCaptcha.V3.Interface;
using MarketPlace.Application.Hubs;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MarketPlace.Application.Services.Implementations;
using MarketPlace.DataLayer.Repository;
using MarketPlace.Application.Services.Interfaces;
using MarketPlace.Application.Utilities;
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

            var mvcBuilder = services.AddControllersWithViews();

#if DEBUG
            mvcBuilder.AddRazorRuntimeCompilation();

#endif

            services.AddHttpContextAccessor();
            services.AddSignalR();

            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

            services.AddScoped<ISmsService, SmsService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ISiteService, SiteService>();
            services.AddScoped<ISellerService, SellerService>();
            services.AddScoped<IContactService, ContactService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<ISellerWalletService, SellerWalletService>();
            services.AddScoped<IPaymentService, PaymentService>();
            services.AddScoped<IProductDiscountService, ProductDiscountService>();
            services.AddScoped<IBlogService, BlogService>();
            services.AddScoped<IChatRoomService, ChatRoomService>();
            services.AddScoped<IMessageService, MessageService>();

            services.AddScoped<IPasswordHasher, PasswordHasher>();
            services.AddScoped<IAuthHelper, AuthHelper>();
            services.AddHttpClient<ICaptchaValidator, GoogleReCaptchaValidator>();

            #endregion

            #region Data Protection

            services.AddDataProtection()
                .PersistKeysToFileSystem(new DirectoryInfo(Directory.GetCurrentDirectory() + "\\wwwroot\\Auth\\"))
                .SetApplicationName("MarketPlace_Eshop_FG")
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
                options.AccessDeniedPath = "/404Error-page-not-found";
                options.ExpireTimeSpan = TimeSpan.FromMinutes(43200);
            });

            services.AddAuthorization(options =>
            {
                options.AddPolicy("AdminArea",
                    builder => builder.RequireRole(new List<string> { Roles.Administrator, Roles.AdminAssistant, Roles.ContentUploader }));

                options.AddPolicy("UserManagement",
                    builder => builder.RequireRole(new List<string> { Roles.Administrator }));

                options.AddPolicy("NotContentSection",
                    builder => builder.RequireRole(new List<string> { Roles.Administrator, Roles.AdminAssistant }));

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

                endpoints.MapHub<SiteChatHub>("/chathub");
                endpoints.MapHub<SupportHub>("/supporthub");
            });
        }
    }
}
