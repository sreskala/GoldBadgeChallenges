using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using Challenge2.KomodoClaims.Repo;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Challenge2.KomodoClaims.UnitTests
{
    [TestClass]
    public class KomodoRepoTests
    {
        [TestMethod]
        public void SeeAllClaims_ShouldReturnEntireRepository()
        {
            //Initialize repo
            KomodoClaimRepo claims = new KomodoClaimRepo();

            //Create claim objects and add to repo
            KomodoClaim claim1 = new KomodoClaim(1, new DateTime(2018, 4, 25), new DateTime(2018, 4, 27),
                ClaimType.Car, "Car accident on 465.", 400.00);

            claims.NewClaim(claim1);
            
            Queue<KomodoClaim> queue = claims.SeeAllClaims();
            bool hasContent = queue.Contains(claim1);

            Assert.IsTrue(hasContent);
        }

        [TestMethod]
        public void NextClaim_ShouldDequeueCorrectly()
        {
            //Initialize repo
            KomodoClaimRepo claims = new KomodoClaimRepo();

            //Create claim objects and add to repo
            KomodoClaim claim1 = new KomodoClaim(1, new DateTime(2018, 4, 25), new DateTime(2018, 4, 27),
                ClaimType.Car, "Car accident on 465.", 400.00);
            KomodoClaim claim2 = new KomodoClaim(2, new DateTime(2018, 4, 11), new DateTime(2018, 4, 12),
                ClaimType.Home, "House fire in kitchen.", 400.00);
            KomodoClaim claim3 = new KomodoClaim(3, new DateTime(2018, 4, 27), new DateTime(2018, 6, 1),
                ClaimType.Theft, "Stolen pancakes.", 400.00);

            claims.NewClaim(claim1);
            claims.NewClaim(claim2);
            claims.NewClaim(claim3);

            Queue<KomodoClaim> queue1 = claims.SeeAllClaims();


            claims.NextClaim();

            Assert.IsFalse(queue1.Contains(claim1));

            
        }

        [TestMethod]
        public void NewClaim_ShouldCreateNewClaim()
        {
            //Initialize repo
            KomodoClaimRepo claims = new KomodoClaimRepo();

            //Create claim objects and add to repo
            KomodoClaim claim1 = new KomodoClaim(1, new DateTime(2018, 4, 25), new DateTime(2018, 4, 27),
                ClaimType.Car, "Car accident on 465.", 400.00);

            claims.NewClaim(claim1);

            Queue<KomodoClaim> queue1 = claims.SeeAllClaims();

            Assert.IsTrue(queue1.Contains(claim1));
        }
    }
}
