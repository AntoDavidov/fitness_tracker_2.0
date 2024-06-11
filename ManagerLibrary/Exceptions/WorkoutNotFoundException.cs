using System;

namespace ManagerLibrary.Exceptions
{
    public class WorkoutNotFoundException : Exception
    {
        public WorkoutNotFoundException(int workoutId)
            : base($"Workout with ID {workoutId} not found.")
        {
        }
    }
}
