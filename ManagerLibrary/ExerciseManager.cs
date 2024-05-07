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
        private List<Exercise> cashedExercises;
        private ExerciseDBManager exerciseDBManager;

        public ExerciseManager()
        {
            exerciseDBManager = new ExerciseDBManager();
            cashedExercises = null;
        }
        public void AddStrengthExercise(Strength strengthExercise)
        {
            exerciseDBManager.AddStrengthExerciseToDB(strengthExercise);
        }

        public void AddCardioExercise(Cardio cardioExercise)
        {
            exerciseDBManager.AddCardioExerciseToDB(cardioExercise);
        }
        //public List<Exercise> GetExercises()
        //{
        //    if (cashedExercises == null)
        //    {
        //        cashedExercises = exerciseDBManager.GetAllStrengthExercisesFromDB();
        //    }
        //}
        public void DeleteExercise(int id)
        {
            exerciseDBManager.DeleteExercise(id);
        }

    }
}
