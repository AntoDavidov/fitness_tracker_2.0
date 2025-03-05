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
                services.AddSingleton<IWorkoutRepo, FakeWorkoutRepo>();
                
            }
            else
            {
                services.AddSingleton<IEmployeeRepo, EmployeeDBManager>();
                services.AddSingleton<IExerciseRepo, ExerciseDBManager>();
                services.AddSingleton<IWorkoutRepo, WorkoutDBManager>();
            }

            services.AddSingleton<EmployeeManager>();
            services.AddSingleton<ExerciseManager>();
            services.AddSingleton<WorkoutManager>();
        }
    }
}
