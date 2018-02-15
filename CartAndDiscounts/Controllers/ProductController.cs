using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CartAndDiscounts.Models;

namespace CartAndDiscounts.Controllers
{
    public class ProductController : Controller
    {
        private SC_DBContext context = new SC_DBContext();
        // GET: Product
        public ActionResult Index()
        {
            ViewBag.listProducts = context.Products.ToList();
            return View();
        }

        
    }
}