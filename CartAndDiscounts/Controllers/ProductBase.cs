using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CartAndDiscounts.Models;

namespace CartAndDiscounts.Controllers
{
    public class ProductBase : ProductAbstract
    {
        public ProductBase(Product product)
        {
            ProductId = product.ProductId;
            ProductName = product.ProductName;
            Price = product.Price;
            Quantity = 1;

        }
        public override string GetOptionCode()
        {
            return "";
        }

        public override decimal GetPrice()//(Product product)
        {
            return Price;
        }

        public override int GetQuantity()
        {
            return Quantity;
        }
    }
}