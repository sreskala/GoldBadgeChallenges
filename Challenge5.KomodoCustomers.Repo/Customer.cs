using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge5.KomodoCustomers.Repo
{
    //Type enum
    public enum CustomerType { Potential, Current, Past}
    public class Customer
    {
        //fields
        private string _firstName;
        private string _lastName;

        //First Name
        public string FirstName
        {
            get { return _firstName[0] + _firstName.Substring(1).ToLower(); }
            set { _firstName = value; }
        }

        //Last Name
        public string LastName
        {
            get { return _lastName[0] + _lastName.Substring(1).ToLower(); }
            set { _lastName = value; }
        }
        //Type - Potential, Current, Past
        public CustomerType CustomerType { get; set; }

        //Email
        public string Email()
        {
            string str = "";
            if(CustomerType == CustomerType.Potential)
            {
                str = "We currently have the lowest rates on Helicopter Insurance!";
            } else if(CustomerType == CustomerType.Past)
            {
                str = "It's been a long time since we've heard from you, we want you back.";
            } else if(CustomerType == CustomerType.Current)
            {
                str = "Thank you for your work with us. We appreciate your loyalty. Here's a coupon.";
            } else
            {
                throw new Exception("Not a valid type");
            }

            return str;
        }

        //constructor
        public Customer() {}
        public Customer(string first, string last, CustomerType customerType)
        {
            FirstName = first;
            LastName = last;
            CustomerType = customerType;
        }
     
    }
}
