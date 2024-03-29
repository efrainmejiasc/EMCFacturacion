using AutoMapper;
using DatosEMC.Clases;
using DatosEMC.DataModels;
using DatosEMC.IRepositories;
using DatosEMC.Repositories;
using FacturacionEMCApi.SecurityToken;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Localization;
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
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
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
            EngineData.ConnectionDb = Configuration.GetConnectionString("DefaultConnectionLocal");
            services.AddDbContext<MyAppContext>(op => op.UseSqlServer(Configuration.GetConnectionString("DefaultConnectionLocal"),
                                                       b => b.MigrationsAssembly("DatosEMC")));
#else
            EngineData.ConnectionDb = Configuration.GetConnectionString("DefaultConnection");
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
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo { Title = "FACTURACION EMC API", Version = "v1" });
                options.CustomOperationIds(e => $"{e.ActionDescriptor.RouteValues["controller"]}_{e.ActionDescriptor.RouteValues["action"]}");

                options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "JWT Authorization header using the Bearer scheme (Example: 'Bearer 12345abcdef')",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer "
                });

                options.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            },
                            Scheme = "oauth2",
                            Name = "Bearer",
                            In = ParameterLocation.Header
                        },
                        Array.Empty<string>()
                    }
                });

                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                options.IncludeXmlComments(xmlPath);

            });
            // AGREGAR MAPEO ENTRE CLASES
            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new AutoMapperProfile());
            });
            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);

            services.AddScoped<MyAppContext, MyAppContext>();

            services.AddScoped<IUnidadMedidaService, UnidadMedidaService>();
            services.AddScoped<IUnidadMedidaRepository, UnidadMedidaRepository>();

            services.AddScoped<IMetodoPagoService, MetodoPagoService>();
            services.AddScoped<IMetodoPagoRepository,MetodoPagoRepository>();

            services.AddScoped<IUsuarioService, UsuarioService>();
            services.AddScoped<IUsuarioRepository,UsuarioRepository>();

            services.AddScoped<IClienteService, ClienteService>();
            services.AddScoped<IClienteRepository, ClienteRepository>();

            services.AddScoped<IEmpresaService, EmpresaService>();
            services.AddScoped<IEmpresaRepository, EmpresaRepository>();

            services.AddScoped<IProveedorService, ProveedorService>();
            services.AddScoped<IProveedorRepository, ProveedorRepository>();

            services.AddScoped<IInicioFacturacionService, InicioFacturacionService>();
            services.AddScoped<IInicioFacturacionRepository, InicioFacturacionRepository>();

            services.AddScoped<IFacturaCompraService, FacturaCompraService>();
            services.AddScoped<IFacturaCompraRepository, FacturaCompraRepository>();

            services.AddScoped<IFacturaCompraDetalleService, FacturaCompraDetalleService>();
            services.AddScoped<IFacturaCompraDetalleRepository, FacturaCompraDetalleRepository>();

            services.AddScoped<IFacturaVentaService, FacturaVentaService>();
            services.AddScoped<IFacturaVentaRepository, FacturaVentaRepository>();

            services.AddScoped<IFacturaVentaDetalleService, FacturaVentaDetalleService>();
            services.AddScoped<IFacturaVentaDetalleRepository, FacturaVentaDetalleRepository>();

            services.AddScoped<IStockTotalService, StockTotalService>();
            services.AddScoped<IStockTotalRepository, StockTotalRepository>();

            services.AddScoped<IStockBodegaService, StockBodegaService>();
            //services.AddScoped<IStockBodegaRepository, StockBodegaRepository>();

            services.AddScoped<IStockTransitoService, StockTransitoService>();
            services.AddScoped<IStockTransitoRepository, StockTransitoRepository>();

            services.AddScoped<IProductoService, ProductoService>();
            services.AddScoped<IProductoRepository, ProductoRepository>();

            services.AddScoped<IProductoImgService, ProductoImgService>();
            services.AddScoped<IProductoImgRepository, ProductoImgRepository>();

            services.AddScoped<IProductoImgInfoService, ProductoImgInfoService>();
            services.AddScoped<IProductoImgInfoRepository, ProductoImgInfoRepository>();

            services.AddScoped<ITrazabilidadEnvioService, TrazabilidadEnvioService>();
            services.AddScoped<ITrazabilidadEnvioRepository, TrazabilidadEnvioRepository>();

            services.AddScoped<IVentaNumeroService, VentaNumeroService>();
            services.AddScoped<IVentaNumeroRepository, VentaNumeroRepository>();

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
            //******************************************************************************
            var culturaInglesa = "en-US";
            var culturaEspaņola = "es-ES";
            var ci = new CultureInfo(culturaInglesa);
            ci.NumberFormat.NumberDecimalSeparator = ".";
            ci.NumberFormat.CurrencyDecimalSeparator = ".";
            var ce = new CultureInfo(culturaEspaņola);
            ce.NumberFormat.NumberDecimalSeparator = ",";
            ce.NumberFormat.CurrencyDecimalSeparator = ",";
#if DEBUG

            CultureInfo.DefaultThreadCurrentCulture = ce;
            CultureInfo.DefaultThreadCurrentUICulture = ce;
#else

            CultureInfo.DefaultThreadCurrentCulture = ci;
            CultureInfo.DefaultThreadCurrentUICulture = ci;
#endif


            app.UseRequestLocalization(new RequestLocalizationOptions
            {
                DefaultRequestCulture = new RequestCulture(ci),
                SupportedCultures = new List<CultureInfo>
                {
                    ci,ce
                },
                SupportedUICultures = new List<CultureInfo>
                {
                    ci,ce
                }
            });
            //******************************************************************************
        }
    }
}
