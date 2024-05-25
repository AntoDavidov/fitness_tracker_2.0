using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBLibrary;
using DBLibrary.IRepositories;
using ExerciseLibrary;

namespace ManagerLibrary
{
    public class ExerciseManager
    {
        private List<Strength> cachedStrengthExercises;
        private List<Cardio> cachedCardioExercises;
        private readonly IExerciseRepository _exerciseRepository;

        public ExerciseManager(IExerciseRepository exerciseRepository)
        {
            _exerciseRepository = exerciseRepository;
            cachedStrengthExercises = null;
            cachedCardioExercises = null;
        }

        public void AddStrengthExercise(Strength strengthExercise)
        {
            _exerciseRepository.AddStrengthExercise(strengthExercise);
        }

        public void AddCardioExercise(Cardio cardioExercise)
        {
            _exerciseRepository.AddCardioExercise(cardioExercise);
        }

        public List<Exercise> GetExerciseList()
        {
            List<Exercise> allExercises = new List<Exercise>();

            if (cachedStrengthExercises == null)
            {
                cachedStrengthExercises = _exerciseRepository.GetStrengthExercises();
            }

            if (cachedCardioExercises == null)
            {
                cachedCardioExercises = _exerciseRepository.GetCardioExercises();
            }

            allExercises.AddRange(cachedStrengthExercises);
            allExercises.AddRange(cachedCardioExercises);

            return allExercises;
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

        public void DeleteStrengthExercise(Strength strength)
        {
            _exerciseRepository.DeleteStrengthExercise(strength);
        }

        public void DeleteCardioExercise(Cardio cardio)
        {
            _exerciseRepository.DeleteCardioExercise(cardio);
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
