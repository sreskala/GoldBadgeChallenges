using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge3.KomodoInsurance.Repo
{
    public class BadgeRepo
    {
        //initialize the private repository
        private Dictionary<int, List<Door>> _repo = new Dictionary<int, List<Door>>();

        //Create new badge
        public bool CreateNewBadge(Badge badge)
        {
            _repo.Add(badge.BadgeId, badge.Doors);

            if(_repo.ContainsKey(badge.BadgeId))
            {
                return true;
            } else
            {
                return false;
            }
            
        }

        

        //update doors on badge - ADD
        public void AddDoors(int id, List<Door> doors)
        {
            //List<Door> currentDoors = badgeElements.Value;
            //List<Door> addedDoors = currentDoors.Union(doors).ToList();

            //_repo[badgeElements.Key] = addedDoors;
            //string doorsList = DisplayDoors(addedDoors);

            //Console.WriteLine($"{badgeElements.Key} now has access to door(s) {doorsList}");

            List<Door> currentDoors = _repo[id];
            List<Door> addedDoors = currentDoors.Union(doors).ToList();

            _repo[id] = addedDoors;

            string doorsList = DisplayDoors(addedDoors);

            Console.WriteLine($"{id} now has access to {doorsList}");

        }

        //update doors on badge - REMOVE
        public void RemoveDoor(int id, Door door)
        {
            List<Door> currentDoors = _repo[id];

            for(int i = 0; i < currentDoors.Count; i++)
            {
                if(door == currentDoors[i])
                {
                    Console.WriteLine($"Removed door {currentDoors[i]}");
                    currentDoors.RemoveAt(i);
                    
                }
            }

            string doorsList = DisplayDoors(currentDoors);

            Console.WriteLine($"{id} has access to door(s) {doorsList}");
        }

        //show all badge numbers and door access
        public void ShowAllBadges()
        {
            for(int i = 0; i < _repo.Count; i++)
            {
                int id = _repo.ElementAt(i).Key;
                List<Door> doors = _repo.ElementAt(i).Value;

                //string doorsShow = "";
                //foreach(Door door in doors)
                //{
                //    doorsShow += door + ",";
                //}

                //doorsShow = doorsShow.Substring(0, doorsShow.Length - 1);

                string doorsList = DisplayDoors(doors);

                Console.WriteLine("Badge#       Door Access");
                Console.WriteLine($"{id}            {doorsList}");
            }
        }

        private string DisplayDoors(List<Door> doors)
        {
            string doorsShow = "";
            foreach (Door door in doors)
            {
                doorsShow += door + ",";
            }

            doorsShow = doorsShow.Substring(0, doorsShow.Length - 1);

            return doorsShow;
        }

        public Dictionary<int, List<Door>> GetDict()
        {
            return _repo;
        }
    }
}
