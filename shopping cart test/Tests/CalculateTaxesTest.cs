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
    public class CalculateTaxesTest
    {
        public shoppingCart GetShoppingCartWithNoItems()
        {
            return new shoppingCart("USD");
        }

        public shoppingCart GetShoppingCartWithOneItem(double taxe, int quantity)
        {
            shoppingCart myShoppingCart = new shoppingCart("USD");
            item item = new item(100,taxe, shopping_cart.Type.Fruit_and_vegetables);
            cartItem myItem = new cartItem(item, quantity, true, 0.05, 1, 9999);
            myShoppingCart.AddItem(myItem);
            return myShoppingCart;
        }

        public shoppingCart GetShoppingCartWithManyItems(double[] taxes, int[] quantities)
        {
            shoppingCart myShoppingCart = new shoppingCart("USD");
            var TexeAndQuantity = taxes.Zip(quantities, (i, j) => new { taxe = i, quantity = j });
            foreach (var value in TexeAndQuantity)
            {
                item item = new item(100, value.taxe, shopping_cart.Type.Fruit_and_vegetables);
                cartItem myItem = new cartItem(item, value.quantity, true, 0.05, 1, 9999);
                myShoppingCart.AddItem(myItem);
            }

            return myShoppingCart;
        }
        [TestMethod]
        public void CalculateTaxes_ReturnZero_WithEmptyCrat()
        {
            //Fixture setup
            var shoppingCart = GetShoppingCartWithNoItems();
            calculateTaxes calTaxes = new calculateTaxes(shoppingCart);
            //Exercise system
            var actual = calTaxes.CalculateTaxes();
            //verify outcome
            Assert.AreEqual(actual, 0);
        }

        [TestCase(.40, 1, 40)]
        [TestCase(.25, 3, 75)]
        [TestCase(.10, 1, 10)]
        [TestCase(.15, 2, 30)]
        public void CalculateTaxes_ReturnCorrectResult_whenAddingOneItem(double taxe, int quantity, double expected)
        {
            //Fixture setup
            var shoppingCart = GetShoppingCartWithOneItem(taxe, quantity);
            calculateTaxes calTaxes = new calculateTaxes(shoppingCart);
            //Exercise system
            var actual = calTaxes.CalculateTaxes();
            //verify outcome
            Assert.AreEqual(actual, expected);
        }


        [TestCase(new double[] { .3, .4 }, new int[] { 1, 1 }, 70)]
        [TestCase(new double[] { .2, .40 }, new int[] { 3, 1 }, 100)]
        [TestCase(new double[] { .25, .50 }, new int[] { 4, 2 }, 200)]
        public void CalculateTaxes_ReturnCorrectResult_WithManyItems(double[] taxes, int[] quantities, double expected)
        {
            //Fixture setup
            var shoppingCart = GetShoppingCartWithManyItems(taxes, quantities);
            calculateTaxes calTaxes = new calculateTaxes(shoppingCart);
            //Exercise system
            var actual = calTaxes.CalculateTaxes();
            //verify outcome
            Assert.AreEqual(actual, expected);
        }

    }
}
