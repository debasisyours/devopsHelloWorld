using AzureDevOps.Domain;
using AzureDevOps.Domain.Entities;
using AzureDevOps.Domain.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace AzureDevOps.Repositories
{
    public interface ICustomerRepository
    {
        Task<ResponseMessage> SaveCustomerAsync(Customer customer);
    }

    public class CustomerRepository:ICustomerRepository
    {
        private readonly ApiContext _context = null;

        public CustomerRepository(ApiContext context)
        {
            _context = context;
        }

        public async Task<ResponseMessage> SaveCustomerAsync(Customer customer)
        {
            ResponseMessage response = new ResponseMessage { IsSuccess = false };

            try
            {
                var existing = _context.Customers.FirstOrDefault(s => s.Id == customer.Id);
                if (existing == null)
                {
                    _context.Customers.Add(customer);
                }
                else
                {
                    existing.DateOfBirth = customer.DateOfBirth;
                    existing.FirstName = customer.FirstName;
                    existing.LastName = customer.LastName;
                }
                await _context.SaveChangesAsync();
                response.IsSuccess = true;
            }
            catch(Exception ex)
            {
                response.Detail = ex.Message;
            }

            return response;
        }
    }
}
