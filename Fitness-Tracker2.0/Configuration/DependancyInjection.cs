using DBLibrary;
using DBLibrary.FakeDBManager;
using DBLibrary.FakeRepositories;
using DBLibrary.IRepositories;
using ManagerLibrary;
using Microsoft.Extensions.DependencyInjection;

namespace YourProject.Configuration
{
    public static class DependencyInjection
    {
        public static void ConfigureServices(IServiceCollection services, bool useFakeRepository = false)
        {
            if (useFakeRepository)
            {
                services.AddSingleton<IExerciseRepository, FakeExerciseRepository>();
            }
            else
            {
                services.AddSingleton<IExerciseRepository, ExerciseDBManager>();
            }

            services.AddSingleton<ExerciseManager>();
        }
    }
}
