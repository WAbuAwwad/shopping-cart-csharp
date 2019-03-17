using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using shopping_cart;

namespace shopping_cart_test
    {
   [TestClass]
   public  class CalculateTotalTest
    {
        [TestMethod]
        public void CalculateTotal_ReturnItemPrice_whenAddingOneItem()
        {
  
            shoppingCart myShoppingCart = new shoppingCart("USD");
            item item = new item(30, .65, shopping_cart.Type.Fruit_and_vegetables);
            cartItem myItem = new cartItem(item, 1, true, 0.05, 1, 9999);
            myShoppingCart.AddItem(myItem);
            calculateTotal calTotal = new calculateTotal(myShoppingCart);
            Assert.AreEqual(calTotal.CalculateTotal(), 30);

        }
        [TestMethod]
        public void CalculateTotal_ReturnTotalPrice_whenAddingDifferentItems()
        {
            shoppingCart myShoppingCart = new shoppingCart("USD");
            Assert.AreEqual(myShoppingCart.IsEmpty, true);
            item item = new item(30, .65, shopping_cart.Type.Fruit_and_vegetables);
            cartItem myItem = new cartItem(item, 1, true, 0.05, 1, 9999);
            myShoppingCart.AddItem(myItem);
            item = new item(15.8, .13, shopping_cart.Type.Fruit_and_vegetables);
            myItem = new cartItem(item, 1, true, 0.05, 1, 9999);
            myShoppingCart.AddItem(myItem);
            calculateTotal calTotal = new calculateTotal(myShoppingCart);
            Assert.AreEqual(calTotal.CalculateTotal(), 45.8);
        }
        [TestMethod]
        public void CalculateTotal_ReturnTotalPrice_whenAddingDifferentQuantities()
        {
            shoppingCart myShoppingCart = new shoppingCart("USD");
            Assert.AreEqual(myShoppingCart.IsEmpty, true);
            item item = new item(30, .65, shopping_cart.Type.Fruit_and_vegetables);
            cartItem myItem = new cartItem(item, 2, true, 0.05, 1, 9999);
            myShoppingCart.AddItem(myItem);
            item = new item(15.8, .13, shopping_cart.Type.Fruit_and_vegetables);
            myItem = new cartItem(item, 1, true, 0.05, 1, 9999);
            myShoppingCart.AddItem(myItem);
            calculateTotal calTotal = new calculateTotal(myShoppingCart);
            Assert.AreEqual(calTotal.CalculateTotal(), 75.8);
        }

    }
}
