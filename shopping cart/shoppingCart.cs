using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                total += item.Price;
            }
            return total;
        }
        public double CalculateTaxes()
        {
            return 0.1;
        }
        public double CalculateDiscount()
        {
            return 0.1;
        }
    }
}
