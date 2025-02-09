using Data.Entities;

namespace Business.Services
{
    public interface ICustomerService
    {
        CustomerEntity AddCustomer(CustomerEntity customer);
        bool DeleteCustomer(int id);
        IEnumerable<CustomerEntity> GetAllCustomers();
        CustomerEntity GetCustomer(int id);
        CustomerEntity UpdateCustomer(CustomerEntity customer);
    }
}