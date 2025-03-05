using System;

namespace ManagerLibrary.Exceptions
{
    public class RatingAlreadyExistsException : Exception
    {
        public RatingAlreadyExistsException(int workoutId, int customerId)
            : base($"You have already rated workout {workoutId}.")
        {
        }
    }
}
