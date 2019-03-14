using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shopping_cart
{
   public class cartItem
    {

        private double price;
        private string currency;
        private double taxe;
        private bool hasDiscount;
        private double discount;
        public double  Price { get { return price; } }
        public string Currency { get { return currency; } }
        public double Taxe { get { return taxe; } }
        public bool HasDiscount { get { return hasDiscount; } }
        public double Discount { get { return discount; } }

        public  cartItem(double price,string currency, double taxe , bool hasDiscount,double discount)
        {
            this.price = price;
            this.currency = currency;
            this.taxe = taxe;
            this.hasDiscount = hasDiscount;
            this.discount = discount;
        }
    }
}
