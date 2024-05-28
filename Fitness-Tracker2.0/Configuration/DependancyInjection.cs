using DBLibrary;
using ManagerLibrary;
using Microsoft.Extensions.DependencyInjection;
using IRepositories;
using Unit_Testing.FakeRepo;

namespace Fitness_Tracker2._0.Configuration
{
    public static class DependencyInjection
    {
        public static void ConfigureServices(IServiceCollection services, bool useFakeRepository = false)
        {
            if (useFakeRepository)
            {
                services.AddSingleton<IEmployeeRepo, FakeEmployeeRepo>();
                services.AddSingleton<IExerciseRepo, FakeExerciseRepo>();
            }
            else
            {
                services.AddSingleton<IEmployeeRepo, EmployeeDBManager>();
                services.AddSingleton<IExerciseRepo, ExerciseDBManager>();
            }

            services.AddSingleton<EmployeeManager>();
            services.AddSingleton<ExerciseManager>();
        }
    }
}
