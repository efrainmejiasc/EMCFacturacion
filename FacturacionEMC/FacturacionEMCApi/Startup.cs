using AutoMapper;
using DatosEMC.DataModels;
using DatosEMC.IRepositories;
using DatosEMC.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using NegocioEMC;
using NegocioEMC.IServices;
using NegocioEMC.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FacturacionEMCApi
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
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "FacturacionEMCApi", Version = "v1" });
            });

            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new AutoMapperProfile());
            });
            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);
#if DEBUG

            services.AddDbContext<MyAppContext>(op => op.UseSqlServer(Configuration.GetConnectionString("DefaultConnectionLocal"),
                                                       b => b.MigrationsAssembly("DatosEMC")));
#else
            services.AddDbContext<MyAppContext>(op => op.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"),
                                                      b => b.MigrationsAssembly("DatosEMC")));
#endif

            services.AddScoped<IUsuarioService, UsuarioService>();
            services.AddScoped<IUsuarioRepository,UsuarioRepository>();

            services.AddScoped<IEmpresaService, EmpresaService>();
            services.AddScoped<IEmpresaRepository, EmpresaRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "FacturacionEMCApi v1"));
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
