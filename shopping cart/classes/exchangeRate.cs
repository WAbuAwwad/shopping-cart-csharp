using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shopping_cart
{
  public  class exchangeRate
    {


        public double ExchangeCurrency(string currency)
        {

            if (currency.ToUpper() == "EUR") return 1.5;
            else if (currency.ToUpper() == "NIS") return 3.5;
            else if (currency.ToUpper() == "AUD") return 5.8;
            else if (currency.ToUpper() == "SAR") return 2.7;
            else return 1;
        }
    }
}
