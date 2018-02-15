using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CartAndDiscounts.Models;

namespace CartAndDiscounts.Controllers
{
    public abstract class ProductDecorator : ProductAbstract
    {
        protected ProductAbstract BaseProduct = null;

        protected string OptionCode = "";
        protected decimal Price = 0.0M;
        protected int Quantity = 1;

        protected ProductDecorator(ProductAbstract product)
        {
            BaseProduct = product;
            ProductName = product.ProductName;
        }

        public override string GetOptionCode()
        {
            return string.Format("{0}-{1}", BaseProduct.GetOptionCode(), OptionCode);
        }

        public override decimal GetPrice()
        {
            return Price + BaseProduct.GetPrice();
        }

        public override int GetQuantity()
        {
            return Quantity + BaseProduct.GetQuantity();
        }
    }
}