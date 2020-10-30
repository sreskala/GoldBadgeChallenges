using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge4.KomodoOutings.Repo.OutingsClasses
{
    public class Bowling : IOuting
    {
        //field
        private string _name = "Bowling";

        public string Name
        {
            get { return _name; }
        }

        public int PeopleAttended { get; set; }

        public DateTime DateOfOuting { get; set; }

        public decimal CostPerPerson { get; set; }

        public Bowling() { }
        public Bowling(int people, DateTime date, decimal costPer)
        {
            PeopleAttended = people;
            DateOfOuting = date;
            CostPerPerson = costPer;
        }
    }
}
