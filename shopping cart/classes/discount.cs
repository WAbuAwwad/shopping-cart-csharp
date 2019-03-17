using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shopping_cart
{

    public enum DiscountType
    {noDiscount , perItem, perType, perCart }
    
    public class discount
    {
        private DiscountType type;
        private double percentage;
        public DiscountType Type { get{ return type; } }
        public double Percentage { get{ return percentage; } }

        public discount(DiscountType type , double percentage)
        {
            this.type = type;
            this.percentage = percentage;
        }
    }
}
