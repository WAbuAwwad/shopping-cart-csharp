using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using shopping_cart;
namespace shopping_cart_test
{
    [TestClass]
    public class CalculatePaymentTest
    {

        [TestMethod]
        public void CalculatPayment_ReturnPayment_oneItem()
        {
            shoppingCart myShoppingCart = new shoppingCart("USD");
            item item = new item(30, .15, shopping_cart.Type.Fruit_and_vegetables);
            cartItem myItem = new cartItem(item, 1, true, 0.05, 1, 9999);
            myShoppingCart.AddItem(myItem);
            calculatePayment calPayment = new calculatePayment(myShoppingCart);
            Assert.AreEqual(calPayment.payment(), 34.5);
        }

        [TestMethod]
        public void CalculatPayment_ReturnPayment_forItems()
        {
            shoppingCart myShoppingCart = new shoppingCart("USD");
            Assert.AreEqual(myShoppingCart.IsEmpty, true);
            item item = new item(30, .15, shopping_cart.Type.Fruit_and_vegetables);
            cartItem myItem = new cartItem(item, 2, true, 0.05, 1, 9999);
            myShoppingCart.AddItem(myItem);
            item = new item(80, .15, shopping_cart.Type.Fruit_and_vegetables);
            myItem = new cartItem(item, 1, true, 0.05, 1, 9999);
            myShoppingCart.AddItem(myItem);
            calculatePayment calPayment = new calculatePayment(myShoppingCart);
            Assert.AreEqual(calPayment.payment(), 161);
        }

        [TestMethod]
        public void CalculatPayment_ReturnPayment_withDiscount()
        {
            shoppingCart myShoppingCart = new shoppingCart("USD");
            Assert.AreEqual(myShoppingCart.IsEmpty, true);
            item item = new item(30, .15, shopping_cart.Type.Fruit_and_vegetables);
            cartItem myItem = new cartItem(item, 1, true, 0.05, 1, 9999);
            myShoppingCart.AddItem(myItem);
            discount discount = new discount(shopping_cart.DiscountType.perItem, 0.0);
            myShoppingCart.AddDiscount(discount);
            calculatePayment calPayment = new calculatePayment(myShoppingCart);
            Assert.AreEqual(calPayment.payment(), 33);
        }
    }
}
