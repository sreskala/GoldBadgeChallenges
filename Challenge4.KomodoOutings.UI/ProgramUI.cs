using Challenge4.KomodoOutings.Repo;
using Challenge4.KomodoOutings.Repo.OutingsClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Challenge4.KomodoOutings.UI
{
    public class ProgramUI
    {
        private OutingsRepo _repo = new OutingsRepo();

        public void Run()
        {
            SeedContent();
            Menu();
        }

        public void SeedContent()
        {
            IOuting golf = new Golf(50, new DateTime(2020, 8, 2), 25.50m);
            IOuting bowling = new Bowling(14, new DateTime(2020, 9, 17), 10.75m);
            IOuting park = new AmusementPark(102, new DateTime(2020, 6, 21), 100.00m);
            IOuting concert = new Concert(45, new DateTime(2020, 12, 2), 72.80m);

            _repo.AddOutings(golf);
            _repo.AddOutings(bowling);
            _repo.AddOutings(park);
            _repo.AddOutings(concert);
        }

        public void Menu()
        {
            
            bool keepRunning = true;
            
            while(keepRunning)
            {
                Console.Clear();
                DisplayMenu();
                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        DisplayAllOutings();
                        PressKey();
                        break;
                    case "2":
                        AddOuting();
                        PressKey();
                        break;
                    case "3":
                        DisplayTotalCost();
                        PressKey();
                        break;
                    case "4":
                        CostByOuting();
                        PressKey();
                        break;
                    case "5":
                        keepRunning = false;
                        break;
                    default:
                        break;
                }

            }
            

        }

        public void DisplayAllOutings()
        {
            List<IOuting> outings = _repo.DisplayOutings();

            foreach(IOuting outing in outings)
            {
                Console.WriteLine("=======================");
                Console.WriteLine($"Outing: {outing.Name}");
                Console.WriteLine($"People in attendance: {outing.PeopleAttended}");
                Console.WriteLine($"Cost per person: ${outing.CostPerPerson}");
                Console.WriteLine($"Date of outing: {outing.DateOfOuting.ToString("MMMM dd, yyyy")}");
                Console.WriteLine("=======================");
            }
        }

        public void AddOuting()
        {
            OutingChoices("add");

            string choice = Console.ReadLine();

            Console.WriteLine("How many people attended: ");
            string people = Console.ReadLine();
            int peopleInt = Int32.Parse(people);

            Console.WriteLine("What was the cost per person: ");
            string cost = Console.ReadLine();
            decimal costD = Convert.ToDecimal(cost);

            Console.WriteLine("When did the event take place (MM/DD/YY): ");
            string date = Console.ReadLine();
            DateTime dateTime = DateTime.Parse(date);

            switch (choice)
            {
                case "1":
                    IOuting golf = new Golf(peopleInt, dateTime, costD);
                    _repo.AddOutings(golf);
                    break;
                case "2":
                    IOuting bowling = new Bowling(peopleInt, dateTime, costD);
                    _repo.AddOutings(bowling);
                    break;
                case "3":
                    IOuting park = new AmusementPark(peopleInt, dateTime, costD);
                    _repo.AddOutings(park);
                    break;
                case "4":
                    IOuting concert = new Concert(peopleInt, dateTime, costD);
                    _repo.AddOutings(concert);
                    break;
                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }
        }

        public void DisplayTotalCost()
        {
            decimal cost = _repo.DisplayTotalCost();

            string totalString = String.Format("{0:C}", cost);
            Console.WriteLine($"Total of all outings: {totalString}");
        }

        public void CostByOuting()
        {
            OutingChoices("total by");

            string choice = Console.ReadLine();
            Type type = typeof(IOuting);


            switch (choice)
            {
                case "1":
                    type = typeof(Golf);
                    break;
                case "2":
                    type = typeof(Bowling);
                    break;
                case "3":
                    type = typeof(AmusementPark);
                    break;
                case "4":
                    type = typeof(Concert);
                    break;
                default:
                    break;
            }

           decimal total = _repo.CostByOuting(type);

           string totalString = String.Format("{0:C}", total);

           Console.WriteLine($"Total cost of {type.Name} outings is {totalString}");
        }


        internal void DisplayMenu()
        {
            Console.WriteLine("Choose an item from the menu: ");
            Console.WriteLine("1. Display all outings");
            Console.WriteLine("2. Add an outing to the list");
            Console.WriteLine("3. See total cost for all outings");
            Console.WriteLine("4. See total cost for specific outing type");
            Console.WriteLine("5. Exit");
        }

        internal void OutingChoices(string action)
        {
            Console.WriteLine($"What type of outing would you like to {action}?");
            Console.WriteLine("1. Golf");
            Console.WriteLine("2. Bowling");
            Console.WriteLine("3. Amusement Park");
            Console.WriteLine("4. Concert");
        }

        internal void PressKey()
        {
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }
    }
}
