using ExerciseLibrary;
using IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unit_Testing.FakeRepo
{
    public class FakeWorkoutRepo : IWorkoutRepo
    {
        private readonly List<Workouts> _workouts = new();
        private readonly List<(int WorkoutId, int ExerciseId)> _workoutExercises = new();
        private readonly FakeExerciseRepo _exerciseRepo;

        public FakeWorkoutRepo()
        {

        }

        public void AddExerciseToWorkout(int workoutId, int exerciseId)
        {
            _workoutExercises.Add((workoutId, exerciseId));
        }

        public bool AddWorkoutWithoutExercises(Workouts workout)
        {
            _workouts.Add(workout);
            return true;
        }

        public void DeleteWorkout(int workoutId)
        {
            for (int i = _workouts.Count - 1; i >= 0; i--)
            {
                if (_workouts[i].GetId() == workoutId)
                {
                    _workouts.RemoveAt(i);
                }
            }
            for (int i = _workoutExercises.Count - 1; i >= 0; i--)
            {
                if (_workoutExercises[i].WorkoutId == workoutId)
                {
                    _workoutExercises.RemoveAt(i);
                }
            }
        }

        public List<Exercise>? GetExercisesForWorkout(int workoutId)
        {
            List<int> exerciseIds = new List<int>();
            foreach (var we in _workoutExercises)
            {
                if (we.WorkoutId == workoutId)
                {
                    exerciseIds.Add(we.ExerciseId);
                }
            }

            List<Exercise> exercises = new List<Exercise>();
            foreach (var exerciseId in exerciseIds)
            {
                var exercise = _exerciseRepo.GetExerciseById(exerciseId);
                if (exercise != null)
                {
                    exercises.Add(exercise);
                }
            }
            return exercises;
        }

        public List<int> GetWorkoutIdsContainingExercise(int exerciseId)
        {
            List<int> workoutIds = new List<int>();
            foreach (var we in _workoutExercises)
            {
                if (we.ExerciseId == exerciseId)
                {
                    workoutIds.Add(we.WorkoutId);
                }
            }
            return workoutIds;
        }

        public List<Workouts>? GetAllWorkouts()
        {
            return _workouts;
        }

        public Workouts? GetWorkout(Workouts workout)
        {
            foreach (var w in _workouts)
            {
                if (w.GetName() == workout.GetName() &&
                    w.GetDescription() == workout.GetDescription() &&
                    w.GetWorkoutLevel() == workout.GetWorkoutLevel())
                {
                    return w;
                }
            }
            return null;
        }

        public Workouts? GetWorkoutById(int workoutId)
        {
            foreach (var w in _workouts)
            {
                if (w.GetId() == workoutId)
                {
                    return w;
                }
            }
            return null;
        }

        public bool ExerciseAlreadyExistsInWorkout(int workoutId, int exerciseId)
        {
            foreach (var we in _workoutExercises)
            {
                if (we.WorkoutId == workoutId && we.ExerciseId == exerciseId)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
