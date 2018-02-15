using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CartAndDiscounts.Models
{
    public class Cart
    {
        public int CartId { get; set; }
        public List<Product> Products { get; set; }
        public decimal TotalPrice { get; set; }
        public List<Discount> Discounts { get; set; }
        
    }
}