using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplication2.Models;

namespace WebApplication2.Service
{
    public interface ICustomerService
    {
        List<Customer> GetCustomers();

        bool InsertCustomers(List<Customer> customers);

        bool DeleteCustomers(List<Customer> customers);

        bool UpdateCustomers(List<Customer> customers);
    }
}