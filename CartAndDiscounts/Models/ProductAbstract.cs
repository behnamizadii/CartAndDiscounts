using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CartAndDiscounts.Controllers
{
    public abstract class ProductAbstract
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public string DiscountDescription { get; set; }
        public abstract string GetOptionCode();
        public abstract decimal GetPrice();
        public abstract int GetQuantity();

    }
}