using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shopping_cart
{
  public  class calculateTaxes
    {
        shoppingCart myShoppingCart;
        public calculateTaxes(shoppingCart shoppingCart)
        {
            this.myShoppingCart = shoppingCart;
        }

        public double CalculateTaxes()
        {
            double taxes = 0;
            foreach (var item in myShoppingCart.Items)
            {
                taxes += item.Item.Price * item.Item.Taxe * item.Quantity;
            }
            return taxes;
        }
    }
}
