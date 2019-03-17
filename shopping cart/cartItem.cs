using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shopping_cart
{
   public class cartItem
    {
        private item item;
        private bool hasDiscount;
        private double discount;
        private int quantity;
        private int itemId;
        private long soldTo;
        public bool HasDiscount { get { return hasDiscount; } }
        public double Discount { get { return discount; } }
        public int Quantity { get { return quantity; } }
        public item Item { get { return item; } }
        public  cartItem(item item, int quantity ,bool hasDiscount,double discount,int id , int soldTo)
        {
            this.item = item;
            this.hasDiscount = hasDiscount;
            this.discount = discount;
            this.quantity = quantity;
            this.itemId = id;
            this.soldTo = soldTo;
        }
    }
}
