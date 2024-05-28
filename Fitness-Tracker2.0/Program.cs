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

            var services = new ServiceCollection();
            DependencyInjection.ConfigureServices(services, useFakeRepository: false); 
            var serviceProvider = services.BuildServiceProvider();

            var employeeManager = serviceProvider.GetService<EmployeeManager>();
            var exerciseManager = serviceProvider.GetService<ExerciseManager>();
            var workoutManager = serviceProvider.GetService<WorkoutManager>();
            Application.Run(new frmLoginPage(employeeManager, exerciseManager, workoutManager));
        }
    }
}
