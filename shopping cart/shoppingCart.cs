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
        private ArrayList items;
        public bool IsEmpty { get { return isEmpty; } }
        public shoppingCart(int itemsMaxLimit)
        {
            this.isEmpty = true;
           this.items = new ArrayList();
        }

        public void  AddItem(cartItem item)
        {
            this.items.Add(item);
            this.isEmpty = false;
        }
        public double calculateTotal()
        {
            return 0.1;
        }
        public double calculateTaxes()
        {
            return 0.1;
        }
        public double calculateDiscount()
        {
            return 0.1;
        }
    }
}
