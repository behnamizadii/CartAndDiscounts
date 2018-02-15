using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web;
using System.Web.DynamicData;
using System.Web.Mvc;
using CartAndDiscounts.Models;
using CartAndDiscounts.Models.DiscountSchemes;
using Microsoft.SqlServer.Server;

namespace CartAndDiscounts.Controllers
{
    public class CartController : Controller
    {
        private SC_DBContext context = new SC_DBContext();
        // GET: Cart
        public ActionResult Index()
        {
            return View();
        }

        private int ItemExist(int id)
        {
            List<Item> cart = (List<Item>)Session["cart"];
            for (int i = 0; i < cart.Count; i++)
            {
                if (cart[i].Product.ProductId == id)
                    return i;
            }
            return -1;
        }

        private int QuantityCount(int id)
        {
            List<Item> cart = (List<Item>) Session["cart"];
            int quantity = cart.Find(x => x.Product.ProductId == id).Quantity;
            return quantity;
        }

        //Assumption : all the items are eligible for buy one free one
        //This method is messy if I had more time I would have refactored it.
        //i.e. product definitely requires null check...
        public ActionResult AddToCart(int id)
        {
            List<Item> cart;
            var product = context.Products.Find(id);
            var item = GetDiscount(product, "TODAY5", true);
            var discount = product.Price - item.TotalPrice;
            if (Session["cart"] == null)
            {
                cart = new List<Item>();
                cart.Add(new Item(product, item.Quantity, item.TotalPrice, discount));
                Session["cart"] = cart;
            }
            else
            {
                cart = (List<Item>)Session["cart"];
                int index = ItemExist(id);
                if (index == -1)
                    cart.Add(new Item(product, item.Quantity, item.TotalPrice, discount));
                else
                {
                    cart[index].Quantity += item.Quantity;
                    cart[index].TotalPrice += item.TotalPrice;
                    cart[index].TotalDiscount += discount;
                }
                Session["cart"] = cart;
            }
            ViewBag.totalPrice = CalculateTotalPrice(cart);
            ViewBag.totalDiscount = CalculateTotalDiscount(cart);
            return View("Cart");
        }


        private decimal CalculateTotalDiscount(List<Item> items)
        {
            decimal total = 0;
            foreach (var item in items)
            {
                total += item.TotalDiscount;
            }
            return total;
        }
        private decimal CalculateTotalPrice(List<Item> items)
        {
            decimal total = 0;
            foreach (var item in items)
            {
                total += item.TotalPrice;
            }
            return total;
        }


        //Get Discount on Individual Item
        private Item GetDiscount(Product product, string discountCode, bool isEligibleForFreeOne)
        {
            ProductBase productBase = new ProductBase(product);
            var item = new Item();
            
            ProductDecorator discountDecorator;
            if (discountCode == "TODAY5") // Requires a validator against DB but for now assumption is a discount TODAY5 is given to the user
            {
                discountDecorator = new DiscountDecorator(productBase);
            }
            else
            {
                discountDecorator = new DiscountDecorator(productBase);
            }

            ProductDecorator buy1free1Decorator;
            if (isEligibleForFreeOne)
            {
                buy1free1Decorator = new BuyOneFreeOne(discountDecorator);
            }
            else
            {
                buy1free1Decorator = discountDecorator;
            }
            
            var pr = buy1free1Decorator.ProductId + buy1free1Decorator.GetOptionCode();
            //This line of code could be used to check the Discount Tag and store it in DB
            //For example we might want to know which discounts are used in a purchase
            item.TotalPrice = buy1free1Decorator.GetPrice();
            item.Quantity = buy1free1Decorator.GetQuantity();
            return item;
        }
    }
}