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
            _workouts.RemoveAll(w => w.GetId() == workoutId);
            _workoutExercises.RemoveAll(we => we.WorkoutId == workoutId);
        }
        public List<Exercise>? GetExercisesForWorkout(int workoutId)
        {
            var exerciseIds = _workoutExercises.Where(we => we.WorkoutId == workoutId).Select(we => we.ExerciseId).ToList();
            return exerciseIds.Select(_exerciseRepo.GetExerciseById).ToList();
        }
        public List<int> GetWorkoutIdsContainingExercise(int exerciseId)
        {
            return _workoutExercises.Where(we => we.ExerciseId == exerciseId).Select(we => we.WorkoutId).ToList();
        }
        public List<Workouts>? GetAllWorkouts()
        {
            return _workouts;
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
