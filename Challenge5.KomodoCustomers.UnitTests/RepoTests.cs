using System;
using Challenge5.KomodoCustomers.Repo;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Challenge5.KomodoCustomers.UnitTests
{
    [TestClass]
    public class RepoTests
    {
        [TestMethod]
        public void CreateCustomer_ShouldReturnTrue()
        {
            //make new repo
            CustomerRepo repo = new CustomerRepo();

            //make new customers and add them to repo
            Customer customer1 = new Customer("Mike", "Smith", CustomerType.Current);

            bool wasCreated = repo.CreateCustomer(customer1);

            //Assert
            Assert.IsTrue(wasCreated);
        }
    }
}
