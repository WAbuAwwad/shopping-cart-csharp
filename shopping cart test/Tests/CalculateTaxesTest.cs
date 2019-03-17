using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using shopping_cart;

namespace shopping_cart_test
{
    [TestClass]
    public class CalculateTaxesTest
    {
        [TestMethod]
        public void CalculateTexes_ReturnTaxesPercent_wheAddingOneItem()
        {
            shoppingCart myShoppingCart = new shoppingCart("USD");
            item item = new item(30, .65, shopping_cart.Type.Fruit_and_vegetables);
            cartItem myItem = new cartItem(item, 1, true, 0.05, 1, 9999);
            myShoppingCart.AddItem(myItem);
            calculateTaxes calTaxes = new calculateTaxes(myShoppingCart);
            Assert.AreEqual(calTaxes.CalculateTaxes(), 19.5);
        }
        [TestMethod]
        public void CalculateTexes_ReturnTaxesPercent_wheAddingDifferentItems()
        {
            shoppingCart myShoppingCart = new shoppingCart("USD");
            item item = new item(30, .65, shopping_cart.Type.Fruit_and_vegetables);
            cartItem myItem = new cartItem(item, 1, true, 0.05, 1, 9999);
            myShoppingCart.AddItem(myItem);
            item = new item(15.8, .15, shopping_cart.Type.Fruit_and_vegetables);
            myItem = new cartItem(item, 1, true, 0.05, 1, 9999);
            myShoppingCart.AddItem(myItem);
            calculateTaxes calTaxes = new calculateTaxes(myShoppingCart);
            Assert.AreEqual(calTaxes.CalculateTaxes(), 21.87);
        }
        [TestMethod]
        public void CalculateTexes_ReturnTaxesPercent_whenAddingDifferentQuantities()
        {
            shoppingCart myShoppingCart = new shoppingCart("USD");
            item item = new item(30, .65, shopping_cart.Type.Fruit_and_vegetables);
            cartItem myItem = new cartItem(item, 2, true, 0.05, 1, 9999);
            myShoppingCart.AddItem(myItem);
            item = new item(15.8, .15, shopping_cart.Type.Fruit_and_vegetables);
            myItem = new cartItem(item, 1, true, 0.05, 1, 9999);
            myShoppingCart.AddItem(myItem);
            calculateTaxes calTaxes = new calculateTaxes(myShoppingCart);
            Assert.AreEqual(calTaxes.CalculateTaxes(), 41.37);
        }

    }
}
