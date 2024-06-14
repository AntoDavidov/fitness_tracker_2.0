using ExerciseLibrary;
using IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unit_Testing.FakeRepo
{
    public class FakeExerciseRepo : IExerciseRepo
    {
        private readonly List<Strength> _strengthExercises = new();
        private readonly List<Cardio> _cardioExercises = new();
        private readonly List<Exercise> _exercises = new(); 
        //private readonly List<Workouts> _workouts = new();
        //private readonly List<(int WorkoutId, int ExerciseId)> _workoutExercises = new();

        public bool AddStrengthExercise(Strength strength)
        {
            _exercises.Add(strength);
            return true;
        }

        public bool AddCardioExercise(Cardio cardio)
        {
            _exercises.Add(cardio);
            return true;
        }

        public Exercise? GetExerciseById(int exerciseId)
        {
            foreach (var exercise in _exercises)
            {
                if (exercise.GetId() == exerciseId)
                {
                    return exercise;
                }
            }
            return null;
        }

        public Cardio? GetCardioExerciseById(int exerciseId)
        {
            foreach (var exercise in _exercises)
            {
                if (exercise is Cardio cardio)
                {
                    if (cardio.GetId() == exerciseId)
                    {
                        return cardio;
                    }
                }
                
            }

            return null;
        }
        public List<Exercise> SearchExercisesByName(string name)
        {
            List<Exercise> matchingExercises = new List<Exercise>();

            foreach (var exercise in _exercises)
            {
                if (exercise.GetName().IndexOf(name, StringComparison.OrdinalIgnoreCase) >= 0)
                {
                    matchingExercises.Add(exercise);
                }
            }

            return matchingExercises;
        }
        public List<Exercise> SearchExercisesByNameAndType(string exerciseType, string exerciseName)
        {
            return _exercises.Where(e =>
                (string.IsNullOrEmpty(exerciseType) ||
                 (exerciseType == "Strength" && e is Strength) ||
                 (exerciseType == "Cardio" && e is Cardio)) &&
                (string.IsNullOrEmpty(exerciseName) ||
                 e.GetName().Contains(exerciseName, StringComparison.OrdinalIgnoreCase)))
            .ToList();
        }
        public Strength? GetStrengthExerciseById(int exerciseId)
        {
            foreach (var exercise in _strengthExercises)
            {
                if (exercise is Strength strength)
                {
                    if (strength.GetId() == exerciseId)
                    {
                        return strength;
                    }
                }
            }

            return null;
        }

        public void DeleteStrengthExercise(Strength strengthExercise)
        {
            for (int i = 0; i < _strengthExercises.Count; i++)
            {
                if (_strengthExercises[i].GetId() == strengthExercise.GetId())
                {
                    _strengthExercises.RemoveAt(i);
                    break;
                }
            }
        }

        public void DeleteCardioExercise(Cardio cardioExercise)
        {
            for (int i = 0; i < _cardioExercises.Count; i++)
            {
                if (_cardioExercises[i].GetId() == cardioExercise.GetId())
                {
                    _cardioExercises.RemoveAt(i);
                    break;
                }
            }
        }

        public List<Cardio>? GetCardioExercises()
        {
            return _cardioExercises;
        }

        public List<Strength>? GetStrengthExercises()
        {
            return _strengthExercises;
        }
    }
}
