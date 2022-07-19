using FacturacionEMCSite.StringResources.Abstract;
using FacturacionEMCSite.StringResources.Concrete;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Globalization;

namespace FacturacionEMCSite.StringResources
{
    public class Resources
    {
        private readonly IWebHostEnvironment _hostingEnvironment;

        private static System.IO.FileInfo pathResourceFile;
        private static IResourceProvider resourceProvider;

        public Resources(IWebHostEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
            pathResourceFile = new System.IO.FileInfo(_hostingEnvironment.ContentRootPath + @"/StringResources/Resources.xml");
            resourceProvider = new XmlResourceProvider(pathResourceFile.ToString());
    }
        public static string Company
        {
            get { return resourceProvider.GetResource("Company", CultureInfo.CurrentUICulture.Name) as String; }
        }

        public static string LogOut
        {
            get { return resourceProvider.GetResource("LogOut", CultureInfo.CurrentUICulture.Name) as String; }
        }
    }
}
