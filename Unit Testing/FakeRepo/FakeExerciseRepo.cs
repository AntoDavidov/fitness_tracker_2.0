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
        private readonly List<Workouts> _workouts = new();
        private readonly List<(int WorkoutId, int ExerciseId)> _workoutExercises = new();

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

        public bool AddWorkoutWithoutExercises(Workouts workout)
        {
            _workouts.Add(workout);
            return true;
        }

        

        public Exercise? GetExerciseById(int exerciseId)
        {
            return _strengthExercises.FirstOrDefault(e => e.GetId() == exerciseId) as Exercise ??
                   _cardioExercises.FirstOrDefault(e => e.GetId() == exerciseId) as Exercise;
        }

        public Cardio? GetCardioExerciseById(int exerciseId)
        {
            return _cardioExercises.FirstOrDefault(e => e.GetId() == exerciseId);
        }

        public Strength? GetStrengthExerciseById(int exerciseId)
        {
            return _strengthExercises.FirstOrDefault(e => e.GetId() == exerciseId);
        }
        public void DeleteStrengthExercise(Strength strengthExercise)
        {
            _strengthExercises.RemoveAll(e => e.GetId() == strengthExercise.GetId());
        }

        public void DeleteCardioExercise(Cardio cardioExercise)
        {
            _cardioExercises.RemoveAll(e => e.GetId() == cardioExercise.GetId());
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
