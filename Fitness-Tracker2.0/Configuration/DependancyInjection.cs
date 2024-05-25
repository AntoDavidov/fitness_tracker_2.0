using DBLibrary;
using DBLibrary.FakeRepositories;
using DBLibrary.IRepositories;
using ManagerLibrary;
using Microsoft.Extensions.DependencyInjection;

namespace Fitness_Tracker2._0.Configuration
{
    public static class DependencyInjection
    {
        public static void ConfigureServices(IServiceCollection services, bool useFakeRepository = false)
        {
            if (useFakeRepository)
            {
                services.AddSingleton<IEmployeeRepository, FakeEmployeeRepository>();
                services.AddSingleton<IExerciseRepository, FakeExerciseRepository>();
            }
            else
            {
                services.AddSingleton<IEmployeeRepository, EmployeeDBManager>();
                services.AddSingleton<IExerciseRepository, ExerciseDBManager>();
            }

            services.AddSingleton<EmployeeManager>();
            services.AddSingleton<ExerciseManager>();
        }
    }
}
