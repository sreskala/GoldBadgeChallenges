using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge4.KomodoOutings.Repo
{
    public interface IOuting
    {
        string Name { get; }
        int PeopleAttended { get; set; }

        DateTime DateOfOuting { get; set; }

        decimal CostPerPerson { get; set; }

    }
}
