﻿using Business.Models;
using Business.Services;

namespace Presentation.Dialogs
{
    public class CustomerDialog(ICustomerService customerService) : ICustomerDialog
    {
        private readonly ICustomerService _customerService = customerService;
        public async Task CreateCustomerDialog()
        {
            var customer = new CustomerRegistrationForm();

            Console.WriteLine("Set customer name:");
            customer.CustomerName = Console.ReadLine()!;

            var result = await _customerService.CreateCustomerAsync(customer);
            if (result != null)
            {
                Console.WriteLine($"{"Customer added with id:"} {result.Id}");
                Console.WriteLine($" ");
            }
            else
            {
                Console.WriteLine("Somethong went wrong");
            }
        }

    }
}
