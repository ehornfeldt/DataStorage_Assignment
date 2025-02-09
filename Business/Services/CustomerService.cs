using Data.Contexts;
using Data.Entities;

namespace Business.Services
{
    public class CustomerService(DataContext context) : ICustomerService
    {
        private readonly DataContext _context = context;

        public CustomerEntity AddCustomer(CustomerEntity customer)
        {
            _context.Customers.Add(customer);
            _context.SaveChanges();
            return customer;
        }

        public IEnumerable<CustomerEntity> GetAllCustomers()
        {
            return _context.Customers;
        }
        public CustomerEntity GetCustomer(int id)
        {
            var customer = _context.Customers.FirstOrDefault(x => x.Id == id);
            return customer ?? null!;
        }
        public CustomerEntity UpdateCustomer(CustomerEntity customer)
        {
            _context.Customers.Update(customer);
            _context.SaveChanges();
            return customer;
        }
        public bool DeleteCustomer(int id)
        {
            var customer = GetCustomer(id);
            if (customer != null)
            {
                _context.Customers.Remove(customer);
                _context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
