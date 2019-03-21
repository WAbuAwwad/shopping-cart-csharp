using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using shopping_cart;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace shopping_cart_test
{
    [TestClass]
    public class CalculatePaymentTest
    {

        public shoppingCart GetShoppingCartWithNoItems()
        {
            return new shoppingCart("USD");
        }

        public shoppingCart GetShoppingCartWithOneItem(double price, double taxe, double discount, int quantity)
        {
            shoppingCart myShoppingCart = new shoppingCart("USD");
            item item = new item(price, taxe, shopping_cart.Type.Fruit_and_vegetables);
            cartItem myItem = new cartItem(item, quantity, true, discount, 1, 9999);
            myShoppingCart.AddItem(myItem);
            return myShoppingCart;
        }



        [TestMethod]
        public void CalculatePayment_ReturnZero_WithEmptyCrat()
        {
            //Fixture setup
            var shoppingCart = GetShoppingCartWithNoItems();
            calculatePayment payment = new calculatePayment(shoppingCart);
            //Exercise system
            var actual = payment.payment();
            //verify outcome
            Assert.AreEqual(actual, 0);
        }

        [TestCase(100,.10,.20, 1, 90)]
        [TestCase(100, .15, .25, 1, 90)]
        public void CalculatPayment_ReturnCorrectResult_WithOneItem(double price , double taxe , double discount ,int quantity ,double expected)
        {
            //Fixture setup
            var shoppingCart = GetShoppingCartWithOneItem(price,taxe,discount, quantity);
            shoppingCart.AddDiscount(new discount(shopping_cart.DiscountType.perItem, 0.0));
            calculatePayment calPayment = new calculatePayment(shoppingCart);
            //Exercise system
            var actual = calPayment.payment();
            //verify outcome
            Assert.AreEqual(actual, expected);
        }
    }
}
