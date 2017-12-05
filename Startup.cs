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
            services.AddAutoMapper();
            services.AddMvc();
            services.AddDefaultAWSOptions(Configuration.GetAWSOptions());
            services.AddAWSService<IAmazonSimpleEmailService>();
            services.AddAWSService<IAmazonS3>();
            services.AddDbContext<AutomotoresDbContext>(options => options.UseMySql(Configuration["ConnectionStrings:AutomotoresDatabase"]));
            services.Configure<SentryOptions>(Configuration.GetSection("Sentry"));
            services.Configure<FotosConfiguracion>(Configuration.GetSection("FotosConfiguracion"));

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}
