using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Schema;

namespace CartAndDiscounts.Models
{
    public class Item
    {
        private Product _product = new Product();

        public Product Product
        {
            get { return _product; }
            set { _product = value; }
        }
        private int _quantity;

        public int Quantity
        {
            get { return _quantity; }
            set { _quantity = value; }
        }

        private decimal _totalPrice;

        public decimal TotalPrice
        {
            get { return _totalPrice; }
            set { _totalPrice = value; }
        }

        private decimal _totalDiscount;

        public decimal TotalDiscount
        {
            get { return _totalDiscount; }
            set { _totalDiscount = value; }
        }

        public Item()
        {
            
        }

        public Item(Product product, int quantity, decimal price, decimal discount)
        {
            _product = product;
            _quantity = quantity;
            _totalPrice = price;
            _totalDiscount = discount;
        }
    }
}