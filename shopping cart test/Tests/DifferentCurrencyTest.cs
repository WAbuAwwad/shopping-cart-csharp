using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using shopping_cart;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace shopping_cart_test
{
    [TestClass]
    public class DifferentCurrencyTest
    {
        public shoppingCart GetShoppingCartWithSpecificCurrency(string currency)
        {
            shoppingCart myShoppingCart = new shoppingCart(currency);
            item item = new item(100, .15, shopping_cart.Type.Fruit_and_vegetables);
            cartItem myItem = new cartItem(item,1, true, 0.25, 1, 9999);
            myShoppingCart.AddItem(myItem);
            myShoppingCart.AddDiscount(new discount(shopping_cart.DiscountType.perItem, 0.0));
            return myShoppingCart;
        }

        [TestCase("USD",90)]
        [TestCase("EUR", 135)]
        [TestCase("NIS", 315)]
        [TestCase("AUD", 522)]

        public void ExchangeCurrency_ReturnPaymentInSpecifiedCurrency(string currency, double expected)
        {
            //Fixture setup
            var shoppingCart = GetShoppingCartWithSpecificCurrency(currency);
            calculatePayment calPayment = new calculatePayment(shoppingCart);
            //Exercise system
            var actual = calPayment.payment();
            //verify outcome
            Assert.AreEqual(actual, expected);

        }
    }
}
