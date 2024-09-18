using System.Collections.Generic;
using System.Threading.Tasks;
using EasyExample.Models;

namespace EasyExample.Repository
{
    public interface ICustomerRepository
    {
        List<Customer> GetCustomers();

        bool InsertCustomers(List<Customer> customers);

        bool DeleteCustomers(List<Customer> customers);

        bool UpdateCustomers(List<Customer> customers);
    }
}