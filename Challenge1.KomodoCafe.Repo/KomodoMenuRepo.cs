using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge1.KomodoCafe.Repo
{
    public class KomodoMenuRepo
    {
        //fields
        private List<KomodoMenu> _repo = new List<KomodoMenu>(); //this is the private repo field

        //CRUD - Create, Read, Update, Delete

        //Create or Add method
        public bool AddMenuItem(KomodoMenu menuItem)
        {
            int startingCount = _repo.Count;

            _repo.Add(menuItem); //Adds menu item to list

            return startingCount < _repo.Count ? true : false; //checks if the count is larger than initial - if so returns true
        }

        //Read or Get method
        public List<KomodoMenu> GetMenuItems()
        {
            return _repo;
        }

        public KomodoMenu GetMenuItemByMealNumber(int mealNum)
        {
            foreach(KomodoMenu menu in _repo)
            {
                //reads through every item in repo to find match
                if(mealNum == menu.MealNumber)
                {
                    //returns match if found
                    return menu;
                }
            }

            //returns nothing if no matches found
            return null;
        }

        //Update method
        public bool UpdateMenuItem(int mealNum, KomodoMenu menu)
        {
            //calls our previously built method to get the meal by mealnumber
            KomodoMenu itemToUpdate = GetMenuItemByMealNumber(mealNum);

            if(itemToUpdate != null)
            {
                //if we received a menu item we update old values with new values
                itemToUpdate.Description = menu.Description;
                itemToUpdate.Ingredients = menu.Ingredients;
                itemToUpdate.Price = menu.Price;

                return true;
            } else
            {
                return false;
            }
        }

        //Delete or Remove method
        public bool DeleteMenuItem(int mealNum)
        {
            //call get menu by meal number
            KomodoMenu menuToDelete = GetMenuItemByMealNumber(mealNum);

            if(menuToDelete != null)
            {
                _repo.Remove(menuToDelete);
                return true;
            } else
            {
                return false;
            }
        }
    }
}
