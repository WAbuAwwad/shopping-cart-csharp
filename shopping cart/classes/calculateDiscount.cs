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
            double discount = 0;
            foreach (var Discount in myShoppingCart.Discounts)
            {
                if (Discount.Type == DiscountType.noDiscount) discount+= 0.0;
                
                if (Discount.Type == DiscountType.perCart)
                    discount += calTotal.CalculateTotal() * Discount.Percentage;

                foreach (var item in myShoppingCart.Items)
                {
                    if (Discount.Type == DiscountType.perItem  && item.HasDiscount)
                        discount += item.Item.Price * item.Discount * item.Quantity;
                    else if (Discount.Type == DiscountType.perType && item.HasDiscount)
                        discount += item.Item.Price * item.Discount;
                }
            }
            return discount;
        }


    }
}
