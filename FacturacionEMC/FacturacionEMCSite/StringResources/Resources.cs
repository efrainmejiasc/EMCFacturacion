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
        public static string StartInvoice
        {
            get { return resourceProvider.GetResource("StartInvoice", CultureInfo.CurrentUICulture.Name).ToString(); }
        }
        public static string InvoiceInit
        {
            get { return resourceProvider.GetResource("InvoiceInit", CultureInfo.CurrentUICulture.Name).ToString(); }
        }
        public static string StartBillingNumber
        {
            get { return resourceProvider.GetResource("StartBillingNumber", CultureInfo.CurrentUICulture.Name).ToString(); }
        }
        public static string Instructions
        {
            get { return resourceProvider.GetResource("Instructions", CultureInfo.CurrentUICulture.Name).ToString(); }
        }
        public static string RestartInvoiceInit
        {
            get { return resourceProvider.GetResource("RestartInvoiceInit", CultureInfo.CurrentUICulture.Name).ToString(); }
        }
        public static string ResetP
        {
            get { return resourceProvider.GetResource("ResetP", CultureInfo.CurrentUICulture.Name).ToString(); }
        }
        public static string OneP
        {
            get { return resourceProvider.GetResource("OneP", CultureInfo.CurrentUICulture.Name).ToString(); }
        }
        public static string TwoP
        {
            get { return resourceProvider.GetResource("TwoP", CultureInfo.CurrentUICulture.Name).ToString(); }
        }
        public static string ThreeP
        {
            get { return resourceProvider.GetResource("ThreeP", CultureInfo.CurrentUICulture.Name).ToString(); }
        }
        public static string ExampleP
        {
            get { return resourceProvider.GetResource("ExampleP", CultureInfo.CurrentUICulture.Name).ToString(); }
        }
        public static string Notice
        {
            get { return resourceProvider.GetResource("Notice", CultureInfo.CurrentUICulture.Name).ToString(); }
        }
        public static string Invoice
        {
            get { return resourceProvider.GetResource("Invoice", CultureInfo.CurrentUICulture.Name).ToString(); }
        }
        public static string PaymentMethod
        {
            get { return resourceProvider.GetResource("PaymentMethod", CultureInfo.CurrentUICulture.Name).ToString(); }
        }
        public static string Client
        {
            get { return resourceProvider.GetResource("Client", CultureInfo.CurrentUICulture.Name).ToString(); }
        }
        public static string Description
        {
            get { return resourceProvider.GetResource("Description", CultureInfo.CurrentUICulture.Name).ToString(); }
        }
        public static string Price
        {
            get { return resourceProvider.GetResource("Price", CultureInfo.CurrentUICulture.Name).ToString(); }
        }
        public static string Subtotal
        {
            get { return resourceProvider.GetResource("Subtotal", CultureInfo.CurrentUICulture.Name).ToString(); }
        }
        public static string Total
        {
            get { return resourceProvider.GetResource("Total", CultureInfo.CurrentUICulture.Name).ToString(); }
        }
        public static string Tax
        {
            get { return resourceProvider.GetResource("Tax", CultureInfo.CurrentUICulture.Name).ToString(); }
        }
        public static string Discount
        {
            get { return resourceProvider.GetResource("Discount", CultureInfo.CurrentUICulture.Name).ToString(); }
        }
        public static string RFC
        {
            get { return resourceProvider.GetResource("RFC", CultureInfo.CurrentUICulture.Name).ToString(); }
        }
        public static string PhoneNumber
        {
            get { return resourceProvider.GetResource("PhoneNumber", CultureInfo.CurrentUICulture.Name).ToString(); }
        }
        public static string Address
        {
            get { return resourceProvider.GetResource("Address", CultureInfo.CurrentUICulture.Name).ToString(); }
        }
        public static string AddNewClient
        {
            get { return resourceProvider.GetResource("AddNewClient", CultureInfo.CurrentUICulture.Name).ToString(); }
        }
        public static string NameSocialReason
        {
            get { return resourceProvider.GetResource("NameSocialReason", CultureInfo.CurrentUICulture.Name).ToString(); }
        }
        public static string Print
        {
            get { return resourceProvider.GetResource("Print", CultureInfo.CurrentUICulture.Name).ToString(); }
        }
        public static string Date
        {
            get { return resourceProvider.GetResource("Date", CultureInfo.CurrentUICulture.Name).ToString(); }
        }
        public static string NameArticle
        {
            get { return (string)resourceProvider.GetResource("NameArticle", CultureInfo.CurrentUICulture.Name); }
        }
        public static string Supplier
        {
            get { return (string)resourceProvider.GetResource("Supplier", CultureInfo.CurrentUICulture.Name); }
        }
        public static string AddPurchaseInvoice
        {
            get { return resourceProvider.GetResource("AddPurchaseInvoice", CultureInfo.CurrentUICulture.Name).ToString(); }
        }
        public static string AddDetail
        {
            get { return resourceProvider.GetResource("AddDetail", CultureInfo.CurrentUICulture.Name).ToString(); }
        }
        public static string AddSalesInvoice
        {
            get { return resourceProvider.GetResource("AddSalesInvoice", CultureInfo.CurrentUICulture.Name).ToString(); }
        }
        public static string InvoiceDetail
        {
            get { return resourceProvider.GetResource("InvoiceDetail", CultureInfo.CurrentUICulture.Name).ToString(); }
        }
        public static string AssignStockToSeller
        {
            get { return resourceProvider.GetResource("AssignStockToSeller", CultureInfo.CurrentUICulture.Name).ToString(); }
        }
        public static string AssignedItems
        {
            get { return resourceProvider.GetResource("AssignedItems", CultureInfo.CurrentUICulture.Name).ToString(); }
        }
    }
}
