using Business.Models;
using Data.Entities;

namespace Business.Services
{
    public interface ICustomerService
    {
        Task<CustomerEntity> CreateCustomerAsync(CustomerRegistrationForm form);
        Task<bool> DeleteCustomerAsync(int id);
        Task<IEnumerable<CustomerEntity>> GetCustomersAsync();
    }
}