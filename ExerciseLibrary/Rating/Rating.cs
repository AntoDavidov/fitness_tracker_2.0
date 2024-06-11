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
        private Workouts workout;
        private Customer customer;
        private int ratingValue;

        public Rating(Workouts workoutID, Customer customerID, int ratingValue)
        {
            this.workout = workoutID;
            this.customer = customerID;
            this.ratingValue = ratingValue;
        }
        public Rating(int id, Workouts workoutId, Customer customerId, int ratingValue)
        {
            this.id = id;
            this.workout = workoutId;
            this.customer = customerId;
            this.ratingValue = ratingValue;
        }   

        public int GetRatingID()
        {
            return id;
        }

        public Workouts GetWorkout()
        {
            return workout;
        }

        public Customer GetCustomer()
        {
            return customer;
        }

        public int GetRatingValue()
        {
            return ratingValue;
        }
    }
}
