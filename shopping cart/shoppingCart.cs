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
            this.items.Add(item);
            this.isEmpty = false;
        }

        public double CalculateTotal()
        {
            double total = 0;
            foreach (var item in items)
            {
                 double priceInUSD = item.Price* Convert.ToDouble(GetExchangeRate("USD",item.Currency)) ;
                 total += priceInUSD * item.Quantity;
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

       
        public string  GetExchangeRate(string from, string to)
        {
            using (var client = new HttpClient())
            {
                try
                {
                    var response = client.GetStringAsync(new Uri("http://apilayer.net/api/live?access_key=e7cbfc3e92bb561815abe7e82ce9069e&currencies=USD,AUD,CAD,PLN,MXN&format=1")).Result;
                    dynamic result = JValue.Parse(response);
                    if (result.success == "True")
                    {
                        string temp = from.ToUpper() + to.ToUpper();
                        return result.quotes[temp];
                    }
                    else
                    {
                     return "error in fetching data";
                    }
                }
                catch (HttpRequestException httpRequestException)
                {
                    return "error "+ httpRequestException;
                }
            }

        }
    }
}
