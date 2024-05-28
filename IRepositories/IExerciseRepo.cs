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
        Exercise? GetExerciseById(int exerciseId);
        Cardio? GetCardioExerciseById(int exerciseId);
        Strength? GetStrengthExerciseById(int exerciseId);
        void DeleteStrengthExercise(Strength strengthExercise);
        void DeleteCardioExercise(Cardio cardioExercise);
        List<Cardio>? GetCardioExercises();
        List<Strength>? GetStrengthExercises();
    }
}
