using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shopping_cart
{
    class Program
    {
        static void Main(string[] args)
        {
            shoppingCart myShoppingCart = new shoppingCart();
            Console.WriteLine(myShoppingCart.GetExchangeRate("USD", "USD"));
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();

        }
    }
}
