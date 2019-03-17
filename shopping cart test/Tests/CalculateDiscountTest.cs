using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using shopping_cart;

namespace shopping_cart_test
{
    [TestClass]
    public class CalculateDiscountTest
    {

        [TestMethod]
        public void CalculatDiscount_ReturnDiscount_calculatedPerItem()
        {
            shoppingCart myShoppingCart = new shoppingCart("USD");
            discount discount = new discount(shopping_cart.DiscountType.perItem, 0.0);
            myShoppingCart.AddDiscount(discount);
            item item = new item(30, .13, shopping_cart.Type.Fruit_and_vegetables);
            cartItem myItem = new cartItem(item, 2, true, 0.15, 1, 9999);
            myShoppingCart.AddItem(myItem);
            calculateDiscount calDiscount = new calculateDiscount(myShoppingCart);
            Assert.AreEqual(calDiscount.CalculateDiscount(), 9);
        }

        [TestMethod]
        public void CalculatDiscount_ReturnDiscount_calculatedPerType()
        {
            discount discount = new discount(shopping_cart.DiscountType.perType, 0.0);
            shoppingCart myShoppingCart = new shoppingCart("USD");
            myShoppingCart.AddDiscount(discount);
            item item = new item(30, .13, shopping_cart.Type.Fruit_and_vegetables);
            cartItem myItem = new cartItem(item, 2, true, 0.15, 1, 9999);
            myShoppingCart.AddItem(myItem);
            calculateDiscount calDiscount = new calculateDiscount(myShoppingCart);
            Assert.AreEqual(calDiscount.CalculateDiscount(), 4.5);
        }

        [TestMethod]
        public void CalculatDiscount_ReturnDiscount_calculatedPerCart()
        {
            discount discount = new discount(shopping_cart.DiscountType.perCart, 0.40);
            shoppingCart myShoppingCart = new shoppingCart("USD");
            myShoppingCart.AddDiscount(discount);
            item item = new item(40, .13, shopping_cart.Type.Fruit_and_vegetables);
            cartItem myItem = new cartItem(item, 1, true, 0.15, 1, 9999);
            myShoppingCart.AddItem(myItem);
            item = new item(20, .13, shopping_cart.Type.Fruit_and_vegetables);
            myItem = new cartItem(item, 3, true, 0.15, 1, 9999);
            myShoppingCart.AddItem(myItem);
            calculateDiscount calDiscount = new calculateDiscount(myShoppingCart);
            Assert.AreEqual(calDiscount.CalculateDiscount(), 40);
        }

        [TestMethod]
        public void CalculatDiscount_ReturnDiscount_multipleDicounts()
        {
            discount discount = new discount(shopping_cart.DiscountType.perCart, 0.40);
            shoppingCart myShoppingCart = new shoppingCart("USD");
            myShoppingCart.AddDiscount(discount);
            item item = new item(40, .13, shopping_cart.Type.Fruit_and_vegetables);
            cartItem myItem = new cartItem(item, 1, true, 0.15, 1, 9999);
            myShoppingCart.AddItem(myItem);
            item = new item(20, .13, shopping_cart.Type.Fruit_and_vegetables);
            myItem = new cartItem(item, 3, true, 0.15, 1, 9999);
            myShoppingCart.AddItem(myItem);
            calculateDiscount calDiscount = new calculateDiscount(myShoppingCart);
            discount = new discount(shopping_cart.DiscountType.perItem, 0.0);
            myShoppingCart.AddDiscount(discount);
            Assert.AreEqual(calDiscount.CalculateDiscount(), 55);

        }
    }
}
