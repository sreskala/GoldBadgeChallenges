using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge4.KomodoOutings.Repo.OutingsClasses
{
    public class AmusementPark : IOuting
    {
        //field
        private string _name = "Amusement Park";

        public string Name
        {
            get { return _name; }
        }

        public int PeopleAttended { get; set; }

        public DateTime DateOfOuting { get; set; }

        public decimal CostPerPerson { get; set; }

        public AmusementPark() { }
        public AmusementPark(int people, DateTime date, decimal costPer)
        {
            PeopleAttended = people;
            DateOfOuting = date;
            CostPerPerson = costPer;
        }
    }
}
