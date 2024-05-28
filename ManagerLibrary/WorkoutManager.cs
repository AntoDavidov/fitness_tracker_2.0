using ExerciseLibrary;
using IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagerLibrary
{
    public class WorkoutManager
    {
        private readonly IWorkoutRepo _workoutRepo;
        public WorkoutManager(IWorkoutRepo workoutRepo) 
        { 
            _workoutRepo = workoutRepo;
        }
        public bool AddWorkoutWithoutExercises(Workouts workout)
        {
            return _workoutRepo.AddWorkoutWithoutExercises(workout);
        }

        public Workouts? FindWorkout(Workouts workout)
        {
            return _workoutRepo.GetWorkout(workout);
        }

        public Workouts? GetWorkoutById(int workoutId)
        {
            return _workoutRepo.GetWorkoutById(workoutId);
        }

        public void AddExerciseToWorkout(Workouts workout, Exercise exercise)
        {
            _workoutRepo.AddExerciseToWorkout(workout.GetId(), exercise.GetId());
        }

        public List<Exercise> GetCurrentWorkoutExercises(Workouts workouts)
        {
            return _workoutRepo.GetExercisesForWorkout(workouts.GetId());
        }

        public bool ExerciseExistsInWorkout(Workouts workouts, Exercise exercise)
        {
            return _workoutRepo.ExerciseAlreadyExistsInWorkout(workouts.GetId(), exercise.GetId());
        }

        public List<Workouts> GetWorkouts()
        {
            return _workoutRepo.GetAllWorkouts();
        }
        public void DeleteWorkout(Workouts workouts)
        {
            _workoutRepo.DeleteWorkout(workouts.GetId());
        }

        public List<int> GetWorkoutIdsContainingExercise(int exerciseId)
        {
            return _workoutRepo.GetWorkoutIdsContainingExercise(exerciseId);
        }

    }
}
