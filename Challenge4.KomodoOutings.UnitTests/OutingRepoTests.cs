using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using Challenge4.KomodoOutings.Repo;
using Challenge4.KomodoOutings.Repo.OutingsClasses;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Challenge4.KomodoOutings.UnitTests
{
    [TestClass]
    public class OutingRepoTests
    {
        [TestMethod]
        public void DisplayOutings_ShouldReturnTheCorrectContent()
        {
            //make new repo
            OutingsRepo repo = new OutingsRepo();

            //New up object and add to repo
            IOuting golf = new Golf();
            repo.AddOutings(golf);

            //set the first element of display to an IOuting object
            List<IOuting> outings = repo.DisplayOutings();

            IOuting outing = outings[0];

            Assert.AreEqual(golf, outing);
        }

        [TestMethod]
        public void AddOutings_ShouldReturnTrue()
        {
            //make new repo
            OutingsRepo repo = new OutingsRepo();

            //New up object and add to repo setting it to bool
            IOuting golf = new Golf();
            bool wasAdded = repo.AddOutings(golf);

            Assert.IsTrue(wasAdded);
        }

        [TestMethod]
        public void DisplayTotalCost_ShouldDisplayCorrectTotal()
        {
            //make new repo
            OutingsRepo repo = new OutingsRepo();

            //New up objects and add to repo
            IOuting golf = new Golf(10, DateTime.Now, 10.00m);
            repo.AddOutings(golf);

            IOuting bowling = new Bowling(10, DateTime.Now, 10.00m);
            repo.AddOutings(bowling);

            //We know the total should be 10 x 10 + 10 x 10 = 200.00
            decimal actualCost = 200m;

            decimal cost = repo.DisplayTotalCost();

            Assert.AreEqual(actualCost, cost);
        }

        [TestMethod]
        public void CostByOuting_ShouldReturnCorrectAmountByCategory()
        {
            //make new repo
            OutingsRepo repo = new OutingsRepo();

            //New up objects and add to repo
            IOuting golf = new Golf(10, DateTime.Now, 10.00m); //total for this should be 100
            repo.AddOutings(golf);

            IOuting golf2 = new Golf(5, DateTime.Now, 10.00m); //total for this should be 50
            repo.AddOutings(golf2);
            //Total for golf shoould be 150.00

            IOuting bowling = new Bowling(10, DateTime.Now, 10.00m); //total for this should be 100
            repo.AddOutings(bowling);

            IOuting bowling2 = new Bowling(30, DateTime.Now, 10.00m); //total for this should be 300
            repo.AddOutings(bowling2);
            //total for bowlilng should be 400

            decimal expectedCostBowling = 400.00m;
            decimal expectedCostGolf = 150.00m;

            decimal actualCostBowling = repo.CostByOuting(typeof(Bowling));
            decimal actualCostGolf = repo.CostByOuting(typeof(Golf));

            Assert.AreEqual(expectedCostGolf, actualCostGolf);
            Assert.AreEqual(expectedCostBowling, actualCostBowling);
        }
    }
}
