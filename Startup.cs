using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Amazon.SimpleEmail;
using Amazon.S3;
using Amazon.S3.Transfer;
using AutoMapper;
using Automotores.Backend.Core;
using Automotores.Backend.Core.Models;
using Automotores.Backend.Core.Services;
using Automotores.Backend.Extensions;
using Automotores.Backend.Persistence;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.SpaServices.Webpack;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;

namespace Automotores.Backend
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
            services.AddScoped<IEmpresaRepository, EmpresaRepository>();
            services.AddScoped<IAdministradorRepository, AdministradorRepository>();
            services.AddScoped<IEstablecimientoRepository, EstablecimientoRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IErrorReporter, SentryErrorReporter>();
            services.AddScoped<IMailRepository, MailRepository>();
            services.AddScoped<IPromocionRepository, PromocionRepository>();
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            services.AddScoped<IVehiculoRepository, VehiculoRepository>();
            services.AddTransient<IUploadService, UploadService>();
            services.AddTransient<IMailService, MailService>();
            services.AddTransient<IIdentityService, IdentiyService>();

            services.AddAutoMapper();
            services.AddDefaultAWSOptions(Configuration.GetAWSOptions());
            services.AddAWSService<IAmazonSimpleEmailService>();
            services.AddAWSService<IAmazonS3>();

            services.AddDbContext<AutomotoresDbContext>(options => options.UseMySql(Configuration["ConnectionStrings:AutomotoresDatabase"]));

            services.AddIdentity<User, IdentityRole>()
                    .AddEntityFrameworkStores<AutomotoresDbContext>()
                    .AddDefaultTokenProviders();

            services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequireDigit = true;
                options.Password.RequiredLength = 8;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireLowercase = false;
                options.Password.RequiredUniqueChars = 6;

                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(30);
                options.Lockout.MaxFailedAccessAttempts = 10;
                options.Lockout.AllowedForNewUsers = true;

                // User settings
                options.User.RequireUniqueEmail = false;
            });
            services.Configure<CookieAuthenticationOptions>(opt =>
            {
                services.ConfigureApplicationCookie(options =>
                {
                    options.Cookie.HttpOnly = true;
                    options.Events.OnRedirectToAccessDenied = (context) =>
                    {
                        context.Response.StatusCode = 401;
                        return Task.CompletedTask;
                    };
                    options.Events.OnRedirectToLogin = (context) =>
                    {
                        context.Response.StatusCode = 401;
                        return Task.CompletedTask;
                    };
                    options.Events.OnRedirectToLogout = (context) =>
                    {
                        context.Response.StatusCode = 401; return Task.CompletedTask;
                    };
                    options.Cookie.Expiration = TimeSpan.FromDays(150);
                    options.SlidingExpiration = true;
                });
            });

            services.AddMvc();

            services.Configure<SentryOptions>(Configuration.GetSection("Sentry"));
            services.Configure<FotosConfiguracion>(Configuration.GetSection("FotosConfiguracion"));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IServiceProvider serviceProvider)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseAuthentication();

            app.UseMvc();

            CreateRoles(serviceProvider);
        }

        private void CreateRoles(IServiceProvider serviceProvider)
        {

            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var userManager = serviceProvider.GetRequiredService<UserManager<User>>();
            Task<IdentityResult> roleResult;
            string[] roles = { "SuperAdministrador", "Empresa", "AdministradorEmpresa", "UsuarioAplicacionMovil" };

            string email = "gerencia@automotoresclub.com";

            foreach (var role in roles)
            {
                Task<bool> hasAdminRole = roleManager.RoleExistsAsync(role);
                hasAdminRole.Wait();

                if (!hasAdminRole.Result)
                {
                    roleResult = roleManager.CreateAsync(new IdentityRole(role));
                    roleResult.Wait();
                }

            }

            Task<User> superUser = userManager.FindByEmailAsync(email);
            superUser.Wait();

            if (superUser.Result == null)
            {
                User superAdministrador = new User();
                superAdministrador.Email = email;
                superAdministrador.UserName = email;

                Task<IdentityResult> newUser = userManager.CreateAsync(superAdministrador, "Rafael2017*");
                newUser.Wait();

                if (newUser.Result.Succeeded)
                {
                    Task<IdentityResult> newUserRole = userManager.AddToRoleAsync(superAdministrador, "SuperAdministrador");
                    newUserRole.Wait();
                }
            }
        }
    }
}
