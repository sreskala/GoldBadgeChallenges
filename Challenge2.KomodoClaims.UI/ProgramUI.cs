using Challenge2.KomodoClaims.Repo;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge2.KomodoClaims.UI
{
    public class ProgramUI
    {
        //private
        private KomodoClaimRepo _repo = new KomodoClaimRepo();

        public void Run()
        {
            SeedContent();
            Menu();
        }

        public void SeedContent()
        {
            KomodoClaim claim1 = new KomodoClaim(1, new DateTime(2018, 4, 25), new DateTime(2018, 4, 27),
                ClaimType.Car, "Car accident on 465.", 400.00);
            KomodoClaim claim2 = new KomodoClaim(2, new DateTime(2018, 4, 11), new DateTime(2018, 4, 12),
                ClaimType.Home, "House fire in kitchen.", 400.00);
            KomodoClaim claim3 = new KomodoClaim(3, new DateTime(2018, 4, 27), new DateTime(2018, 6, 1),
                ClaimType.Theft, "Stolen pancakes.", 400.00);

            _repo.NewClaim(claim1);
            _repo.NewClaim(claim2);
            _repo.NewClaim(claim3);
        }

        public void Menu()
        {
            bool continueToRun = true;

            while (continueToRun)
            {
                Console.WriteLine("Choose a menu item: ");
                Console.WriteLine("1. See all claims");
                Console.WriteLine("2. Take care of next claim");
                Console.WriteLine("3. Enter a new claim");
                Console.WriteLine("4. Exit");

                int choice = Int32.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        //see all claims
                        Console.Clear();
                        SeeAllClaims();
                        break;
                    case 2:
                        //take care of next claim
                        Console.Clear();
                        NextClaim();
                        break;
                    case 3:
                        //enter a new claim
                        Console.Clear();
                        EnterNewClaim();
                        break;
                    case 4:
                        continueToRun = false;
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Invalid choice.");
                        Console.WriteLine("Press any key to try again.");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                }
            }

            
        }

        public void SeeAllClaims()
        {
            Queue<KomodoClaim> claims = _repo.SeeAllClaims();

            foreach(KomodoClaim claim in claims)
            {
                DisplayClaimItem(claim);
            }
        }

        public void NextClaim()
        {
            Queue<KomodoClaim> claims = _repo.SeeAllClaims();

            Console.WriteLine("Here are the details for the next claim to be handled: ");
            KomodoClaim claim = claims.Peek();

            DisplayClaimItem(claim);

            Console.WriteLine("Do you want to deal with this claim now (y/n)?");
            string choice = Console.ReadLine();

            if(choice.ToLower() == "y")
            {
               bool wasRemoved = _repo.NextClaim();
                if(wasRemoved)
                {
                    Console.WriteLine("Succesfully handled.");
                } else
                {
                    Console.WriteLine("Oops. Something went wrong.");
                }
            }
            
        }

        public void EnterNewClaim()
        {
            Console.WriteLine("Enter the claim ID: ");
            int claimId = Int32.Parse(Console.ReadLine());

            Console.WriteLine("Pick a claim type: ");
            Console.WriteLine("1. Car");
            Console.WriteLine("2. Home");
            Console.WriteLine("3. Theft");

            int claimInt = 1;

            bool incorrect = true;
            while(incorrect)
            {
                claimInt = Int32.Parse(Console.ReadLine());
                if(claimInt > 3)
                {
                    Console.WriteLine("Not a valid choice please try again.");
                } else
                {
                    incorrect = false;
                }
            }

            ClaimType claimType = (ClaimType)claimInt;

            Console.WriteLine("Enter a claim description: ");
            string desc = Console.ReadLine();

            Console.WriteLine("Enter amount of damage : ");
            double claimAmount = Double.Parse(Console.ReadLine());

            Console.WriteLine("Enter date of accident (mm/dd/yyyy): ");
            DateTime accidentDate = DateTime.Parse(Console.ReadLine());

            Console.WriteLine("Date of claim (mm/dd/yyyy): ");
            DateTime claimDate = DateTime.Parse(Console.ReadLine());

            KomodoClaim claim = new KomodoClaim(claimId, accidentDate, claimDate, claimType, desc, claimAmount);

            bool wasCreated = _repo.NewClaim(claim);

            if(wasCreated)
            {
                Console.WriteLine("Claim successfully created:");
                bool valid = claim.IsValid();
                if (valid)
                {
                    Console.WriteLine("Claim is valid.");
                }
                else
                {
                    Console.WriteLine("Claim is not valid.");
                }
            } else
            {
                Console.WriteLine("Oops. Something went wrong.");
            }
        }

        public void DisplayClaimItem(KomodoClaim claim)
        {
            Console.WriteLine($"|ClaimID| {"|Type|"} {"|Description|"} {"|Amount|"} {"|DateOfAccident|"}" +
                $"{"|DateOfClaim|"} {"|IsValid|"}");
            Console.WriteLine($"|{claim.ClaimId}, {claim.ClaimType}, {claim.Description}, {claim.ClaimAmount}, " +
                $"{claim.DateOfIncident.ToShortDateString()}, " +
            $"{claim.DateOfClaim.Date.ToShortDateString()}, {claim.IsValid()}|");
            Console.WriteLine("\n\n");
        }
    }
}
