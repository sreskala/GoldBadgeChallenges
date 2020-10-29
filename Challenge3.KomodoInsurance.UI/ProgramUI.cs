using Challenge3.KomodoInsurance.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge3.KomodoInsurance.UI
{
    public class ProgramUI
    {

        //create repo object
        private BadgeRepo _repo = new BadgeRepo();
        public void Run()
        {
            SeedContent();
            Menu();
        }

        public void SeedContent()
        {
            //Add badges
            Badge badge1 = new Badge(1401, new List<Door> { Door.A1, Door.A3, Door.A5 });
            Badge badge2 = new Badge(9572, new List<Door> { Door.B3, Door.B5 });

            _repo.CreateNewBadge(badge1);
            _repo.CreateNewBadge(badge2);
        }

        public void Menu()
        {
            bool keepRunning = true;

            while (keepRunning)
            {
                Console.WriteLine("Hello Security Admin, what would you like to do?");
                Console.WriteLine("1. Add a badge");
                Console.WriteLine("2. Edit a badge");
                Console.WriteLine("3. List all badges");
                Console.WriteLine("4. Exit\n");

                int choice = Int32.Parse(Console.ReadLine());
                Console.Clear();

                switch (choice)
                {
                    case 1:
                        //Add a badge
                        AddNewBadge();
                        PressToContinue();
                        break;
                    case 2:
                        //Edit a badge
                        _repo.ShowAllBadges();
                        UpdateBadge();
                        PressToContinue();
                        break;
                    case 3:
                        _repo.ShowAllBadges();
                        PressToContinue();
                        break;
                    case 4:
                        //exit
                        keepRunning = false;
                        break;
                    default:
                        break;
                }
            }

        }

        public void AddNewBadge()
        {
            int badgeId = 0;
            string input = "";
            bool notSuccessful = true;
            while (notSuccessful)
            {
                Console.WriteLine("What is the number on the badge: ");
                input = Console.ReadLine();
                int number = 0;

                if (!Int32.TryParse(input, out number) || Int32.Parse(input) < 0 || input.Length != 4)
                {
                    Console.WriteLine("Please enter only whole positive numbers, must be 4 digits exactly.");
                    Console.WriteLine("Press any key to try again.");
                    Console.ReadKey();
                    Console.Clear();
                }
                else
                {
                    badgeId = Int32.Parse(input);
                    notSuccessful = false;
                }
            }


            Console.WriteLine("List a door that it needs access to:");
            DisplayDoorSelection();
            List<Door> doors = AddDoors();

            Badge badge = new Badge(badgeId, doors);
             _repo.CreateNewBadge(badge);


        }

        public void UpdateBadge()
        {
            Console.WriteLine("What is the number on the badge you would like to update?");
            int id = Int32.Parse(Console.ReadLine());

            _repo.ShowBadge(id);

            Console.WriteLine("What would you like to do?");
            Console.WriteLine("1. Remove a door");
            Console.WriteLine("2. Add a door");

            int choice = Int32.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    Console.WriteLine("Which door would you like to remove?");
                    DisplayDoorSelection();
                    Door doorToRemove = (Door)Int32.Parse(Console.ReadLine());

                    _repo.RemoveDoor(id, doorToRemove);
                    break;
                case 2:
                    Console.WriteLine("What doors would you like to add?");
                    DisplayDoorSelection();
                    List<Door> doors = AddDoors();

                    _repo.AddDoors(id, doors);
                    break;
                default:
                    break;
            }
        }

        public void DisplayDoorSelection()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("From the following list select a door: ");
            sb.AppendLine("1. A1");
            sb.AppendLine("2. A2");
            sb.AppendLine("3. A3");
            sb.AppendLine("4. A4");
            sb.AppendLine("5. A5");
            sb.AppendLine("6. B1");
            sb.AppendLine("7. B2");
            sb.AppendLine("8. B3");
            sb.AppendLine("9. B4");
            sb.AppendLine("10. B5");

            Console.WriteLine(sb.ToString() + "\n");
        }

        public void PressToContinue()
        {
            Console.WriteLine("\nPress any key to continue");
            Console.ReadKey();
            Console.Clear();
        }

        public List<Door> AddDoors()
        {
            List<Door> doors = new List<Door>();

            bool keepAdding = true;
            while (keepAdding)
            {
                int door = Int32.Parse(Console.ReadLine());
                Door doorType = (Door)door;
                doors.Add(doorType);

                Console.WriteLine("Any other doors (y/n)?");
                string choice = Console.ReadLine();


                if (choice.ToLower() == "n")
                {
                    keepAdding = false;
                }
                else
                {
                    Console.WriteLine("List other door:");
                }

            }

            return doors;
        }
    }
}
