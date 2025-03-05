using ExerciseLibrary;
using IRepositories;
using NameLibrary;
using System;
using System.Collections.Generic;

namespace Unit_Testing.FakeRepo
{
    public class FakeWorkoutRepo : IWorkoutRepo
    {
        private readonly List<Workouts> _workouts = new();
        private readonly List<(int WorkoutId, int ExerciseId)> _workoutExercises = new();
        private readonly FakeExerciseRepo _exerciseRepo;

        public FakeWorkoutRepo()
        {
            _workouts = new List<Workouts>
            {
                new Workouts(1, "Workout 1", "Description for Workout 1", Level.Beginner),
                new Workouts(2, "Workout 2", "Description for Workout 2", Level.Intermediate),
                new Workouts(3, "Workout 3", "Description for Workout 3", Level.Advanced),
                new Workouts(4, "Workout 4", "Description for Workout 4", Level.Intermediate),
                new Workouts(5, "Workout 5", "Description for Workout 5", Level.Advanced),
            };

            _workoutExercises = new List<(int WorkoutId, int ExerciseId)>
            {
                (1, 1), (1, 2),
                (2, 2), (2, 3),
                (3, 4), (3, 5),
                (4, 1), (4, 3),
                (5, 4), (5, 5)
            };

            _exerciseRepo = new FakeExerciseRepo();
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

        public List<Workouts> GetFilteredWorkouts(int? level, bool includeLevel, int pageIndex, int pageSize)
        {
            List<Workouts> filteredWorkouts = new List<Workouts>();
            foreach (var workout in _workouts)
            {
                if (includeLevel && workout.GetWorkoutLevel() == (Level)level)
                {
                    filteredWorkouts.Add(workout);
                }
                else if (!includeLevel && workout.GetWorkoutLevel() != (Level)level)
                {
                    filteredWorkouts.Add(workout);
                }
            }

            List<Workouts> paginatedWorkouts = new List<Workouts>();
            int skipCount = (pageIndex - 1) * pageSize;
            for (int i = skipCount; i < skipCount + pageSize && i < filteredWorkouts.Count; i++)
            {
                paginatedWorkouts.Add(filteredWorkouts[i]);
            }

            return paginatedWorkouts;
        }

        public int GetFilteredWorkoutsCount(int? level, bool includeLevel)
        {
            int count = 0;
            foreach (var workout in _workouts)
            {
                if (includeLevel && workout.GetWorkoutLevel() == (Level)level)
                {
                    count++;
                }
                else if (!includeLevel && workout.GetWorkoutLevel() != (Level)level)
                {
                    count++;
                }
            }
            return count;
        }

        public List<Workouts> GetWorkoutsByPage(int pageIndex, int pageSize)
        {
            List<Workouts> paginatedWorkouts = new List<Workouts>();
            int skipCount = (pageIndex - 1) * pageSize;
            for (int i = skipCount; i < skipCount + pageSize && i < _workouts.Count; i++)
            {
                paginatedWorkouts.Add(_workouts[i]);
            }
            return paginatedWorkouts;
        }

        public List<Workouts> SearchWorkouts(string name, int? level = null)
        {
            List<Workouts> matchingWorkouts = new List<Workouts>();
            foreach (var workout in _workouts)
            {
                if (workout.GetName().IndexOf(name, StringComparison.OrdinalIgnoreCase) >= 0 &&
                    (!level.HasValue || workout.GetWorkoutLevel().Equals((Level)level.Value)))
                {
                    matchingWorkouts.Add(workout);
                }
            }
            return matchingWorkouts;
        }

        public int GetTotalWorkoutsCount()
        {
            return _workouts.Count;
        }

        public List<Workouts> GetTopRatedWorkouts(int n)
        {
            List<Workouts> topRatedWorkouts = new List<Workouts>();
            for (int i = 0; i < n && i < _workouts.Count; i++)
            {
                topRatedWorkouts.Add(_workouts[i]);
            }
            return topRatedWorkouts;
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

        public void RemoveExerciseFromWorkout(int workoutId, int exerciseId)
        {
            for (int i = 0; i < _workoutExercises.Count; i++)
            {
                if (_workoutExercises[i].WorkoutId == workoutId && _workoutExercises[i].ExerciseId == exerciseId)
                {
                    _workoutExercises.RemoveAt(i);
                    break;
                }
            }
        }
    }
}
