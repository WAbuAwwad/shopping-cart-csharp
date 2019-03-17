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
            calculateTotal calTotal = new calculateTotal(myShoppingCart);
            Assert.AreEqual(calTotal.CalculateTotal(),60);
            item = new item(15.8, .13, shopping_cart.Type.Fruit_and_vegetables);
            myItem = new cartItem(item, 1, true, 0.05, 1, 9999);
            myShoppingCart.AddItem(myItem);
            calTotal = new calculateTotal(myShoppingCart);
            Assert.AreEqual(calTotal.CalculateTotal(), 75.8);
        }
        [TestMethod]
        public void Calculate_Texes()
        {
            shoppingCart myShoppingCart = new shoppingCart("USD", "no discount");
            Assert.AreEqual(myShoppingCart.IsEmpty, true);
            item item = new item(30, .65, shopping_cart.Type.Fruit_and_vegetables);
            cartItem myItem = new cartItem(item, 1, true, 0.05, 1, 9999);
            myShoppingCart.AddItem(myItem);
            calculateTaxes calTaxes = new calculateTaxes(myShoppingCart);
            Assert.AreEqual(calTaxes.CalculateTaxes(), 19.5);
            item = new item(15.8, .15, shopping_cart.Type.Fruit_and_vegetables);
            myItem = new cartItem(item, 1, true, 0.05, 1, 9999);
            myShoppingCart.AddItem(myItem);
            calTaxes = new calculateTaxes(myShoppingCart);
            Assert.AreEqual(calTaxes.CalculateTaxes(), 21.87);
        }
        [TestMethod]
        public void Calculate_discount_all_cases()
        {
            shoppingCart myShoppingCart = new shoppingCart("USD", "no discount");
            Assert.AreEqual(myShoppingCart.IsEmpty, true);
            item item = new item(30, .13, shopping_cart.Type.Fruit_and_vegetables);
            cartItem myItem = new cartItem(item, 1, true, 0.65, 1, 9999);
            myShoppingCart.AddItem(myItem);
            calculateDiscount calDiscount = new calculateDiscount(myShoppingCart);
            Assert.AreEqual(calDiscount.CalculateDiscount(),0);
            myShoppingCart = new shoppingCart("USD", "perItem");
            item = new item(30, .65, shopping_cart.Type.Fruit_and_vegetables);
            myItem = new cartItem(item, 1, false, 0.05, 1, 9999);
            myShoppingCart.AddItem(myItem);
            calDiscount = new calculateDiscount(myShoppingCart);
            Assert.AreEqual(calDiscount.CalculateDiscount(), 0);
            myShoppingCart = new shoppingCart("USD", "perItem");
            item = new item(30, .65, shopping_cart.Type.Fruit_and_vegetables);
            myItem = new cartItem(item,2, true, 0.05, 1, 9999);
            myShoppingCart.AddItem(myItem);
            calDiscount = new calculateDiscount(myShoppingCart);
            Assert.AreEqual(calDiscount.CalculateDiscount(),3);
            myShoppingCart = new shoppingCart("USD", "perType");
            item = new item(30, .65, shopping_cart.Type.Fruit_and_vegetables);
            myItem = new cartItem(item, 2, true, 0.05, 1, 9999);
            myShoppingCart.AddItem(myItem);
            calDiscount = new calculateDiscount(myShoppingCart);
            Assert.AreEqual(calDiscount.CalculateDiscount(), 1.5);
            myShoppingCart = new shoppingCart("USD", "perCart" , 0.40);
            item = new item(40, .65, shopping_cart.Type.Fruit_and_vegetables);
            myItem = new cartItem(item, 1, true, 0.05, 1, 9999);
            myShoppingCart.AddItem(myItem);
            item = new item(20, .65, shopping_cart.Type.Fruit_and_vegetables);
            myItem = new cartItem(item, 3, true, 0.05, 1, 9999);
            myShoppingCart.AddItem(myItem);
            calDiscount = new calculateDiscount(myShoppingCart);
            Assert.AreEqual(calDiscount.CalculateDiscount(), 40);

        }
        [TestMethod]
        public void Dealing_with_currency()
        {
            shoppingCart myShoppingCart = new shoppingCart("USD", "no discount");
            Assert.AreEqual(myShoppingCart.IsEmpty, true);
            item item = new item(30, .15, shopping_cart.Type.Fruit_and_vegetables);
            cartItem myItem = new cartItem(item, 1, true, 0.05, 1, 9999);
            myShoppingCart.AddItem(myItem);
            calculatePayment calPayment = new calculatePayment(myShoppingCart);
            Assert.AreEqual(calPayment.payment(), 34.5);
            myShoppingCart = new shoppingCart("EUR", "no discount");
            item = new item(30, .15, shopping_cart.Type.Fruit_and_vegetables);
            myItem = new cartItem(item, 1, true, 0.05, 1, 9999);
            myShoppingCart.AddItem(myItem);
            calPayment = new calculatePayment(myShoppingCart);
            Assert.AreEqual(calPayment.payment(), 51.75);
        }
    }
}
