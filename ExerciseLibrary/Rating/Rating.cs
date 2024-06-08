using NameLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExerciseLibrary.Rating
{
    public class Rating
    {
        private int id;
        private int workoutId;
        private int customerId;
        private int ratingValue;

        public Rating(int workoutID, int customerID, int ratingValue)
        {
            this.workoutId = workoutID;
            this.customerId = customerID;
            this.ratingValue = ratingValue;
        }
        public Rating(int id, int workoutId, int customerId, int ratingValue)
        {
            this.id = id;
            this.workoutId = workoutId;
            this.customerId = customerId;
            this.ratingValue = ratingValue;
        }   

        public int GetRatingID()
        {
            return id;
        }

        public int GetWorkoutID()
        {
            return workoutId;
        }

        public int GetCustomerID()
        {
            return customerId;
        }

        public int GetRatingValue()
        {
            return ratingValue;
        }
    }
}
