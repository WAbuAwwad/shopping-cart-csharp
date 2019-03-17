using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shopping_cart
{
public  class calculateTotal
    {
        shoppingCart myShoppingCart;
     public  calculateTotal(shoppingCart shoppingCart)
        {
            this.myShoppingCart = shoppingCart;
        }


        public double CalculateTotal()
        {
            double total = 0;
            foreach (var item in myShoppingCart.Items)
            {

                total += item.Item.Price * item.Quantity;
            }
            return total;
        }

    }
}
