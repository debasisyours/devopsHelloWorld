using AzureDevOps.Repositories;
using AzureDevOps.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AzureDevOps.API
{
    public static class DependencyExtensions
    {
        public static void RegisterDependencies(this IServiceCollection services)
        {
            services.AddTransient<ICustomerRepository, CustomerRepository>();
            services.AddTransient<ISaveCustomerService, SaveCustomerService>();
        }
    }
}
