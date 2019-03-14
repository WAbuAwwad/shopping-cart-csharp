using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using shopping_cart;
namespace shopping_cart_test
{
    [TestClass]
    public class UnitTest
    {
        [TestMethod]
        public void initial_state()
        {
            shoppingCart myShoppingCart = new shoppingCart();
            Assert.AreEqual(myShoppingCart.IsEmpty,true);
        }
        [TestMethod]
        public void Add_Item()
        {
            shoppingCart myShoppingCart = new shoppingCart();
            cartItem myItem = new cartItem(30, 0.65, true, 0.05);
            Assert.AreEqual(myShoppingCart.IsEmpty, true);
            myShoppingCart.AddItem(myItem);
            Assert.AreEqual(myShoppingCart.IsEmpty, false);

        }
        [TestMethod]
        public void Calculate_Total()
        {
            shoppingCart myShoppingCart = new shoppingCart();
            Assert.AreEqual(myShoppingCart.IsEmpty, true);
            cartItem myItem = new cartItem(30, 0.65, true, 0.05);
            myShoppingCart.AddItem(myItem);
            Assert.AreEqual(myShoppingCart.CalculateTotal(),30);
            cartItem myItem1 = new cartItem(15.8, 0.65, true, 0.05);
            myShoppingCart.AddItem(myItem1);
            Assert.AreEqual(myShoppingCart.CalculateTotal(), 45.8);
        }
        [TestMethod]
        public void Calculate_Texes()
        {
            shoppingCart myShoppingCart = new shoppingCart();
            Assert.AreEqual(myShoppingCart.IsEmpty, true);
            cartItem myItem = new cartItem(30, 0.65, true, 0.05);
            myShoppingCart.AddItem(myItem);
            Assert.AreEqual(myShoppingCart.CalculateTaxes(), 19.5);
            cartItem myItem1 = new cartItem(15.8, 0.15, true, 0.05);
            myShoppingCart.AddItem(myItem1);
            Assert.AreEqual(myShoppingCart.CalculateTaxes(), 21.87);
        }
        [TestMethod]
        public void Calculate_discount()
        {
            shoppingCart myShoppingCart = new shoppingCart();
            Assert.AreEqual(myShoppingCart.IsEmpty, true);
            cartItem myItem = new cartItem(30, 0.65, true, 0.05);
            myShoppingCart.AddItem(myItem);
            Assert.AreEqual(myShoppingCart.CalculateDiscount(),1.5);
            cartItem myItem1 = new cartItem(15.8, 0.15, true, 0.25);
            myShoppingCart.AddItem(myItem1);
            Assert.AreEqual(myShoppingCart.CalculateDiscount(),5.45);
        }
    }
}
