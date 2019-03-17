﻿using System;
using System.Collections.Generic;
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
            shoppingCart myShoppingCart = new shoppingCart("USD");
            Assert.AreEqual(myShoppingCart.IsEmpty, true);
        }
        [TestMethod]
        public void Add_Item()
        {
            
            shoppingCart myShoppingCart = new shoppingCart("USD");
            item item = new item(40, .13, shopping_cart.Type.Fruit_and_vegetables);
            cartItem myItem = new cartItem(item, 1, true, 0.05, 1, 9999);
            Assert.AreEqual(myShoppingCart.IsEmpty, true);
            myShoppingCart.AddItem(myItem);
            Assert.AreEqual(myShoppingCart.IsEmpty, false);

        }
        [TestMethod]
        public void Calculate_Total()
        {
            shoppingCart myShoppingCart = new shoppingCart("USD");
            Assert.AreEqual(myShoppingCart.IsEmpty, true);
            item item = new item(30, .65, shopping_cart.Type.Fruit_and_vegetables);
            cartItem myItem = new cartItem(item, 2, true, 0.05, 1, 9999);
            myShoppingCart.AddItem(myItem);
            calculateTotal calTotal = new calculateTotal(myShoppingCart);
            Assert.AreEqual(calTotal.CalculateTotal(), 60);
            item = new item(15.8, .13, shopping_cart.Type.Fruit_and_vegetables);
            myItem = new cartItem(item, 1, true, 0.05, 1, 9999);
            myShoppingCart.AddItem(myItem);
            calTotal = new calculateTotal(myShoppingCart);
            Assert.AreEqual(calTotal.CalculateTotal(), 75.8);
        }
        [TestMethod]
        public void Calculate_Texes()
        {

            
            shoppingCart myShoppingCart = new shoppingCart("USD");
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
        public void Calculate_one_discount_perItem()
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
        public void Calculate_one_discount_perType()
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
        public void Calculate_one_discount_perCart ()
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
        public void Calculate_discounts()
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

            discount = new discount(shopping_cart.DiscountType.perItem, 0.0);
            myShoppingCart.AddDiscount(discount);
            Assert.AreEqual(calDiscount.CalculateDiscount(),55);

        }

        [TestMethod]
        public void Dealing_with_currency()
        {
            
            
            shoppingCart myShoppingCart = new shoppingCart("USD");
            Assert.AreEqual(myShoppingCart.IsEmpty, true);
            item item = new item(30, .15, shopping_cart.Type.Fruit_and_vegetables);
            cartItem myItem = new cartItem(item, 1, true, 0.05, 1, 9999);
            myShoppingCart.AddItem(myItem);
            calculatePayment calPayment = new calculatePayment(myShoppingCart);
            Assert.AreEqual(calPayment.payment(), 34.5);
            myShoppingCart = new shoppingCart("EUR");
            item = new item(30, .15, shopping_cart.Type.Fruit_and_vegetables);
            myItem = new cartItem(item, 1, true, 0.05, 1, 9999);
            myShoppingCart.AddItem(myItem);
            calPayment = new calculatePayment(myShoppingCart);
            Assert.AreEqual(calPayment.payment(), 51.75);
        }
    }
}
