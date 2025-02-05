using Business.Services;
using Data.Entities;

namespace Presentation.Dialogs
{
    public class CustomerDialog(ICustomerService customerService) : ICustomerDialog
    {
        private readonly ICustomerService _customerService = customerService;
        public void CreateCustomerDialog()
        {
            var customer = new CustomerEntity();

            Console.WriteLine("Set customer name:");
            customer.CustomerName = Console.ReadLine()!;

            var result = _customerService.AddCustomer(customer);
            if (result != null)
            {
                Console.WriteLine($"{"Customer added with id:"} {result.Id}");
            }
            else
            {
                Console.WriteLine("Somethong went wrong");
            }
            Console.ReadKey();
        }

    }
}
