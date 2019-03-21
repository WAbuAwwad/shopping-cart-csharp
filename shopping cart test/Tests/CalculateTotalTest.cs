using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using shopping_cart;
using System.Linq;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace shopping_cart_test
{
    [TestClass]
   public  class CalculateTotalTest
    {
        public shoppingCart GetShoppingCartWithNoItems()
        {
            return new shoppingCart("USD");
        }

        public shoppingCart GetShoppingCartWithItem(double price,int quantity)
        {
            shoppingCart myShoppingCart = new shoppingCart("USD");
            item item = new item(price , .65, shopping_cart.Type.Fruit_and_vegetables);
            cartItem myItem = new cartItem(item, quantity, true, 0.05, 1, 9999);
            myShoppingCart.AddItem(myItem);
            return myShoppingCart;
        }

        public shoppingCart GetShoppingCartWithManyItems(double[] prices, int[] quantities)
        {
            shoppingCart myShoppingCart = new shoppingCart("USD");
            var PriceAndQuantity = prices.Zip(quantities, (i, j) => new { price = i,quantity = j });
            foreach (var value  in PriceAndQuantity )
            {
                item item = new item(value.price, .65, shopping_cart.Type.Fruit_and_vegetables);
                cartItem myItem = new cartItem(item,value.quantity, true, 0.05, 1, 9999);
                myShoppingCart.AddItem(myItem);
            }
            
            return myShoppingCart;
        }

        [TestMethod]
        public void CalculateTotal_ReturnZero_WithEmptyCrat()
        {
            //Fixture setup
            var shoppingCart = GetShoppingCartWithNoItems();
            calculateTotal calTotal = new calculateTotal(shoppingCart);
            //Exercise system
            var actual = calTotal.CalculateTotal();
            //verify outcome
            Assert.AreEqual(actual,0);
        }

        [TestCase(40,1,40)]
        [TestCase(30, 3, 90)]
        [TestCase(18.5, 1, 18.5)]
        [TestCase(4.3, 2, 8.6)]
        public void CalculateTotal_ReturnItemPrice_whenAddingOneItem(double price , int quantity,double expected)
        {
            //Fixture setup
            var shoppingCart = GetShoppingCartWithItems(price, quantity);
            calculateTotal calTotal = new calculateTotal(shoppingCart);
            //Exercise system
            var actual = calTotal.CalculateTotal();
            //verify outcome
            Assert.AreEqual(actual,expected);
        }


        [TestCase(new double[] { 30, 40 }, new int[] { 1, 1 }, 70)]
        [TestCase(new double[] { 20, 40 }, new int[] { 3, 1 }, 100)]
        [TestCase(new double[] {2.25, 50}, new int[] { 4, 2 }, 109)]
        public void CalculateTotal_ReturnTotalPrice_WithManyItems(double[] prices , int[] quantities , double expected)
        {
            //Fixture setup
            var shoppingCart = GetShoppingCartWithManyItems(prices, quantities);
            calculateTotal calTotal = new calculateTotal(shoppingCart);
            //Exercise system
            var actual = calTotal.CalculateTotal();
            //verify outcome
            Assert.AreEqual(actual, expected);
        }


    }
}
