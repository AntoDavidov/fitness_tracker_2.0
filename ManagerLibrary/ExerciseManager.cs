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
        //remove
        public List<Exercise> GetExerciseList()
        {
            if (cachedExercises == null)
            {
                cachedExercises = new List<Exercise>();
                cachedExercises.AddRange(_exerciseRepository.GetStrengthExercises());
                cachedExercises.AddRange(_exerciseRepository.GetCardioExercises());
            }

            return cachedExercises;
        }
        public List<Exercise> SearchExercisesByName(string name)
        {
            return _exerciseRepository.SearchExercisesByName(name);
        }

        public List<Strength> GetOnlyStrengthExercises()
        {
            return _exerciseRepository.GetStrengthExercises();
        }
        public List<Exercise> SearchExercisesByTypeAndName(string exerciseType, string exerciseName)
        {
            return _exerciseRepository.SearchExercisesByNameAndType(exerciseType, exerciseName);
        }


        public List<Cardio> GetOnlyCardioExercises()
        {
            return _exerciseRepository.GetCardioExercises();
        }
        //remove
        public Strength? GetStrengthExerciseById(int strengthId)
        {
            return _exerciseRepository.GetStrengthExerciseById(strengthId);
        }

        //remove
        public Cardio? GetCardioExerciseById(int cardioId)
        {
            return _exerciseRepository.GetCardioExerciseById(cardioId);
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
