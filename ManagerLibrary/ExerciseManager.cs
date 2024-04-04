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
        private List<Exercise> exercises;
        private ExerciseDBManager exerciseDBManager;

        public ExerciseManager()
        {
            exercises = new List<Exercise>();
            exerciseDBManager = new ExerciseDBManager();
            InitializeExerciseList();
        }
        public void InitializeExerciseList()
        {
            new List<Exercise>();
        }
        public void AddStrengthExercise(Strength strengthExercise)
        {
            exerciseDBManager.AddStrengthExerciseToDB(strengthExercise);
            InitializeExerciseList();
        }
        public List<Exercise> GetExercises()
        {
            return exercises;
        }
        public void DeleteExercise(int id)
        {
            exerciseDBManager.DeleteExercise(id);
            InitializeExerciseList();
        }

    }
}
