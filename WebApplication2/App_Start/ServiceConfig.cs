using Microsoft.Extensions.DependencyInjection;
using WebApplication2.Repository;
using WebApplication2.Service;

namespace WebApplication2.App_Start
{
    public class ServiceConfig
    {
        public static void RegisterServices(ServiceCollection services)
        {
            services.AddSingleton<ICustomerService, CustomerService>();
            services.AddSingleton<ICustomerRepository, CustomerRepository>();
        }
    }
}