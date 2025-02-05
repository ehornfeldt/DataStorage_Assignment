﻿using Business.Services;
using Data.Entities;

namespace Presentation.Dialogs
{
    public class ProjectDialog(IProjectService projectService, ICustomerService customerService) : IProjectDialog
    {
        private readonly IProjectService _projectService = projectService;
        private readonly ICustomerService _customerService = customerService;
        public void CreateProjectDialog()
        {
            var project = new ProjectEntity();

            Console.WriteLine("Set project name:");
            project.Name = Console.ReadLine()!;
            Console.WriteLine("Set start date of project:");
            project.StartDate = Console.ReadLine()!;
            Console.WriteLine("Set end date of project:");
            project.EndDate = Console.ReadLine()!;
            Console.WriteLine("Set status on project:");
            project.Status = Console.ReadLine()!;
            Console.WriteLine("Set projectleader:");
            project.ProjectLeader = Console.ReadLine()!;

            Console.WriteLine("--- Below are added customers --- ");
            foreach (var customer in _customerService.GetAllCustomers())
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

            var result = _projectService.AddProject(project);
            if (result != null)
            {
                Console.WriteLine($"{"Project added with id:"} {result.Id}");
            }
            else
            {
                Console.WriteLine("Somethong went wrong");
            }
            Console.ReadKey();
        }
    }
}
