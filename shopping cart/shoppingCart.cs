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
        public bool IsEmpty { get { return isEmpty; } }
        public shoppingCart()
        {
            this.isEmpty = true;
            this.items = new List<cartItem>();
        }

        public void  AddItem(cartItem item)
        {
            double priceInUSD = item.Price * ExchangeCurrency(item.Currency);
            item.Price = priceInUSD;
            this.items.Add(item);
            this.isEmpty = false;
        }

        public double CalculateTotal()
        {
            double total = 0;
            foreach (var item in items)
            {
               
                 total += item.Price * item.Quantity;
            }
            return total;
        }
        public double CalculateTaxes()
        {
            double taxes = 0;
            foreach (var item in items)
            {
                taxes += item.Price * item.Taxe * item.Quantity;
            }
            return taxes;
        }
        public double CalculateDiscount()
        {
            double discount = 0;
            foreach (var item in items)
            {
                discount += item.Price * item.Discount * item.Quantity;
            }
            return discount;
        }

        public double  ExchangeCurrency(string currency)
        {

            if (currency.ToUpper() == "EUR") return 1.5;
            else if (currency.ToUpper() == "NIS") return 3.5;
            else if (currency.ToUpper() == "AED") return 5.8;
            else if (currency.ToUpper() == "SAR") return 2.7;
            else return 1;
        }
    }
}
