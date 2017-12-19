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
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.IdentityModel.Tokens.Jwt;

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

            services.AddAuthorization(options =>
            {
                options.AddPolicy("OnlyAplicacionMovil", policy => policy.RequireRole("UsuarioAplicacionMovil"));
            });

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

                options.User.RequireUniqueEmail = false;
            });
            services.Configure<CookieAuthenticationEvents>(opt =>
            {
                opt.OnRedirectToLogin = ctx =>
                {
                    if (ctx.Request.Path.StartsWithSegments("/api"))
                        ctx.Response.StatusCode = (int)System.Net.HttpStatusCode.Unauthorized;

                    return Task.FromResult(0);
                };
            });

            JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
         .AddJwtBearer(options =>
         {
             options.TokenValidationParameters =
                  new TokenValidationParameters
                  {
                      ValidateIssuerSigningKey = true,
                      ValidateLifetime = true,
                      NameClaimType = JwtRegisteredClaimNames.Sub,
                      RoleClaimType = "roles",
                      ValidIssuer = Configuration["JwtSecurityToken:Issuer"],
                      ValidAudience = Configuration["JwtSecurityToken:Audience"],
                      IssuerSigningKey =
                      new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["JwtSecurityToken:Key"]))
                  };
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

            string[] roles = { "SuperAdministrador", "Empresa", "EmpresaAdministrador", "UsuarioAplicacion" };

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
