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
        private double taxe;
        private bool hasDiscount;
        private double discount;
        private int quantity;
        private int itemId;
        private long soldTo;
        private string color;
        private string type;
        public double  Price { get { return price; }}
        public double Taxe { get { return taxe; } }
        public bool HasDiscount { get { return hasDiscount; } }
        public double Discount { get { return discount; } }
        public int Quantity { get { return quantity; } }
        public  cartItem(int quantity,double price, 
                          double taxe , bool hasDiscount,double discount,int id , int soldTo , string color, string type)
        {
            this.price = price;
            this.taxe = taxe;
            this.hasDiscount = hasDiscount;
            this.discount = discount;
            this.quantity = quantity;
            this.itemId = id;
            this.soldTo = soldTo;
            this.color = color;
            this.type = type;
        }
    }
}
