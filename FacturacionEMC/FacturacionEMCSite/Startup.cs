using AutoMapper;
using DatosEMC.Clases;
using DatosEMC.DataModels;
using DatosEMC.IRepositories;
using DatosEMC.Repositories;
using EMCApi.Client;
using FacturacionEMCSite.Application;
using FacturacionEMCSite.Filters;
using Microsoft.AspNetCore.Authentication;
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
using NegocioEMC.Settings;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;


namespace FacturacionEMCSite
{
    public class Startup
    {
        private readonly IWebHostEnvironment _hostingEnvironment;

        public Startup(IConfiguration configuration, IWebHostEnvironment hostingEnvironment)
        {
            Configuration = configuration;
            _hostingEnvironment = hostingEnvironment;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
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
            services.AddSingleton<StringResources.Resources>(new StringResources.Resources(_hostingEnvironment));
            AppMethods.PathFolderImgProducts = Configuration.GetValue<string>("HostSettings:PathFolderImgProducts");
            SettingsClass();

            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new AutoMapperProfile());
            });
            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);

            services.AddControllers(config =>
            {
                config.Filters.Add(new CustomAuthenticationFilter());
                //config.Filters.Add(new CustomActionFilter());
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();
            else
                app.UseExceptionHandler("/Error");

            app.UseStaticFiles();

            app.UseRouting();

           // app.UseAuthorization();

            app.UseSession();
            app.UseEndpoints(endpoints =>
            {
               // endpoints.MapRazorPages();
                endpoints.MapControllerRoute(
                name: "default",
                pattern: "{controller}/{action}/{id?}",
                defaults: new { controller = "Home", action = "Init" });
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

        private void SettingsClass()
        {
            EmpresaSettings.IdEmpresa = Configuration.GetValue<int>("EmpresaSettings:IdEmpresa");
        }
    }
}
