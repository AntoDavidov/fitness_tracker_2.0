using ExerciseLibrary;
using IRepositories;
using System;
using System.Collections.Generic;

namespace Unit_Testing.FakeRepo
{
    public class FakeExerciseRepo : IExerciseRepo
    {
        private readonly List<Exercise> _exercises;

        public FakeExerciseRepo() 
        {
            _exercises = new List<Exercise>
            {
                new Strength(1, "Push Up", "A basic push-up exercise", MuscleGroup.Chest, 10, 3, 0),
                new Strength(2, "Bench Press", "Bench press with barbell", MuscleGroup.Chest, 8, 4, 100),
                new Strength(3, "Squat", "Barbell squat", MuscleGroup.Legs, 12, 3, 150),
                new Strength(4, "Deadlift", "Deadlift with barbell", MuscleGroup.Back, 5, 5, 200),
                new Strength(5, "Bicep Curl", "Dumbbell bicep curls", MuscleGroup.Bicep, 15, 3, 20),
                new Cardio(6, "Running", "Running on treadmill", TimeSpan.FromMinutes(3)),
                new Cardio(7, "Cycling", "Stationary bike cycling", TimeSpan.FromMinutes(5)),
            };
        
        }
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
                if (exercise is Cardio cardio && cardio.GetId() == exerciseId)
                {
                    return cardio;
                }
            }
            return null;
        }

        public Strength? GetStrengthExerciseById(int exerciseId)
        {
            foreach (var exercise in _exercises)
            {
                if (exercise is Strength strength && strength.GetId() == exerciseId)
                {
                    return strength;
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
            List<Exercise> matchingExercises = new List<Exercise>();
            foreach (var exercise in _exercises)
            {
                if ((string.IsNullOrEmpty(exerciseType) ||
                    (exerciseType == "Strength" && exercise is Strength) ||
                    (exerciseType == "Cardio" && exercise is Cardio)) &&
                    (string.IsNullOrEmpty(exerciseName) ||
                    exercise.GetName().Contains(exerciseName, StringComparison.OrdinalIgnoreCase)))
                {
                    matchingExercises.Add(exercise);
                }
            }
            return matchingExercises;
        }

        public void DeleteStrengthExercise(Strength strengthExercise)
        {
            for (int i = 0; i < _exercises.Count; i++)
            {
                if (_exercises[i] is Strength strength && strength.GetId() == strengthExercise.GetId())
                {
                    _exercises.RemoveAt(i);
                    break;
                }
            }
        }

        public void DeleteCardioExercise(Cardio cardioExercise)
        {
            for (int i = 0; i < _exercises.Count; i++)
            {
                if (_exercises[i] is Cardio cardio && cardio.GetId() == cardioExercise.GetId())
                {
                    _exercises.RemoveAt(i);
                    break;
                }
            }
        }

        public List<Cardio>? GetCardioExercises()
        {
            List<Cardio> cardioExercises = new List<Cardio>();
            foreach (var exercise in _exercises)
            {
                if (exercise is Cardio cardio)
                {
                    cardioExercises.Add(cardio);
                }
            }
            return cardioExercises;
        }

        public List<Strength>? GetStrengthExercises()
        {
            List<Strength> strengthExercises = new List<Strength>();
            foreach (var exercise in _exercises)
            {
                if (exercise is Strength strength)
                {
                    strengthExercises.Add(strength);
                }
            }
            return strengthExercises;
        }
    }
}
