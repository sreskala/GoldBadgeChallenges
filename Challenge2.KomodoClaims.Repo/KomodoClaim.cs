using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge2.KomodoClaims.Repo
{
    public enum ClaimType { Car=1, Home, Theft}
    public class KomodoClaim
    {
        //field
        private int _claimId;

        //Claim ID
        public int ClaimId {
            get { return _claimId; }
            set { _claimId = value; }
        }

        //Claim Type
        public ClaimType ClaimType { get; set; }

        //Description
        public string Description { get; set; }

        //Claim Amount
        public double ClaimAmount { get; set; }
        
        //Date of Incident
        public DateTime DateOfIncident { get; }

        //Date of Claim
        public DateTime DateOfClaim { get; }

        //Is Valid
        public bool IsValid()
        {
            TimeSpan timeSpan = DateOfClaim - DateOfIncident;
            int days = (int)timeSpan.TotalDays;

            return days < 30 ? true : false;
        }

        //constructor
        public KomodoClaim(int id, DateTime incident, DateTime claim, ClaimType claimType, string desc, double amount)
        {
            ClaimId = id;
            DateOfIncident = incident;
            DateOfClaim = claim;
            ClaimType = claimType;
            Description = desc;
            ClaimAmount = amount;
        }

        public KomodoClaim(int id, DateTime incident, DateTime claim)
        {
            ClaimId = id;
            DateOfIncident = incident;
            DateOfClaim = claim;
        }
    }
}
