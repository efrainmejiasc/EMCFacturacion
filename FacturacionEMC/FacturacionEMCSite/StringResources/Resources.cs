using FacturacionEMCSite.StringResources.Abstract;
using FacturacionEMCSite.StringResources.Concrete;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Globalization;

namespace FacturacionEMCSite.StringResources
{
    public class Resources
    {
        private readonly IHostingEnvironment _hostingEnvironment;
        private static System.IO.FileInfo pathResourceFile = new System.IO.FileInfo(@"C:/Users/EfrainMejiasC/Documents/GitHub/EMCFacturacion/FacturacionEMC/FacturacionEMCSite/StringResources/Resources.xml");
        private static IResourceProvider resourceProvider = new XmlResourceProvider(pathResourceFile.ToString());

        [System.Obsolete]
        public Resources(IHostingEnvironment hostingEnvironment)
        {
            this._hostingEnvironment = hostingEnvironment;
            string contentRootPath = this._hostingEnvironment.ContentRootPath;
            pathResourceFile = new System.IO.FileInfo(contentRootPath + @"C:/Users/EfrainMejiasC/Documents/GitHub/EMCFacturacion/FacturacionEMC/FacturacionEMCSite/StringResources/Resources.xml");
            resourceProvider = new XmlResourceProvider(pathResourceFile.ToString());
        }
        public static string Company
        {
            get { return resourceProvider.GetResource("Company", CultureInfo.CurrentUICulture.Name) as String; }
        }
    }
}
