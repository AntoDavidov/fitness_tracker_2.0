using DBLibrary.IRepositories;
using ExerciseLibrary;
using System.Collections.Generic;
using System.Linq;

namespace DBLibrary.FakeRepositories
{
    public class FakeExerciseRepository : IExerciseRepository
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

        public void AddExerciseToWorkout(int workoutId, int exerciseId)
        {
            _workoutExercises.Add((workoutId, exerciseId));
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

        public List<Exercise>? GetExercisesForWorkout(int workoutId)
        {
            var exerciseIds = _workoutExercises.Where(we => we.WorkoutId == workoutId).Select(we => we.ExerciseId).ToList();
            return exerciseIds.Select(GetExerciseById).ToList();
        }

        public void DeleteWorkout(int workoutId)
        {
            _workouts.RemoveAll(w => w.GetId() == workoutId);
            _workoutExercises.RemoveAll(we => we.WorkoutId == workoutId);
        }

        public void DeleteStrengthExercise(Strength strengthExercise)
        {
            _strengthExercises.RemoveAll(e => e.GetId() == strengthExercise.GetId());
        }

        public void DeleteCardioExercise(Cardio cardioExercise)
        {
            _cardioExercises.RemoveAll(e => e.GetId() == cardioExercise.GetId());
        }

        public List<int> GetWorkoutIdsContainingExercise(int exerciseId)
        {
            return _workoutExercises.Where(we => we.ExerciseId == exerciseId).Select(we => we.WorkoutId).ToList();
        }

        public List<Workouts>? GetAllWorkouts()
        {
            return _workouts;
        }

        public List<Cardio>? GetCardioExercises()
        {
            return _cardioExercises;
        }

        public List<Strength>? GetStrengthExercises()
        {
            return _strengthExercises;
        }

        public Workouts? GetWorkout(Workouts workout)
        {
            return _workouts.FirstOrDefault(w => w.GetName() == workout.GetName() &&
                                                  w.GetDescription() == workout.GetDescription() &&
                                                  w.GetWorkoutLevel() == workout.GetWorkoutLevel());
        }

        public Workouts? GetWorkoutById(int workoutId)
        {
            return _workouts.FirstOrDefault(w => w.GetId() == workoutId);
        }

        public bool ExerciseAlreadyExistsInWorkout(int workoutId, int exerciseId)
        {
            return _workoutExercises.Any(we => we.WorkoutId == workoutId && we.ExerciseId == exerciseId);
        }
    }
}
