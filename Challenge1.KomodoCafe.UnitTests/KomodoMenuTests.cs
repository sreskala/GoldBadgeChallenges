using System;
using System.Security.Cryptography.X509Certificates;
using Challenge1.KomodoCafe.Repo;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Challenge1.KomodoCafe.UnitTests
{
    [TestClass]
    public class KomodoMenuTests
    {
        [TestMethod]
        public void CreateNewKomodoMenu_Should_Return_A_New_Object_With_MealName_And_MealNumber_Properties()
        {
            //create new menu object
            KomodoMenu komodoMenu1 = new KomodoMenu(1, "Komodo Burger");
            Console.WriteLine($"Menu item #{komodoMenu1.MealNumber} : {komodoMenu1.MealName}");

            //checks if name is created correctly
            Assert.AreEqual("Komodo Burger", komodoMenu1.MealName);

            //checks if meal number is created correctly
            Assert.AreEqual(1, komodoMenu1.MealNumber);

            //quick test
            Console.WriteLine($"|ClaimID| {"|Type|",10} {"|Description|", 10} {"|Amount|",15} {"|DateOfAccident|", 15}" +
                $"{"|DateOfClaim|",15} {"|IsValid|", 10}");
        }
    }
}
