using System;
using System.Collections.Generic;
using DBLibrary;
using ExerciseLibrary;
using IRepositories;

namespace ManagerLibrary
{
    public class ExerciseManager
    {
        private List<Exercise> cachedExercises;
        private readonly IExerciseRepo _exerciseRepository;

        public ExerciseManager(IExerciseRepo exerciseRepository)
        {
            _exerciseRepository = exerciseRepository;
            cachedExercises = null;
        }

        public void AddExercise(Exercise exercise)
        {
            if (exercise is Strength strengthExercise)
            {
                _exerciseRepository.AddStrengthExercise(strengthExercise);
            }
            else if (exercise is Cardio cardioExercise)
            {
                _exerciseRepository.AddCardioExercise(cardioExercise);
            }

            cachedExercises = null; 
        }

        public List<Exercise> SearchExercisesByName(string name)
        {
            return _exerciseRepository.SearchExercisesByName(name);
        }
        public List<Exercise> SearchExercisesByTypeAndName(string exerciseType, string exerciseName)
        {
            return _exerciseRepository.SearchExercisesByNameAndType(exerciseType, exerciseName);
        }

        public Exercise? GetExerciseById(int exerciseId)
        {
            return _exerciseRepository.GetExerciseById(exerciseId);
        }

        public void DeleteExercise(Exercise exercise)
        {
            if (exercise is Strength strengthExercise)
            {
                _exerciseRepository.DeleteStrengthExercise(strengthExercise);
            }
            else if (exercise is Cardio cardioExercise)
            {
                _exerciseRepository.DeleteCardioExercise(cardioExercise);
            }

            cachedExercises = null; 
        }
    }
}
