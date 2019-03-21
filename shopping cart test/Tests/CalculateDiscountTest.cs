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
    public class CalculateDiscountTest
    {

        public shoppingCart GetShoppingCartWithNoItems()
        {
            return new shoppingCart("USD");
        }

        public shoppingCart GetShoppingCartWithOneItem(double discount, int quantity)
        {
            shoppingCart myShoppingCart = new shoppingCart("USD");
            item item = new item(100, .65, shopping_cart.Type.Fruit_and_vegetables);
            cartItem myItem = new cartItem(item, quantity, true,discount, 1, 9999);
            myShoppingCart.AddItem(myItem);
            return myShoppingCart;
        }

        public shoppingCart GetShoppingCartWithManyItems(double[] discounts, int[] quantities)
        {
            shoppingCart myShoppingCart = new shoppingCart("USD");
            var DiscountAndQuantity = discounts.Zip(quantities, (i, j) => new { discount = i, quantity = j });
            foreach (var value in DiscountAndQuantity)
            {
                item item = new item(100, .65, shopping_cart.Type.Fruit_and_vegetables);
                cartItem myItem = new cartItem(item, value.quantity, true, value.discount, 1, 9999);
                myShoppingCart.AddItem(myItem);
            }

            return myShoppingCart;
        }

        [TestMethod]
        public void CalculateDiscount_ReturnZero_WithEmptyCrat()
        {
            //Fixture setup
            var shoppingCart = GetShoppingCartWithNoItems();
            calculateDiscount calDiscount = new calculateDiscount(shoppingCart);
            //Exercise system
            var actual = calDiscount.CalculateDiscount();
            //verify outcome
            Assert.AreEqual(actual, 0);
        }


        [TestCase(.40, 1, 40)]
        [TestCase(.30, 3, 90)]
        [TestCase(.25, 2, 50)]
        [TestCase(.15, 2, 30)]
        public void CalculatDiscount_ReturnCorrectResult_calculatedPerItem_WithOneItem(double discount , int quantity, double expected)
        {
            //Fixture setup
            var shoppingCart = GetShoppingCartWithOneItem(discount, quantity);
            shoppingCart.AddDiscount(new discount(shopping_cart.DiscountType.perItem, 0.0));
            calculateDiscount calDiscount = new calculateDiscount(shoppingCart);
            //Exercise system
            var actual = calDiscount.CalculateDiscount();
            //verify outcome
            Assert.AreEqual(actual, expected);
        }

        [TestCase(new double[] { .3, .4 }, new int[] { 1, 1 }, 70)]
        [TestCase(new double[] { .2, .40 }, new int[] { 3, 1 }, 100)]
        [TestCase(new double[] { .25, .50 }, new int[] { 4, 2 }, 200)]
        public void CalculateDiscount_ReturnCorrectResult_calculatedPerItem_WithManyItems(double[] discounts, int[] quantities, double expected)
        {
            //Fixture setup
            var shoppingCart = GetShoppingCartWithManyItems(discounts, quantities);
            shoppingCart.AddDiscount(new discount(shopping_cart.DiscountType.perItem, 0.0));
            calculateDiscount calDiscount = new calculateDiscount(shoppingCart);
            //Exercise system
            var actual = calDiscount.CalculateDiscount();
            //verify outcome
            Assert.AreEqual(actual, expected);
        }

        [TestCase(.40, 1, 40)]
        [TestCase(.30, 3, 30)]
        [TestCase(.25, 2, 25)]
        [TestCase(.15, 2, 15)]
        public void CalculatDiscount_ReturnCorrectResult_calculatedPerType_WithOneItem(double discount, int quantity, double expected)
        {
            //Fixture setup
            var shoppingCart = GetShoppingCartWithOneItem(discount, quantity);
            shoppingCart.AddDiscount(new discount(shopping_cart.DiscountType.perType, 0.0));
            calculateDiscount calDiscount = new calculateDiscount(shoppingCart);
            //Exercise system
            var actual = calDiscount.CalculateDiscount();
            //verify outcome
            Assert.AreEqual(actual, expected);
        }

        [TestCase(new double[] { .3, .4 }, new int[] { 1, 1 }, 70)]
        [TestCase(new double[] { .2, .40 }, new int[] { 3, 1 }, 60)]
        [TestCase(new double[] { .25, .50 }, new int[] { 4, 2 }, 75)]
        public void CalculateDiscount_ReturnCorrectResult_calculatedPerType_WithManyItems(double[] discounts, int[] quantities, double expected)
        {
            //Fixture setup
            var shoppingCart = GetShoppingCartWithManyItems(discounts, quantities);
            shoppingCart.AddDiscount(new discount(shopping_cart.DiscountType.perType, 0.0));
            calculateDiscount calDiscount = new calculateDiscount(shoppingCart);
            //Exercise system
            var actual = calDiscount.CalculateDiscount();
            //verify outcome
            Assert.AreEqual(actual, expected);
        }


        [TestCase(.40, 1, 40)]
        [TestCase(.30, 3, 120)]
        [TestCase(.25, 2, 80)]
        [TestCase(.15, 2, 80)]
        public void CalculatDiscount_ReturnCorrectResult_calculatedPerCart_WithOneItem(double discount, int quantity, double expected)
        {
            //Fixture setup
            var shoppingCart = GetShoppingCartWithOneItem(discount, quantity);
            shoppingCart.AddDiscount(new discount(shopping_cart.DiscountType.perCart, 0.40));
            calculateDiscount calDiscount = new calculateDiscount(shoppingCart);
            //Exercise system
            var actual = calDiscount.CalculateDiscount();
            //verify outcome
            Assert.AreEqual(actual, expected);
        }

        [TestCase(new double[] { .3, .4 }, new int[] { 1, 1 }, 80)]
        [TestCase(new double[] { .2, .40 }, new int[] { 3, 1 }, 160)]
        [TestCase(new double[] { .25, .50 }, new int[] { 4, 2 }, 240)]
        public void CalculateDiscount_ReturnCorrectResult_calculatedPerCart_WithManyItems(double[] discounts, int[] quantities, double expected)
        {
            //Fixture setup
            var shoppingCart = GetShoppingCartWithManyItems(discounts, quantities);
            shoppingCart.AddDiscount(new discount(shopping_cart.DiscountType.perCart, 0.40));
            calculateDiscount calDiscount = new calculateDiscount(shoppingCart);
            //Exercise system
            var actual = calDiscount.CalculateDiscount();
            //verify outcome
            Assert.AreEqual(actual, expected);
        }

        [TestCase(new double[] { .3, .4 }, new int[] { 1, 1 }, 150)]
        [TestCase(new double[] { .2, .40 }, new int[] { 3, 1 }, 220)]
        [TestCase(new double[] { .25, .50 }, new int[] { 4, 2 }, 315)]
        public void CalculatDiscount_ReturnDiscount_multipleDicounts(double[] discounts, int[] quantities, double expected)
        {
            //Fixture setup
            var shoppingCart = GetShoppingCartWithManyItems(discounts, quantities);
            shoppingCart.AddDiscount(new discount(shopping_cart.DiscountType.perCart, 0.40));
            shoppingCart.AddDiscount(new discount(shopping_cart.DiscountType.perType, 0.0));
            calculateDiscount calDiscount = new calculateDiscount(shoppingCart);
            //Exercise system
            var actual = calDiscount.CalculateDiscount();
            //verify outcome
            Assert.AreEqual(actual, expected);

        }
    }
}
