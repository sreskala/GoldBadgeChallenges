using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge1.KomodoCafe.Repo
{
    public class KomodoMenu
    {
        //fields
        private int _mealNumber;
        private string _mealName;

        //Meal number for the menu
        public int MealNumber
        {
            get { return _mealNumber; }
            set { _mealNumber = value; }
        }

        //Meal name for the menu
        public string MealName
        {
            get { return _mealName; }
            set { _mealName = value; }
        }

        //Meal description - can be changed
        public string Description { get; set; }

        //List of ingredients for meal
        public List<string> Ingredients { get; set; }

        //price
        public float Price { get; set; }

        //constructor
        public KomodoMenu(int mealnum, string name)
        {
            MealNumber = mealnum;
            MealName = name;
        }

        public KomodoMenu(int mealnum, string name, string desc, List<string> ingredients, float price)
        {
            MealNumber = mealnum;
            MealName = name;
            Description = desc;
            Ingredients = ingredients;
            Price = price;
        }
    }
}
