using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using shopping_cart;

namespace shopping_cart_test
{
    [TestClass]
    public class AddItemTest
    {
        [TestMethod]
        public void AddItem_RetunEmptyCart_whenNotAdingItems()
        {
            shoppingCart myShoppingCart = new shoppingCart("USD");
            Assert.AreEqual(myShoppingCart.IsEmpty, true);
        }

        [TestMethod]
        public void AddItem_RetunNotEmptyCart_whenAddingItem()
        {
            shoppingCart myShoppingCart = new shoppingCart("USD");
            item item = new item(40, .13, shopping_cart.Type.Fruit_and_vegetables);
            cartItem myItem = new cartItem(item, 1, true, 0.05, 1, 9999);
            myShoppingCart.AddItem(myItem);
            Assert.AreEqual(myShoppingCart.IsEmpty, false);
        }
    }
}
