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
        public bool IsEmpty { get { return isEmpty; } }

        public shoppingCart(string currency,string discountType)
        {
            this.isEmpty = true;
            this.items = new List<cartItem>();
            this.currency = currency;
            this.discountType = discountType;
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
            if (this.discountType == "no discount") return 0.0;
            double discount = 0;
            if (this.discountType == "perCart")
                return discount = CalculateTotal() * this.discount;

            foreach (var item in items)
                {
                    if (this.discountType == "perItem" && item.HasDiscount)
                        discount += item.Price * item.Discount * item.Quantity;
                    else if (this.discountType == "perType" && item.HasDiscount)
                        discount += item.Price * item.Discount;
                }
            return discount;
        }

        public double payment()
        {
            double bills = CalculateTotal() + CalculateTaxes() - CalculateDiscount();
            return bills * ExchangeCurrency(this.currency);

        }
        public double  ExchangeCurrency(string currency)
        {

            if (currency.ToUpper() == "EUR") return 1.5;
            else if (currency.ToUpper() == "NIS") return 3.5;
            else if (currency.ToUpper() == "AUD") return 5.8;
            else if (currency.ToUpper() == "SAR") return 2.7;
            else return 1;
        }
    }
}
