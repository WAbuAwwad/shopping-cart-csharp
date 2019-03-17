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
            item item = new item(40, .13, shopping_cart.Type.Fruit_and_vegetables);
            cartItem myItem = new cartItem(item,1,true, 0.05,1,9999);
            Assert.AreEqual(myShoppingCart.IsEmpty, true);
            myShoppingCart.AddItem(myItem);
            Assert.AreEqual(myShoppingCart.IsEmpty, false);

        }
        [TestMethod]
        public void Calculate_Total()
        {
            shoppingCart myShoppingCart = new shoppingCart("USD", "no discount");
            Assert.AreEqual(myShoppingCart.IsEmpty, true);
            item item = new item(30, .65, shopping_cart.Type.Fruit_and_vegetables);
            cartItem myItem = new cartItem(item, 2, true, 0.05, 1, 9999);
            myShoppingCart.AddItem(myItem);
            Assert.AreEqual(myShoppingCart.CalculateTotal(),60);
            item = new item(15.8, .13, shopping_cart.Type.Fruit_and_vegetables);
            myItem = new cartItem(item, 1, true, 0.05, 1, 9999);
            myShoppingCart.AddItem(myItem);
            Assert.AreEqual(myShoppingCart.CalculateTotal(), 75.8);
        }
        [TestMethod]
        public void Calculate_Texes()
        {
            shoppingCart myShoppingCart = new shoppingCart("USD", "no discount");
            Assert.AreEqual(myShoppingCart.IsEmpty, true);
            item item = new item(30, .65, shopping_cart.Type.Fruit_and_vegetables);
            cartItem myItem = new cartItem(item, 1, true, 0.05, 1, 9999);
            myShoppingCart.AddItem(myItem);
            Assert.AreEqual(myShoppingCart.CalculateTaxes(), 19.5);
            item = new item(15.8, .15, shopping_cart.Type.Fruit_and_vegetables);
            myItem = new cartItem(item, 1, true, 0.05, 1, 9999);
            myShoppingCart.AddItem(myItem);
            Assert.AreEqual(myShoppingCart.CalculateTaxes(), 21.87);
        }
        [TestMethod]
        public void Calculate_discount_all_cases()
        {
            shoppingCart myShoppingCart = new shoppingCart("USD", "no discount");
            Assert.AreEqual(myShoppingCart.IsEmpty, true);
            item item = new item(30, .13, shopping_cart.Type.Fruit_and_vegetables);
            cartItem myItem = new cartItem(item, 1, true, 0.65, 1, 9999);
            myShoppingCart.AddItem(myItem);
            Assert.AreEqual(myShoppingCart.CalculateDiscount(),0);
            myShoppingCart = new shoppingCart("USD", "perItem");
            item = new item(30, .65, shopping_cart.Type.Fruit_and_vegetables);
            myItem = new cartItem(item, 1, false, 0.05, 1, 9999);
            myShoppingCart.AddItem(myItem);
            Assert.AreEqual(myShoppingCart.CalculateDiscount(), 0);
            myShoppingCart = new shoppingCart("USD", "perItem");
            item = new item(30, .65, shopping_cart.Type.Fruit_and_vegetables);
            myItem = new cartItem(item,2, true, 0.05, 1, 9999);
            myShoppingCart.AddItem(myItem);
            Assert.AreEqual(myShoppingCart.CalculateDiscount(),3);
            myShoppingCart = new shoppingCart("USD", "perType");
            item = new item(30, .65, shopping_cart.Type.Fruit_and_vegetables);
            myItem = new cartItem(item, 2, true, 0.05, 1, 9999);
            myShoppingCart.AddItem(myItem);
            Assert.AreEqual(myShoppingCart.CalculateDiscount(), 1.5);
            myShoppingCart = new shoppingCart("USD", "perCart" , 0.40);
            item = new item(40, .65, shopping_cart.Type.Fruit_and_vegetables);
            myItem = new cartItem(item, 1, true, 0.05, 1, 9999);
            myShoppingCart.AddItem(myItem);
            item = new item(20, .65, shopping_cart.Type.Fruit_and_vegetables);
            myItem = new cartItem(item, 3, true, 0.05, 1, 9999);
            myShoppingCart.AddItem(myItem);
            Assert.AreEqual(myShoppingCart.CalculateDiscount(), 40);

        }
        [TestMethod]
        public void Dealing_with_currency()
        {
            shoppingCart myShoppingCart = new shoppingCart("USD", "no discount");
            Assert.AreEqual(myShoppingCart.IsEmpty, true);
            item item = new item(30, .15, shopping_cart.Type.Fruit_and_vegetables);
            cartItem myItem = new cartItem(item, 1, true, 0.05, 1, 9999);
            myShoppingCart.AddItem(myItem);
            Assert.AreEqual(myShoppingCart.payment(), 34.5);
            myShoppingCart = new shoppingCart("EUR", "no discount");
            item = new item(30, .15, shopping_cart.Type.Fruit_and_vegetables);
            myItem = new cartItem(item, 1, true, 0.05, 1, 9999);
            myShoppingCart.AddItem(myItem);
            Assert.AreEqual(myShoppingCart.payment(), 51.75);
        }
    }
}
