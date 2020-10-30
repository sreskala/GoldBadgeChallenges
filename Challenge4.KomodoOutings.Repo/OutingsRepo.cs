using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Challenge4.KomodoOutings.Repo
{
    public class OutingsRepo
    {
        //private repo List
        private List<IOuting> _repo = new List<IOuting>();

        //Display all outings
        public List<IOuting> DisplayOutings()
        {
            return _repo;
        }

        //Add outings to the list
        public bool AddOutings(IOuting outing)
        {
            int startingCount = _repo.Count;

            _repo.Add(outing);

            return (startingCount < _repo.Count);
        }

        //Calculations: Display combined cost for all outings
        public decimal DisplayTotalCost()
        {
            decimal total = 0.00m;

            foreach(IOuting outing in _repo)
            {
                decimal costOuting = (decimal)Math.Round((outing.CostPerPerson * outing.PeopleAttended), 2);

                total += costOuting;
            }

            return total;
            //string totalString = String.Format("{0:C}", total);
            //Console.WriteLine($"Total of all outings: {totalString}");
        }

        //Calculations: display outing costs by type 
        public decimal CostByOuting(Type type)
        {
            decimal totalCost = 0.00m;

            foreach(IOuting outing in _repo)
            {
                if(type == outing.GetType())
                {
                    decimal cost = Convert.ToDecimal(Math.Round(outing.CostPerPerson * outing.PeopleAttended, 2));
                    totalCost += cost;
                }
            }

            return totalCost;
            //decimal totalCost = Convert.ToDecimal(Math.Round((outing.CostPerPerson * outing.PeopleAttended), 2));
            //string totalString = String.Format("{0:C}", totalCost);

            //Console.WriteLine($"Total cost of {outing.Name} is {totalCost}");
        }

       
    }
}
