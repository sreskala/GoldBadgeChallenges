using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using Challenge3.KomodoInsurance.Repo;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Challenge3.KomodoInsurance.UnitTests
{
    [TestClass]
    public class InsuranceRepoTest
    {
        [TestMethod]
        public void ShowAllBadges_ShouldGetAllBadges()
        {
            //initialize repo
            BadgeRepo repo = new BadgeRepo();

            //Add badges
            Badge badge1 = new Badge(1401, new List<Door> { Door.A1, Door.A3, Door.A5 });
            Badge badge2 = new Badge(9572, new List<Door> { Door.B3, Door.B5 });

            repo.CreateNewBadge(badge1);
            repo.CreateNewBadge(badge2);

            repo.ShowAllBadges();
        }

        [TestMethod]
        public void CreateNewBadge_ShouldReturnTrue()
        {
            //initialize repo
            BadgeRepo repo = new BadgeRepo();

            //new up Badge obj
            Badge badge1 = new Badge(1401, new List<Door> { Door.A1, Door.A3, Door.A5 });

            bool wasCreated = repo.CreateNewBadge(badge1);

            Assert.IsTrue(wasCreated);
        }

        [TestMethod]
        public void AddDoors_ShouldReturnTrue()
        {
            //initialize repo
            BadgeRepo repo = new BadgeRepo();

            //Add badges
            Badge badge1 = new Badge(1401, new List<Door> { Door.A1, Door.A3, Door.A5 });
            Badge badge2 = new Badge(9572, new List<Door> { Door.B3, Door.B5 });

            repo.CreateNewBadge(badge1);
            repo.CreateNewBadge(badge2);

            int startingCount = badge2.Doors.Count;
            repo.ShowAllBadges();

            repo.AddDoors(9572, new List<Door> { Door.A1, Door.A3, Door.A2, Door.B3 });

            repo.ShowAllBadges();

            var dict = repo.GetDict();
            List<Door> doors = dict[9572];

            int afterCount = doors.Count;

            Console.WriteLine(startingCount);
            Console.WriteLine(afterCount);
            Assert.IsTrue(afterCount > startingCount);
        }

        [TestMethod]
        public void RemoveDoors_ShouldReturnTrue()
        {
            //initialize repo
            BadgeRepo repo = new BadgeRepo();

            //Add badges
            Badge badge1 = new Badge(1401, new List<Door> { Door.A1, Door.A3, Door.A5 });
            Badge badge2 = new Badge(9572, new List<Door> { Door.B3, Door.B5 });

            repo.CreateNewBadge(badge1);
            repo.CreateNewBadge(badge2);

            int startingCount = badge2.Doors.Count;
            repo.ShowAllBadges();

            repo.RemoveDoor(9572, Door.B5);

            repo.ShowAllBadges();
            var dict = repo.GetDict();
            List<Door> doors = dict[9572];

            int afterCount = doors.Count;

            Assert.IsTrue(afterCount < startingCount);
        }
    }
}
