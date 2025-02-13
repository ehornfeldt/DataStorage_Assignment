﻿using Business.Services;
using Data.Contexts;
using Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Presentation.Dialogs;

var serviceCollection = new ServiceCollection();
serviceCollection.AddDbContext<DataContext>(options => options.UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=C:\Projects\DataStorage_Assignment\Data\Databases\local_db.mdf;Integrated Security=True;Connect Timeout=30;Encrypt=True"));
serviceCollection.AddScoped<CustomerRepository>();
serviceCollection.AddScoped<ProjectRepository>();
serviceCollection.AddScoped<IProjectService, ProjectService>();
serviceCollection.AddScoped<ICustomerService, CustomerService>();

serviceCollection.AddScoped<IProjectDialog, ProjectDialog>();
serviceCollection.AddScoped<ICustomerDialog, CustomerDialog>();

var serviceProvider = serviceCollection.BuildServiceProvider();
var projectDialog = serviceProvider.GetRequiredService<IProjectDialog>();
var customerDialog = serviceProvider.GetRequiredService<ICustomerDialog>();

var running = true;

while (running)
{
    Console.WriteLine("Choose any of following options:");
    Console.WriteLine("1 - Add new customer");
    Console.WriteLine("2 - Add new project");
    Console.WriteLine("3 - View all projects");
    Console.WriteLine("4 - View one project");
    Console.WriteLine("5 - Edit project");
    Console.WriteLine("6 - Delete project");
    Console.WriteLine("q - Quit");

    var user_input = Console.ReadLine();
    switch(user_input)
    {
        case "1":
            await customerDialog.CreateCustomerDialog();
            break;
        case "2":
            await projectDialog.CreateProjectDialog();
            break;
        case "3":
            await projectDialog.ViewProjectsDialog();
            break;
        case "4":
            await projectDialog.ViewSingleProjectDialog();
            break;
        case "5":
            await projectDialog.UpdateProjectDialog();
            break;
        case "6":
            await projectDialog.DeleteProjectDialog();
            break;
        case "q":
            running = false;
            break;
        default:
            Console.WriteLine("Option not valid, try again");
            break ;
    }
}