using CartAndDiscounts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace CartAndDiscounts
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GenerateDB();
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        private void GenerateDB()
        {
            using (var context = new SC_DBContext())
            {
                var customer = new Customer()
                {
                    Fullname = "Hadi Izadi",
                    Email = "behnam.iam@gmail.com"
                };

                context.Customers.Add(customer);

                for (int i = 1; i <= 7; i++)
                {
                    var product = new Product()
                    {
                        ProductName = "PowerBank"+i,
                        Category = "Electronics",
                        CreationDate = DateTime.Now,
                        PhotoPath = "/Content/Images/PowerBanks/prod"+i+".jpg",
                        Price = Convert.ToDecimal("1"+i+"0"),
                    };
                    context.Products.Add(product);
                }
                context.SaveChanges();
            }
        }
    }
}
