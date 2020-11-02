using Challenge1.KomodoCafe.Repo;
using System.Collections.Generic;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge1.KomodoCafe.UI
{
    public class ProgramUI
    {
        //field for repo
        private KomodoMenuRepo _repo = new KomodoMenuRepo();

        public void Run()
        {
            //Runs SeedContent to start
            SeedContent();
            Menu();
        }

        //Method to add initial content
        public void SeedContent()
        {
            KomodoMenu item1 = new KomodoMenu(1, "Komodo Burger", "A delicious burger"
                , new List<string> { "meat", "onions", "tomatoes", "lettuce" }
            , 5.90f
            );

            KomodoMenu item2 = new KomodoMenu(2, "Komodo Chicken Sandwich", "Better than Chik Fil A!"
                , new List<string> { "chicken", "onions", "tomatoes", "lettuce" }
            , 4.90f
            );

            _repo.AddMenuItem(item1);
            _repo.AddMenuItem(item2);
        }

        //Menu method
        public void Menu()
        {
            //continue to run the program
            bool continueToRun = true;

            while (continueToRun)
            {
                Console.Clear();
                DisplayMenu();

                //user response
                int choice = Int32.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        //shows all items
                        GetMenu();
                        break;
                    case 2:
                        //shows item by number
                        GetMenuItem();
                        break;
                    case 3:
                        //adds new item
                        AddMenuItem();
                        break;
                    case 4:
                        //updates menu item
                        UpdateMenuItem();
                        break;
                    case 5:
                        //deletes menu item
                        DeleteMenuItem();
                        break;
                    case 6:
                        //exits program
                        continueToRun = false;
                        break;
                    default:
                        Console.WriteLine("Not a valid choice!");
                        break;
                }
            }
        }

        public void DisplayMenu()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Enter the option you'd like to select:");
            sb.AppendLine("1. Display all menu items");
            sb.AppendLine("2. Find menu item by meal number");
            sb.AppendLine("3. Add new menu item");
            sb.AppendLine("4. Update menu item");
            sb.AppendLine("5. Delete menu item");
            sb.AppendLine("6. Exit menu");

            Console.WriteLine(sb);
        }

        public void GetMenu()
        {
            List<KomodoMenu> menuItems = _repo.GetMenuItems();

            foreach (KomodoMenu item in menuItems)
            {
                DisplayMenuItem(item);
            }

            PressKey();
        }

        public void GetMenuItem()
        {
            Console.WriteLine("Please enter the Meal Number of the item you would like to see: ");

            int menuNum = Int32.Parse(Console.ReadLine());

            KomodoMenu item = _repo.GetMenuItemByMealNumber(menuNum);
            if (item != null)
            {
                DisplayMenuItem(item);
            }
            else
            {
                Console.WriteLine("Meal number does not exist.");
            }


            PressKey();
        }

        public void AddMenuItem()
        {
            Console.WriteLine("Enter a meal number for new meal: ");
            int mealNum = 0;

            bool exists = true;
            while (exists)
            {
                mealNum = Int32.Parse(Console.ReadLine());
                if (_repo.GetMenuItemByMealNumber(mealNum) != null)
                {
                    Console.WriteLine("Meal number already exists, please enter a different number.");
                }
                else
                {
                    exists = false;
                }
            }

            Console.WriteLine("Enter a name for new meal: ");
            string name = Console.ReadLine();

            Console.WriteLine("Enter a description: ");
            string desc = Console.ReadLine();

            Console.WriteLine("Enter ingredients separated by a comma: ");
            List<string> ingredients = Console.ReadLine().Split(',').ToList();

            Console.WriteLine("Enter a price: ");
            float price = float.Parse(Console.ReadLine());

            KomodoMenu newMenu = new KomodoMenu(mealNum, name, desc, ingredients, price);

            bool wasAdded = _repo.AddMenuItem(newMenu);

            if (wasAdded)
            {
                Console.WriteLine("New item added to menu list.");
            }
            else
            {
                Console.WriteLine("Oops. Something went wrong.");

            }

            PressKey();
        }

        public void DeleteMenuItem()
        {
            Console.WriteLine("Please enter meal number of item to delete: ");
            int mealNum = Int32.Parse(Console.ReadLine());

            bool wasDeleted = _repo.DeleteMenuItem(mealNum);

            if (wasDeleted)
            {
                Console.WriteLine("Item successfully deleted.");
            }
            else
            {
                Console.WriteLine("Oops. Something went wrong");
            }

            PressKey();
        }

        public void UpdateMenuItem()
        {

            int mealNum = 0;
            KomodoMenu oldItem = null;
            bool exists = false;

            while(!exists)
            {
                Console.WriteLine("Please enter meal number for item to update: ");
                mealNum = Int32.Parse(Console.ReadLine());

                oldItem = _repo.GetMenuItemByMealNumber(mealNum);

                if (oldItem == null)
                {
                    Console.WriteLine("Item not in database.");
                } else
                {
                    exists = true;
                }
            }
            ;


            Console.WriteLine($"Enter new description for {oldItem.MealName}: ");
            string desc = Console.ReadLine();

            Console.WriteLine($"Enter new ingredients separated by commas for {oldItem.MealName}: ");
            List<string> ingredients = Console.ReadLine().Split(',').ToList();

            Console.WriteLine($"Enter new price for {oldItem.MealName}: ");
            float price = float.Parse(Console.ReadLine());

            KomodoMenu newItem = new KomodoMenu(mealNum, oldItem.MealName, desc, ingredients, price);

            bool wasUpdated = _repo.UpdateMenuItem(mealNum, newItem);

            if (wasUpdated)
            {
                Console.WriteLine("Menu item successfully updated!");
            }
            else
            {
                Console.WriteLine("Oops. Something went wrong!");
            }

            PressKey();
        }

        //helper methods --------------

        public void DisplayMenuItem(KomodoMenu item)
        {
            Console.WriteLine($"Meal #: {item.MealNumber}");
            Console.WriteLine($"Meal Name: {item.MealName}");

            //checks if other properties exist
            string desc = item.Description.Length > 0 ? item.Description : "No description exists";
            string ings = item.Ingredients.Count > 0 ? ListIngredients(item.Ingredients) : "No ingredients available";
            string price = item.Price.ToString().Length > 0 ? item.Price.ToString() : "No price available";

            Console.WriteLine($"Description: {desc}");
            Console.WriteLine($"Ingredients: {ings}");
            Console.WriteLine($"Price: {price}");
        }

        public string ListIngredients(List<string> ingredients)
        {
            string ings = "";
            foreach (string ingredient in ingredients)
            {
                ings += "," + ingredient;
            }

            return ings;
        }

        public void PressKey()
        {
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }
    }
}
