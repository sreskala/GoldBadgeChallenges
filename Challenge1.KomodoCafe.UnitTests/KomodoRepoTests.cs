using System;
using System.Collections.Generic;
using Challenge1.KomodoCafe.Repo;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Challenge1.KomodoCafe.UnitTests
{
    [TestClass]
    public class KomodoRepoTests
    {
        [TestMethod]
        public void AddMenuItem_ShouldReturnTrue()
        {
            KomodoMenuRepo menuContent = new KomodoMenuRepo();

            //Create a menu item
            KomodoMenu menuItem = new KomodoMenu(1, "Komodo Burger");

            //Add to repo
            bool wasAdded = menuContent.AddMenuItem(menuItem);

            //Make sure it returns true
            Assert.IsTrue(wasAdded);
        }

        [TestMethod]
        public void GetMenu_ShouldReturnAListOfMenuItems()
        {
            //repeat same method as above with adding
            KomodoMenuRepo menuContent = new KomodoMenuRepo();

            //Create menu items
            KomodoMenu menuItem = new KomodoMenu(1, "Komodo Burger");
            KomodoMenu menuItem2 = new KomodoMenu(2, "Komodo Chicken");

            //Add both to repo
            menuContent.AddMenuItem(menuItem);
            menuContent.AddMenuItem(menuItem2);

            //Get contents
            List<KomodoMenu> menuItems = menuContent.GetMenuItems();

            //create variables for easier visibility
            string menu_1_name = menuItems[0].MealName;
            string menu_2_name = menuItems[1].MealName;

            //Check if both are equal
            Assert.AreEqual("Komodo Burger", menu_1_name);
            Assert.AreEqual("Komodo Chicken", menu_2_name);
        }

        [TestMethod]
        public void GetMealByNumber_ShouldReturnCorrectMeal()
        {
            //repeat same method as above with adding
            KomodoMenuRepo menuContent = new KomodoMenuRepo();

            //Create menu item
            KomodoMenu menuItem = new KomodoMenu(1, "Komodo Burger");

            //add to repo
            menuContent.AddMenuItem(menuItem);

            //Call method
            KomodoMenu item = menuContent.GetMenuItemByMealNumber(1);

            //Check if it returned correct meal
            Assert.AreEqual("Komodo Burger", item.MealName);

        }

        [TestMethod]
        public void DeleteMenuItem_ShouldReturnTrue()
        {
            //repeat same method as above with adding
            KomodoMenuRepo menuContent = new KomodoMenuRepo();

            //Create menu item
            KomodoMenu menuItem = new KomodoMenu(1, "Komodo Burger");

            //add to repo
            menuContent.AddMenuItem(menuItem);

            //check if it was deleted
            bool wasDeleted = menuContent.DeleteMenuItem(menuItem.MealNumber);
            Assert.IsTrue(wasDeleted);
        }
    }
}
