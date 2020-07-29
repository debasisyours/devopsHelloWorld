using AzureDevOps.Domain.Entities;
using AzureDevOps.Domain.Models;
using AzureDevOps.Repositories;
using System;
using System.Threading.Tasks;

namespace AzureDevOps.Services
{
    public interface ISaveCustomerService
    {
        Task<ResponseMessage> SaveCustomerAsync(Customer customer);
    }

    public class SaveCustomerService:ISaveCustomerService
    {
        private readonly ICustomerRepository _customerRepository = null;

        public SaveCustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<ResponseMessage> SaveCustomerAsync(Customer customer)
        {
            return await _customerRepository.SaveCustomerAsync(customer);
        }
    }
}
