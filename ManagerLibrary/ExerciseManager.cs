using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBLibrary;
using ExerciseLibrary;

namespace ManagerLibrary
{
    public class ExerciseManager
    {
        private List<Strength> cachedStrengthExercises;
        private List<Cardio> cachedCardioExercises;
        private ExerciseDBManager exerciseDBManager;

        public ExerciseManager()
        {
            exerciseDBManager = new ExerciseDBManager();
            cachedStrengthExercises = null;
            cachedCardioExercises = null;
        }
        public void AddStrengthExercise(Strength strengthExercise)
        {
            exerciseDBManager.AddStrengthExerciseToDB(strengthExercise);
        }

        public void AddCardioExercise(Cardio cardioExercise)
        {
            exerciseDBManager.AddCardioExerciseToDB(cardioExercise);
        }
        public List<Exercise> GetExerciseList()
        {
            List<Exercise> allExercises = new List<Exercise>();

            // Fetch Strength exercises
            if (cachedStrengthExercises == null)
            {
                cachedStrengthExercises = exerciseDBManager.GetStrengthExercises();
            }

            // Fetch Cardio exercises
            if (cachedCardioExercises == null)
            {
                cachedCardioExercises = exerciseDBManager.GetCardioExercises();
            }

            // Combine Strength and Cardio exercises into a single list
            allExercises.AddRange(cachedStrengthExercises);
            allExercises.AddRange(cachedCardioExercises);

            return allExercises;
        }
        public List<Strength> GetOnlyStrengthExercises()
        {
            return exerciseDBManager.GetStrengthExercises();
        }
        public List<Cardio> GetOnlyCardioExercises()
        {
            return exerciseDBManager.GetCardioExercises();
        }
        public bool AddWorkout(Workouts workout)
        {
            return exerciseDBManager.AddWorkoutToDB(workout);
        }
        public bool AddWorkoutWithoutExercises(Workouts workout)
        {
            return exerciseDBManager.AddWorkoutToDBWithoutExercises(workout);
        }
        public Strength? GetStrengthExerciseById(int strengthId)
        {
            return exerciseDBManager.GetStrengthExerciseById(strengthId);
        }
        public Cardio? GetCardioExerciseById(int cardioId)
        {
            return exerciseDBManager.GetCardioExerciseById(cardioId);
        }
        public Exercise? GetExerciseById(int exerciseId)
        {
            return exerciseDBManager.GetExerciseById(exerciseId);
        }
        public Workouts? FindWorkout(Workouts workout)
        {
            return exerciseDBManager.GetWorkout(workout);
        }
        public void AddExerciseToWorkout(Workouts workout, Exercise exercise)
        {
            exerciseDBManager.AddExerciseToWorkout(workout.GetId(), exercise.GetId());
            workout.AddExercise(exercise);
        }
        public List<Workouts> GetWorkouts()
        {
            return exerciseDBManager.GetAllWorkoutsFromDB();
        }
        public void DeleteExercise(int id)
        {
            exerciseDBManager.DeleteExercise(id);
        }


    }
}
