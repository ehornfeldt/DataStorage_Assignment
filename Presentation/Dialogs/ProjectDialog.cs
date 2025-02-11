using Business.Models;
using Business.Services;
using Data.Entities;

namespace Presentation.Dialogs
{
    public class ProjectDialog(IProjectService projectService, ICustomerService customerService) : IProjectDialog
    {
        private readonly IProjectService _projectService = projectService;
        private readonly ICustomerService _customerService = customerService;
        public async Task CreateProjectDialog()
        {
            var project = new ProjectRegistrationForm();

            Console.WriteLine("Set project name:");
            project.Name = Console.ReadLine()!;
            Console.WriteLine("Set start date of project (YYYY-MM-DD):");
            while (true)
            {
                var startDate = Console.ReadLine()!;
                if (DateTime.TryParse(startDate, out DateTime date))
                {
                    project.StartDate = date;
                    break;
                }
                else
                {
                    Console.WriteLine("Wrong format, write date in format YYYY-MM-DD");
                }
            }
            Console.WriteLine("Set end date of project (YYYY-MM-DD):");
            while (true)
            {
                var endDate = Console.ReadLine()!;
                if (DateTime.TryParse(endDate, out DateTime date))
                {
                    project.EndDate = date;
                    break;
                }
                else
                {
                    Console.WriteLine("Wrong format, write date in format YYYY-MM-DD");
                }
            }
            Console.WriteLine("Set status on project:");
            project.Status = Console.ReadLine()!;
            Console.WriteLine("Set projectleader:");
            project.ProjectLeader = Console.ReadLine()!;

            Console.WriteLine("--- Below are added customers --- ");
            var customers = await _customerService.GetCustomersAsync();
            foreach (var customer in customers)
            {
                Console.WriteLine($"{"Id:"} {customer.Id,-5} {"Name:"} {customer.CustomerName}");
            }
            Console.WriteLine("---------------------------------");

            Console.WriteLine("Set customer id:");
            project.CustomerId = int.Parse(Console.ReadLine()!);
            Console.WriteLine("Set service:");
            project.Service = Console.ReadLine()!;
            Console.WriteLine("Set price:");
            project.Price = int.Parse(Console.ReadLine()!);

            var result = await _projectService.CreateProjectAsync(project);
            if (result != null)
            {
                Console.WriteLine($"{"Project added with id:"} {result.Id}");
            }
            else
            {
                Console.WriteLine("Somethong went wrong");
            }
        }

        public async Task ViewProjectsDialog()
        {
            Console.WriteLine("--- Below are added projects --- ");
            var projects = await _projectService.GetProjectsAsync();
            //foreach (var project in projects)
            //{
            //    Console.WriteLine($"{"Name:"} {project.Name,-5} {"Date:"} {project.StartDate} {"-"} {project.EndDate,-5} {"Customer:"} {project.Customer.CustomerName,-5} {"Projectleader:"} {project.ProjectLeader,-5} {"Status:"} {project.Status,-5} {"Service:"} {project.Service,-5} {"Price:"} {project.Price,-5}");
            //}
            foreach (var project in projects)
            {
                if (project.Customer == null)
                {
                    Console.WriteLine($"2:Project ID {project.Id} has no associated customer.");
                }
                else
                {
                    Console.WriteLine($"--- Name: {project.Name} ---");
                    Console.WriteLine($"Date: {project.StartDate} - {project.EndDate}");
                    Console.WriteLine($"Customer: {project.Customer.CustomerName}");
                    Console.WriteLine($"Projectleader: {project.ProjectLeader}");
                    Console.WriteLine($"Status: {project.Status}");
                    Console.WriteLine($"Service: {project.Service}");
                    Console.WriteLine($"Price: {project.Price}");
                    Console.WriteLine(" ");
                }
            }
            Console.WriteLine("---------------------------------");

        }
    }
}
