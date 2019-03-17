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
            shoppingCart myShoppingCart = new shoppingCart("USD","no discount");
            Assert.AreEqual(myShoppingCart.IsEmpty,true);
        }
        [TestMethod]
        public void Add_Item()
        {
            shoppingCart myShoppingCart = new shoppingCart("USD", "no discount");
            cartItem myItem = new cartItem(1,30, 0.65, true, 0.05,5,888,"red","food");
            Assert.AreEqual(myShoppingCart.IsEmpty, true);
            myShoppingCart.AddItem(myItem);
            Assert.AreEqual(myShoppingCart.IsEmpty, false);

        }
        [TestMethod]
        public void Calculate_Total()
        {
            shoppingCart myShoppingCart = new shoppingCart("USD", "no discount");
            Assert.AreEqual(myShoppingCart.IsEmpty, true);
            cartItem myItem = new cartItem(2,30, 0.65, true, 0.05, 5, 888, "red", "food");
            myShoppingCart.AddItem(myItem);
            Assert.AreEqual(myShoppingCart.CalculateTotal(),60);
            cartItem myItem1 = new cartItem(1,15.8, 0.65, true, 0.05, 5, 888, "red", "food");
            myShoppingCart.AddItem(myItem1);
            Assert.AreEqual(myShoppingCart.CalculateTotal(), 75.8);
        }
        [TestMethod]
        public void Calculate_Texes()
        {
            shoppingCart myShoppingCart = new shoppingCart("USD", "no discount");
            Assert.AreEqual(myShoppingCart.IsEmpty, true);
            cartItem myItem = new cartItem(1,30, 0.65, true, 0.05, 5, 888, "red", "food");
            myShoppingCart.AddItem(myItem);
            Assert.AreEqual(myShoppingCart.CalculateTaxes(), 19.5);
            cartItem myItem1 = new cartItem(1,15.8, 0.15, true, 0.05, 5, 888, "red", "food");
            myShoppingCart.AddItem(myItem1);
            Assert.AreEqual(myShoppingCart.CalculateTaxes(), 21.87);
        }
        [TestMethod]
        public void Calculate_discount_all_cases()
        {
            shoppingCart myShoppingCart = new shoppingCart("USD", "no discount");
            Assert.AreEqual(myShoppingCart.IsEmpty, true);
            cartItem myItem = new cartItem(1,30, 0.65, false, 0.0, 5, 888, "red", "food");
            myShoppingCart.AddItem(myItem);
            Assert.AreEqual(myShoppingCart.CalculateDiscount(),0);
            myShoppingCart = new shoppingCart("USD", "perItem");
            myItem = new cartItem(1, 30,0.65, false, 0.0, 5, 888, "red", "food");
            myShoppingCart.AddItem(myItem);
            Assert.AreEqual(myShoppingCart.CalculateDiscount(), 0);
            myShoppingCart = new shoppingCart("USD", "perItem");
            myItem = new cartItem(2, 30, 0.65, true, 0.05, 5, 888, "red", "food");
            myShoppingCart.AddItem(myItem);
            Assert.AreEqual(myShoppingCart.CalculateDiscount(),3);
            myShoppingCart = new shoppingCart("USD", "perType");
            myItem = new cartItem(2, 30, 0.65, true, 0.05, 5, 888, "red", "food");
            myShoppingCart.AddItem(myItem);
            Assert.AreEqual(myShoppingCart.CalculateDiscount(), 1.5);
            myShoppingCart = new shoppingCart("USD", "perCart" , 0.40);
            myItem = new cartItem(1, 40, 0.65, true, 0.05, 5, 888, "red", "food");
            myShoppingCart.AddItem(myItem);
            myItem = new cartItem(3, 20, 0.65, true, 0.05, 5, 888, "red", "food");
            myShoppingCart.AddItem(myItem);
            Assert.AreEqual(myShoppingCart.CalculateDiscount(), 40);

        }
        [TestMethod]
        public void Dealing_with_currency()
        {
            shoppingCart myShoppingCart = new shoppingCart("USD", "no discount");
            Assert.AreEqual(myShoppingCart.IsEmpty, true);
            cartItem myItem = new cartItem(1,30,0.15, true, 0.05, 5, 888, "red", "food");
            myShoppingCart.AddItem(myItem);
            Assert.AreEqual(myShoppingCart.payment(), 34.5);
            myShoppingCart = new shoppingCart("EUR", "no discount");
            myItem = new cartItem(1, 30, 0.15, true, 0.05, 5, 888, "red", "food");
            myShoppingCart.AddItem(myItem);
            Assert.AreEqual(myShoppingCart.payment(), 51.75);
        }
    }
}
