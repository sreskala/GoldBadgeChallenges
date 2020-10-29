using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge3.KomodoInsurance.Repo
{
    //enum for door access
    public enum Door { A1=1, A2, A3, A4, A5, B1, B2, B3, B4, B5}
    public class Badge
    {
        //fields
        private int _badgeId;

        //badge ID
        public int BadgeId
        {
            get { return _badgeId; }
            set { _badgeId = value; }
        }

        //List of door names
        public List<Door> Doors { get; set; }

        //constructor
        public Badge(int id, List<Door> doors)
        {
            BadgeId = id;
            Doors = doors;
        }
    }
}
