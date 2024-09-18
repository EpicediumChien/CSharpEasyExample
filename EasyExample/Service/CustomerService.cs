using System;
using System.Collections.Generic;
using EasyExample.Models;
using EasyExample.Repository;

namespace EasyExample.Service
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerService(ICustomerRepository customerRepository) {
            _customerRepository = customerRepository;
        }

        public List<Customer> GetCustomers()
        {
            return _customerRepository.GetCustomers();
        }

        public bool InsertCustomers(List<Customer> customers) 
        {
            return _customerRepository.InsertCustomers(customers);
        }

        public bool DeleteCustomers(List<Customer> customers)
        {
            return _customerRepository.DeleteCustomers(customers);
        }

        public bool UpdateCustomers(List<Customer> customers)
        {
            return _customerRepository.UpdateCustomers(customers);
        }
    }
}