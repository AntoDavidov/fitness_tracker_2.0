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
        //private readonly List<Workouts> _workouts = new();
        //private readonly List<(int WorkoutId, int ExerciseId)> _workoutExercises = new();

        public bool AddStrengthExercise(Strength strength)
        {
            _strengthExercises.Add(strength);
            return true;
        }

        public bool AddCardioExercise(Cardio cardio)
        {
            _cardioExercises.Add(cardio);
            return true;
        }

        public Exercise? GetExerciseById(int exerciseId)
        {
            foreach (var exercise in _strengthExercises)
            {
                if (exercise.GetId() == exerciseId)
                {
                    return exercise;
                }
            }

            foreach (var exercise in _cardioExercises)
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
            foreach (var exercise in _cardioExercises)
            {
                if (exercise.GetId() == exerciseId)
                {
                    return exercise;
                }
            }

            return null;
        }

        public Strength? GetStrengthExerciseById(int exerciseId)
        {
            foreach (var exercise in _strengthExercises)
            {
                if (exercise.GetId() == exerciseId)
                {
                    return exercise;
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
