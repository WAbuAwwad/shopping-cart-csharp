using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net.Http;


namespace shopping_cart
{
   public class shoppingCart
    {
        private bool isEmpty;
        private List<cartItem> items ;
        private string discountType;
        private double discount;
        private string currency;
        private bool isPaid;
        public bool IsEmpty { get { return isEmpty; } }
        public List<cartItem>Items { get{ return items; } }
        public string DiscountType { get{ return discountType; }}
        public double Discount { get { return discount; } }
        public string Currency { get { return currency; } }
        public shoppingCart(string currency,string discountType)
        {
            this.isEmpty = true;
            this.items = new List<cartItem>();
            this.currency = currency;
            this.discountType = discountType;
            this.isPaid = false;
        }
        public shoppingCart(string currency, string discountType ,double discount)
        {
            this.isEmpty = true;
            this.items = new List<cartItem>();
            this.currency = currency;
            this.discountType = discountType;
            this.discount = discount;
        }
        public void  AddItem(cartItem item)
        {
            this.items.Add(item);
            this.isEmpty = false;
        }


       


    }
}
