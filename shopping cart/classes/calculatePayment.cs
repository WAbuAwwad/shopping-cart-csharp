using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shopping_cart
{
   public class calculatePayment
    {
        shoppingCart myShoppingCart;
        calculateTotal calTotal;
        calculateTaxes calTaxes;
        calculateDiscount calDiscount;
        exchangeRate exRate;
        public calculatePayment(shoppingCart shoppingCart)
        {
            this.myShoppingCart = shoppingCart;
            this.calTotal = new calculateTotal(myShoppingCart);
            this.calTaxes = new calculateTaxes(myShoppingCart);
            this.calDiscount = new calculateDiscount(myShoppingCart);
            this.exRate = new exchangeRate();
        }

        public double payment()
        {
            double bills = calTotal.CalculateTotal() + calTaxes.CalculateTaxes() - calDiscount.CalculateDiscount();
            return bills * exRate.ExchangeCurrency(myShoppingCart.Currency);

        }

    }
}
