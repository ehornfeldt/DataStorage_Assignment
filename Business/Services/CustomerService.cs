using Business.Factories;
using Business.Models;
using Data.Entities;
using Data.Repositories;

namespace Business.Services
{
    public class CustomerService(CustomerRepository customerRepository) : ICustomerService
    {
        private readonly CustomerRepository _customerRepository = customerRepository;

        public async Task<CustomerEntity> CreateCustomerAsync(CustomerRegistrationForm form)
        {
            //skapa ej kund om den redan finns
            var customerEntity = CustomerFactory.Create(form);
            await _customerRepository.AddAsync(customerEntity!);
            
            return customerEntity!;
        }
        public async Task<IEnumerable<CustomerEntity>> GetCustomersAsync()
        {
            var customerEntities = await _customerRepository.GetAsync();
            return customerEntities.Select(CustomerFactory.Create)!;
        }

        public async Task<bool> DeleteCustomerAsync(int id)
        {
            var customerEntity = await _customerRepository.GetAsync(x => x.Id == id);
            await _customerRepository.RemoveAsync(customerEntity!);
            return true;
        }

    }
}
