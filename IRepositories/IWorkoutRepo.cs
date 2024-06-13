using ExerciseLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRepositories
{
    public interface IWorkoutRepo
    {
        bool AddWorkoutWithoutExercises(Workouts workout);
        void AddExerciseToWorkout(int workoutId, int exerciseId);
        Workouts? GetWorkout(Workouts workout);
        Workouts? GetWorkoutById(int workoutId);
        bool ExerciseAlreadyExistsInWorkout(int workoutId, int exerciseId);
        List<Workouts>? GetAllWorkouts();
        public List<Workouts> GetWorkoutsByPage(int pageIndex, int pageSize);
        public List<Workouts> GetFilteredWorkouts(int? level, bool includeLevel, int pageIndex, int pageSize);
        public int GetFilteredWorkoutsCount(int? level, bool includeLevel);

        public int GetTotalWorkoutsCount();
        List<Workouts> GetTopRatedWorkouts(int topN);
        List<int> GetWorkoutIdsContainingExercise(int exerciseId);
        void DeleteWorkout(int workoutId);
        List<Exercise>? GetExercisesForWorkout(int workoutId);
        void RemoveExerciseFromWorkout(int workoutId, int exerciseId);
    }
}
