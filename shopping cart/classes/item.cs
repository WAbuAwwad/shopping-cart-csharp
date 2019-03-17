using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shopping_cart
{

  public  enum Type
    {
        Newspapers_and_magazines,
        Most_groceries_and_food_items,
        Soft_drinks_and_snack_foods_and_candy_bars,
        Tissues_headach_tablets,
        Bread_and_milk_breakfast_ereals,
        Toothpaste_soap_and_shampoo,
        Cleaning_products_dish_washing_powder_detergents,
        Using_an_ATM,
        Cigarettes,
        Alcohol,
        Coffee_tea_and_sugar,
        Fast_food_and_takeaway_meals,
        Pet_food,
        Flowers,
        Fruit_and_vegetables,
        Regular_medicines_and_vitamins,
    };

    public  class item
    {
      
        private double price;
        private double taxe;
        private Type type;
        public double Price { get { return price; } }
        public double Taxe { get { return taxe; } }

        public item(double price, double taxe, Type type)
        {
            this.price = price;
            this.taxe = taxe;
            this.type = type;
        }
    }
}
