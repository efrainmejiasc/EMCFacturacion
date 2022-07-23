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
        public static string GetStarted
        {
            get { return resourceProvider.GetResource("GetStarted", CultureInfo.CurrentUICulture.Name) as String; }
        }
        public static string Company
        {
            get { return resourceProvider.GetResource("Company", CultureInfo.CurrentUICulture.Name) as string; }
        }

        public static string UsernameMail
        {
            get { return resourceProvider.GetResource("UsernameMail", CultureInfo.CurrentUICulture.Name) as string; }
        }

        public static string Password
        {
            get { return resourceProvider.GetResource("Password", CultureInfo.CurrentUICulture.Name) as string; }
        }

        public static string Confirm
        {
            get { return resourceProvider.GetResource("Confirm", CultureInfo.CurrentUICulture.Name).ToString(); }
        }

        public static string Accept
        {
            get { return resourceProvider.GetResource("Accept", CultureInfo.CurrentUICulture.Name).ToString(); }
        }

        public static string Cancel
        {
            get { return resourceProvider.GetResource("Cancel", CultureInfo.CurrentUICulture.Name).ToString(); }
        }

        public static string Users
        {
            get { return resourceProvider.GetResource("Users", CultureInfo.CurrentUICulture.Name).ToString(); }
        }
        public static string Dashboard
        {
            get { return resourceProvider.GetResource("Dashboard", CultureInfo.CurrentUICulture.Name).ToString(); }
        }
        public static string SalesRecord
        {
            get { return resourceProvider.GetResource("SalesRecord", CultureInfo.CurrentUICulture.Name).ToString(); }
        }
        public static string PurchasesRecord
        {
            get { return resourceProvider.GetResource("PurchasesRecord", CultureInfo.CurrentUICulture.Name).ToString(); }
        }

        public static string SalesSummary
        {
            get { return resourceProvider.GetResource("SalesSummary", CultureInfo.CurrentUICulture.Name).ToString(); }
        }
        public static string PurchasesSummary
        {
            get { return resourceProvider.GetResource("PurchasesSummary", CultureInfo.CurrentUICulture.Name).ToString(); }
        }
        public static string Stock
        {
            get { return resourceProvider.GetResource("Stock", CultureInfo.CurrentUICulture.Name).ToString(); }
        }
        public static string Assignments
        {
            get { return resourceProvider.GetResource("Assignments", CultureInfo.CurrentUICulture.Name).ToString(); }
        }
        public static string HomeBilling
        {
            get { return resourceProvider.GetResource("HomeBilling", CultureInfo.CurrentUICulture.Name).ToString(); }
        }

        public static string Login
        {
            get { return resourceProvider.GetResource("Login", CultureInfo.CurrentUICulture.Name) as String; }
        }
        public static string LogOut
        {
            get { return resourceProvider.GetResource("LogOut", CultureInfo.CurrentUICulture.Name) as String; }
        }

        public static string NewUsers
        {
            get { return (string) resourceProvider.GetResource("NewUsers", CultureInfo.CurrentUICulture.Name); }
        }

        public static string Name
        {
            get { return (string)resourceProvider.GetResource("Name", CultureInfo.CurrentUICulture.Name); }
        }

        public static string SurName
        {
            get { return (string)resourceProvider.GetResource("SurName", CultureInfo.CurrentUICulture.Name); }
        }
        public static string UserRol
        {
            get { return (string)resourceProvider.GetResource("UserRol", CultureInfo.CurrentUICulture.Name); }
        }

        public static string Username
        {
            get { return resourceProvider.GetResource("Username", CultureInfo.CurrentUICulture.Name).ToString(); }
        }

        public static string Email
        {
            get { return resourceProvider.GetResource("Email", CultureInfo.CurrentUICulture.Name).ToString(); }
        }

        public static string ConfirmPassword
        {
            get { return resourceProvider.GetResource("ConfirmPassword", CultureInfo.CurrentUICulture.Name) as string; }
        }

        public static string AllUsers
        {
            get { return resourceProvider.GetResource("AllUsers", CultureInfo.CurrentUICulture.Name).ToString(); }
        }

        public static string Status
        {
            get { return resourceProvider.GetResource("Status", CultureInfo.CurrentUICulture.Name).ToString(); }
        }

        public static string Rol
        {
            get { return resourceProvider.GetResource("Rol", CultureInfo.CurrentUICulture.Name).ToString(); }
        }

        public static string RegisteredUsers
        {
            get { return resourceProvider.GetResource("RegisteredUsers", CultureInfo.CurrentUICulture.Name).ToString(); }
        }
        public static string SummaryStock
        {
            get { return resourceProvider.GetResource("SummaryStock", CultureInfo.CurrentUICulture.Name).ToString(); }
        }
        public static string Id
        {
            get { return resourceProvider.GetResource("Id", CultureInfo.CurrentUICulture.Name).ToString(); }
        }
        public static string Product
        {
            get { return resourceProvider.GetResource("Product", CultureInfo.CurrentUICulture.Name).ToString(); }
        }
        public static string Unit
        {
            get { return resourceProvider.GetResource("Unit", CultureInfo.CurrentUICulture.Name).ToString(); }
        }
        public static string Amount
        {
            get { return resourceProvider.GetResource("Amount", CultureInfo.CurrentUICulture.Name).ToString(); }
        }
        public static string Article
        {
            get { return resourceProvider.GetResource("Article", CultureInfo.CurrentUICulture.Name).ToString(); }
        }
        public static string Seller
        {
            get { return resourceProvider.GetResource("Seller", CultureInfo.CurrentUICulture.Name).ToString(); }
        }
        public static string Search
        {
            get { return resourceProvider.GetResource("Search", CultureInfo.CurrentUICulture.Name).ToString(); }
        }
        public static string Save
        {
            get { return resourceProvider.GetResource("Save", CultureInfo.CurrentUICulture.Name).ToString(); }
        }
        public static string VendorAssignments
        {
            get { return resourceProvider.GetResource("VendorAssignments", CultureInfo.CurrentUICulture.Name).ToString(); }
        }
    }
}
