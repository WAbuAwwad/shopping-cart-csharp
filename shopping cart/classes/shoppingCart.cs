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
        private List<discount> discounts;
        private string currency;
        private bool isPaid;
        public bool IsEmpty { get { return isEmpty; } }
        public List<cartItem>Items { get{ return items; } }
        public List<discount> Discounts { get{ return discounts; }}
        public string Currency { get { return currency; } }
        public shoppingCart(string currency)
        {
            this.isEmpty = true;
            this.items = new List<cartItem>();
            this.currency = currency;
            this.discounts = new List<discount>();
            this.isPaid = false;
        }

        public void  AddItem(cartItem item)
        {
            this.items.Add(item);
            this.isEmpty = false;
        }

        public void AddDiscount(discount discount)
        {
            this.discounts.Add(discount);

        }



    }
}
