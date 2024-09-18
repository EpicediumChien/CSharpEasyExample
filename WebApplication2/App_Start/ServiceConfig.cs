using Microsoft.Extensions.DependencyInjection;
using EasyExample.Repository;
using EasyExample.Service;

namespace EasyExample.App_Start
{
    public class ServiceConfig
    {
        public static void RegisterServices(ServiceCollection services)
        {
            services.AddSingleton<IOtherService, OtherService>();
            services.AddSingleton<ICustomerService, CustomerService>();
            services.AddSingleton<ICustomerRepository, CustomerRepository>();
        }
    }
}