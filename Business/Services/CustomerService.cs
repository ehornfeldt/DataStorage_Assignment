using Business.Factories;
using Business.Models;
using Data.Contexts;
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
        //public async Task<CustomerEntity> GetCustomerByIdAsync(int id) { }
        //public async Task<bool> UpdateCustomerAsync() { }
        public async Task<bool> DeleteCustomerAsync(int id)
        {
            var customerEntity = await _customerRepository.GetAsync(x => x.Id == id);
            await _customerRepository.RemoveAsync(customerEntity!);
            return true;
        }

    }
    //public class CustomerService(DataContext context) : ICustomerService
    //{
    //    private readonly DataContext _context = context;

    //    public CustomerEntity AddCustomer(CustomerEntity customer)
    //    {
    //        _context.Customers.Add(customer);
    //        _context.SaveChanges();
    //        return customer;
    //    }

    //    public IEnumerable<CustomerEntity> GetAllCustomers()
    //    {
    //        return _context.Customers;
    //    }
    //    public CustomerEntity GetCustomer(int id)
    //    {
    //        var customer = _context.Customers.FirstOrDefault(x => x.Id == id);
    //        return customer ?? null!;
    //    }
    //    public CustomerEntity UpdateCustomer(CustomerEntity customer)
    //    {
    //        _context.Customers.Update(customer);
    //        _context.SaveChanges();
    //        return customer;
    //    }
    //    public bool DeleteCustomer(int id)
    //    {
    //        var customer = GetCustomer(id);
    //        if (customer != null)
    //        {
    //            _context.Customers.Remove(customer);
    //            _context.SaveChanges();
    //            return true;
    //        }
    //        else
    //        {
    //            return false;
    //        }
    //    }
    //}
}
