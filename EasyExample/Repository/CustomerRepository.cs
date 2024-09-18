using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using EasyExample.Models;
using EasyExample.Repository;

namespace EasyExample.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        public List<Customer> GetCustomers() {
            List<Customer> customers = new List<Customer>
            {
                new Customer() { Iden = 1, Name = "Test1", Birthday = DateTime.Now },
                new Customer() { Iden = 2, Name = "Test2", Birthday = DateTime.Now },
                new Customer() { Iden = 3, Name = "Test3", Birthday = DateTime.Now }
            };
            return customers;
        }

        public bool InsertCustomers(List<Customer> customers)
        { return true; }

        public bool DeleteCustomers(List<Customer> customers)
        { return true; }

        public bool UpdateCustomers(List<Customer> customers)
        { return true; }
    }
}