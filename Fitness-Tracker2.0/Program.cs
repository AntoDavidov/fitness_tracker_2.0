using Microsoft.Extensions.DependencyInjection;
using System;
using System.Windows.Forms;
using ManagerLibrary; // Add this directive
using Fitness_Tracker2._0.Configuration; // Add this directive

namespace Fitness_Tracker2._0
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Set up dependency injection
            var services = new ServiceCollection();
            DependencyInjection.ConfigureServices(services, useFakeRepository: false); // Set to true for unit testing
            var serviceProvider = services.BuildServiceProvider();

            // Resolve the EmployeeManager and pass it to the login form
            var employeeManager = serviceProvider.GetService<EmployeeManager>();
            var exerciseManager = serviceProvider.GetService<ExerciseManager>();    
            Application.Run(new frmLoginPage(employeeManager, exerciseManager));
        }
    }
}
