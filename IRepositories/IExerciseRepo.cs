using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NameLibrary;
using ExerciseLibrary;

namespace IRepositories
{
    public interface IExerciseRepo
    {
        bool AddStrengthExercise(Strength strength);
        bool AddCardioExercise(Cardio cardio);
        bool AddWorkoutWithoutExercises(Workouts workout);
        void AddExerciseToWorkout(int workoutId, int exerciseId);
        Exercise? GetExerciseById(int exerciseId);
        Cardio? GetCardioExerciseById(int exerciseId);
        Strength? GetStrengthExerciseById(int exerciseId);
        List<Exercise>? GetExercisesForWorkout(int workoutId);
        void DeleteWorkout(int workoutId);
        void DeleteStrengthExercise(Strength strengthExercise);
        void DeleteCardioExercise(Cardio cardioExercise);
        List<int> GetWorkoutIdsContainingExercise(int exerciseId);
        List<Workouts>? GetAllWorkouts();
        List<Cardio>? GetCardioExercises();
        List<Strength>? GetStrengthExercises();
        Workouts? GetWorkout(Workouts workout);
        Workouts? GetWorkoutById(int workoutId);
        bool ExerciseAlreadyExistsInWorkout(int workoutId, int exerciseId);
    }
}
