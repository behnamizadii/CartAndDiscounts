using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CartAndDiscounts.Controllers;

namespace CartAndDiscounts.Models.DiscountSchemes
{
    public class BuyOneFreeOne : ProductDecorator
    {
        //private int DiscountRate = 0;
        public BuyOneFreeOne(ProductAbstract product)
            : base(product)
        {
            OptionCode = "BuyOneFreeOne";
            Price = 0;
        }

        public override int GetQuantity()
        {
            return 2;
        }
    }
}