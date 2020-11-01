using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge5.KomodoCustomers.Repo
{
    public class CustomerRepo
    {
        //field
        private List<Customer> _repo = new List<Customer>();

        //CRUD Methods

        //Create new Customer
        public bool CreateCustomer(Customer customer)
        {
            int startingCount = _repo.Count;

            _repo.Add(customer);

            return startingCount < _repo.Count ? true : false;
        }

        //Read - Get all customers
        public List<Customer> GetCustomers()
        {
            return _repo;
        }

        //Read - Get customer by last name
        public Customer GetCustomerByName(string name)
        {

            foreach(Customer customer in _repo)
            {
                if(customer.LastName.ToLower() == name.ToLower())
                {
                    return customer;
                }
            }

            return null;
        }

        //Update - customer update
        public bool UpdateCustomer(Customer customer, string name)
        {
            Customer oldCustomer = GetCustomerByName(name);

            if(oldCustomer != null)
            {
                oldCustomer.FirstName = customer.FirstName;
                oldCustomer.LastName = customer.LastName;
                oldCustomer.CustomerType = customer.CustomerType;

                return true;
            } else
            {
                return false;
            }
        }

        public bool DeleteCustomer(Customer customer)
        {
            int startingCount = _repo.Count;

            _repo.Remove(customer);

            return startingCount > _repo.Count ? true : false;
        }
    }
}
