using Business.Services;
using Data.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Presentation.Dialogs;

var serviceCollection = new ServiceCollection();
serviceCollection.AddDbContext<DataContext>(options => options.UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Projects\DataStorage_Assignment\Data\Databases\local_db.mdf;Integrated Security=True;Connect Timeout=30;Encrypt=True"));
serviceCollection.AddScoped<IProjectService, ProjectService>();
serviceCollection.AddScoped<ICustomerService, CustomerService>();
serviceCollection.AddScoped<IProjectDialog, ProjectDialog>();
serviceCollection.AddScoped<ICustomerDialog, CustomerDialog>();

var serviceProvider = serviceCollection.BuildServiceProvider();
var projectDialog = serviceProvider.GetRequiredService<IProjectDialog>();
var customerDialog = serviceProvider.GetRequiredService<ICustomerDialog>();

while (true)
{
    Console.WriteLine("Hej!");
    var user_input = Console.ReadLine();
    if(user_input == "q")
    {
        break;
    }
    customerDialog.CreateCustomerDialog();
    projectDialog.CreateProjectDialog();
    Console.ReadKey();
}