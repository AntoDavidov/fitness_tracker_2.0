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
        public void DeleteExercise(int id)
        {
            exerciseDBManager.DeleteExercise(id);
        }

    }
}
