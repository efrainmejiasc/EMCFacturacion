using AutoMapper;
using DatosEMC.Clases;
using DatosEMC.DataModels;
using DatosEMC.IRepositories;
using DatosEMC.Repositories;
using EMCApi.Client;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NegocioEMC;
using NegocioEMC.IServices;
using NegocioEMC.Services;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;


namespace FacturacionEMCSite
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
#if DEBUG
            services.AddDbContext<MyAppContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnectionLocal")));
            EngineData.ConnectionDb = Configuration.GetValue<string>("ConnectionStrings:DefaultConnectionLocal");
#else
            services.AddDbContext<MyAppContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            EngineData.ConnectionDb = Configuration.GetValue<string>("ConnectionStrings:DefaultConnection");
#endif

            //**************************************************************************
            services.AddControllersWithViews().AddRazorRuntimeCompilation();
            services.AddTransient<IHttpContextAccessor, HttpContextAccessor>();
            services.AddDistributedMemoryCache();
            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(20);
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });
            services.AddControllersWithViews();
            services.AddRazorPages();
            services.AddMvc();
            //*****************************************************************************

            services.AddScoped<ClientEMCApi, ClientEMCApi>();

            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new AutoMapperProfile());
            });
            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);

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
                app.UseExceptionHandler("/Error");
            }

            app.UseStaticFiles();

            app.UseRouting();

            //app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
               // endpoints.MapRazorPages();
                endpoints.MapControllerRoute(
                name: "default",
                pattern: "{controller}/{action}/{id?}",
                defaults: new { controller = "Home", action = "Index" });
            });

            //******************************************************************************
            var defaultDateCulture = "es-VE";
            var ci = new CultureInfo(defaultDateCulture);
            ci.NumberFormat.NumberDecimalSeparator = ",";
            ci.NumberFormat.CurrencyDecimalSeparator = ",";
            app.UseRequestLocalization(new RequestLocalizationOptions
            {
                DefaultRequestCulture = new RequestCulture(ci),
                SupportedCultures = new List<CultureInfo>
                {
                    ci,
                },
                SupportedUICultures = new List<CultureInfo>
                {
                    ci,
                }
            });
            //******************************************************************************
        }
    }
}
