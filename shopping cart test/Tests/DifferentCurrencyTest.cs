using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using shopping_cart;

namespace shopping_cart_test
{
    [TestClass]
    public class DifferentCurrencyTest
    {
        [TestMethod]
        public void ExchangeCurrency_ReturnPaymentInSpecifiedCurrency()
        {

            shoppingCart myShoppingCart = new shoppingCart("USD");
            item item = new item(30, .15, shopping_cart.Type.Fruit_and_vegetables);
            cartItem myItem = new cartItem(item, 1, true, 0.05, 1, 9999);
            myShoppingCart.AddItem(myItem);
            calculatePayment calPayment = new calculatePayment(myShoppingCart);
            Assert.AreEqual(calPayment.payment(), 34.5);
            myShoppingCart = new shoppingCart("EUR");
            item = new item(30, .15, shopping_cart.Type.Fruit_and_vegetables);
            myItem = new cartItem(item, 1, true, 0.05, 1, 9999);
            myShoppingCart.AddItem(myItem);
            calPayment = new calculatePayment(myShoppingCart);
            Assert.AreEqual(calPayment.payment(), 51.75);
        }
    }
}
