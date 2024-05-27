using System;
using System.Collections.Generic;
using DBLibrary;
using DBLibrary.IRepositories;
using ExerciseLibrary;

namespace ManagerLibrary
{
    public class ExerciseManager
    {
        private List<Exercise> cachedExercises;
        private readonly IExerciseRepository _exerciseRepository;

        public ExerciseManager(IExerciseRepository exerciseRepository)
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

        public List<Strength> GetOnlyStrengthExercises()
        {
            return _exerciseRepository.GetStrengthExercises();
        }

        public List<Cardio> GetOnlyCardioExercises()
        {
            return _exerciseRepository.GetCardioExercises();
        }

        public bool AddWorkoutWithoutExercises(Workouts workout)
        {
            return _exerciseRepository.AddWorkoutWithoutExercises(workout);
        }

        public Strength? GetStrengthExerciseById(int strengthId)
        {
            return _exerciseRepository.GetStrengthExerciseById(strengthId);
        }

        public Cardio? GetCardioExerciseById(int cardioId)
        {
            return _exerciseRepository.GetCardioExerciseById(cardioId);
        }

        public Exercise? GetExerciseById(int exerciseId)
        {
            return _exerciseRepository.GetExerciseById(exerciseId);
        }

        public Workouts? FindWorkout(Workouts workout)
        {
            return _exerciseRepository.GetWorkout(workout);
        }

        public Workouts? GetWorkoutById(int workoutId)
        {
            return _exerciseRepository.GetWorkoutById(workoutId);
        }

        public void AddExerciseToWorkout(Workouts workout, Exercise exercise)
        {
            _exerciseRepository.AddExerciseToWorkout(workout.GetId(), exercise.GetId());
        }

        public List<Exercise> GetCurrentWorkoutExercises(Workouts workouts)
        {
            return _exerciseRepository.GetExercisesForWorkout(workouts.GetId());
        }

        public bool ExerciseExistsInWorkout(Workouts workouts, Exercise exercise)
        {
            return _exerciseRepository.ExerciseAlreadyExistsInWorkout(workouts.GetId(), exercise.GetId());
        }

        public List<Workouts> GetWorkouts()
        {
            return _exerciseRepository.GetAllWorkouts();
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

        public void DeleteWorkout(Workouts workouts)
        {
            _exerciseRepository.DeleteWorkout(workouts.GetId());
        }

        public List<int> GetWorkoutIdsContainingExercise(int exerciseId)
        {
            return _exerciseRepository.GetWorkoutIdsContainingExercise(exerciseId);
        }
    }
}
