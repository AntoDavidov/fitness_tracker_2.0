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
        List<int> GetWorkoutIdsContainingExercise(int exerciseId);
        void DeleteWorkout(int workoutId);
        List<Exercise>? GetExercisesForWorkout(int workoutId);
    }
}
