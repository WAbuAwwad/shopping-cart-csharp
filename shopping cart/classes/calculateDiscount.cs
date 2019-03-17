using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shopping_cart
{
 public   class calculateDiscount
    {
        shoppingCart myShoppingCart;
        calculateTotal calTotal;
        public calculateDiscount(shoppingCart shoppingCart)
        {
            this.myShoppingCart = shoppingCart;
            this.calTotal = new calculateTotal(myShoppingCart);
        }
        public double CalculateDiscount()
        {
            if (myShoppingCart.DiscountType == "no discount") return 0.0;
            double discount = 0;
            if (myShoppingCart.DiscountType == "perCart")
                return discount = calTotal.CalculateTotal() * myShoppingCart.Discount;

            foreach (var item in myShoppingCart.Items)
            {
                if (myShoppingCart.DiscountType == "perItem" && item.HasDiscount)
                    discount += item.Item.Price * item.Discount * item.Quantity;
                else if (myShoppingCart.DiscountType == "perType" && item.HasDiscount)
                    discount += item.Item.Price * item.Discount;
            }
            return discount;
        }



    }
}
