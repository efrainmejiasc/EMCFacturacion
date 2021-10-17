using AutoMapper;
using DatosEMC.DataModels;
using DatosEMC.IRepositories;
using DatosEMC.Repositories;
using FacturacionEMCApi.SecurityToken;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using NegocioEMC;
using NegocioEMC.IServices;
using NegocioEMC.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

#if DEBUG

            services.AddDbContext<MyAppContext>(op => op.UseSqlServer(Configuration.GetConnectionString("DefaultConnectionLocal"),
                                                       b => b.MigrationsAssembly("DatosEMC")));
#else
            services.AddDbContext<MyAppContext>(op => op.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"),
                                                      b => b.MigrationsAssembly("DatosEMC")));
#endif
            services.AddDbContext<MyAppContext>();

            // Asigna la configuracion de la seguridad del JWT
            var jwtSection = Configuration.GetSection("JwtBearerTokenSettings");
            services.Configure<JwtBearerTokenSettings>(jwtSection);
            var jwtBearerTokenSettings = jwtSection.Get<JwtBearerTokenSettings>();
            var key = Encoding.ASCII.GetBytes(jwtBearerTokenSettings.SecretKey);

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.RequireHttpsMetadata = false;
                options.SaveToken = true;
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidIssuer = jwtBearerTokenSettings.Issuer,
                    ValidAudience = jwtBearerTokenSettings.Audience,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                };
            });

            //AGREGAR SWAGGER
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Api Facturacion EMC", Version = "v1" });
            });

            // AGREGAR MAPEO ENTRE CLASES
            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new AutoMapperProfile());
            });
            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);

            services.AddScoped<MyAppContext, MyAppContext>();

            services.AddScoped<IUsuarioService, UsuarioService>();
            services.AddScoped<IUsuarioRepository,UsuarioRepository>();

            services.AddScoped<IClienteService, ClienteService>();
            services.AddScoped<IClienteRepository, ClienteRepository>();

            services.AddScoped<IEmpresaService, EmpresaService>();
            services.AddScoped<IEmpresaRepository, EmpresaRepository>();

            services.AddScoped<IProveedorService, ProveedorService>();
            services.AddScoped<IProveedorRepository, ProveedorRepository>();

            services.AddScoped<IFacturaCompraService, FacturaCompraService>();
            services.AddScoped<IFacturaCompraRepository, FacturaCompraRepository>();

            services.AddScoped<IFacturaCompraDetalleService, FacturaCompraDetalleService>();
            services.AddScoped<IFacturaCompraDetalleRepository, FacturaCompraDetalleRepository>();

            services.AddScoped<IFacturaVentaService, FacturaVentaService>();
            services.AddScoped<IFacturaVentaRepository, FacturaVentaRepository>();

            services.AddScoped<IFacturaVentaDetalleService, FacturaVentaDetalleService>();
            services.AddScoped<IFacturaVentaDetalleRepository, FacturaVentaDetalleRepository>();
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
