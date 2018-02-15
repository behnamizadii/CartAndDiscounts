using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;

namespace CartAndDiscounts.Models
{
    public class SC_DBContext : DbContext
    {
        public SC_DBContext() : base("CartAndDiscountDB")
        {
           Database.SetInitializer(new DropCreateDatabaseAlways<SC_DBContext>());
        }
        

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Discount> Discounts { get; set; }
    }
}