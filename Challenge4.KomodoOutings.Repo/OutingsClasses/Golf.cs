using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge4.KomodoOutings.Repo.OutingsClasses
{
    public class Golf : IOuting
    {
        private string _name = "Golf";
        public string Name
        {
            get { return _name; }
        }
        public int PeopleAttended { get; set; }
        public DateTime DateOfOuting { get; set; }
        public decimal CostPerPerson { get; set; }

        public Golf() { }
        public Golf(int people, DateTime date, decimal costPer)
        {
            PeopleAttended = people;
            DateOfOuting = date;
            CostPerPerson = costPer;
        }
    }
}
