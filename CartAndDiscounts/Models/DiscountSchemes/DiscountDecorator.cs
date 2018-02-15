using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CartAndDiscounts.Controllers;

namespace CartAndDiscounts.Models.DiscountSchemes
{
    public class DiscountDecorator : ProductDecorator
    {
        private int DiscountRate = 5;

        public DiscountDecorator(ProductAbstract product)
            :base(product)
        {
            this.OptionCode = "Discount";
            this.Price = 0;
        }

        public override string GetOptionCode()
        {
            return base.GetOptionCode() + string.Format("Disc{0}", DiscountRate);
        }

        public override decimal GetPrice()
        {
            var finalPrice = (100 - DiscountRate) * BaseProduct.GetPrice() / 100;
            return finalPrice;
        }
    }
}