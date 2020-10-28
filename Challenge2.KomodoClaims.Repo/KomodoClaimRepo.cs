using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge2.KomodoClaims.Repo
{
    public class KomodoClaimRepo
    {
        //Setting the private queue
        private Queue<KomodoClaim> _repo = new Queue<KomodoClaim>();

        //1. See all claims
        public Queue<KomodoClaim> SeeAllClaims()
        {
            return _repo;
        }

        //2. Take care of next claim
        public bool NextClaim()
        {
            int startingCount = _repo.Count;

            _repo.Dequeue();

            return startingCount > _repo.Count;
        }

        //3. Enter new claim
        public bool NewClaim(KomodoClaim claim)
        {
            int startingCount = _repo.Count;

            _repo.Enqueue(claim);

            return startingCount < _repo.Count;
        }

    }
}
