using IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExerciseLibrary.Rating;

namespace ManagerLibrary.ConcreteStrategyClasses
{
    public class PercantageRating : ICalculateRating
    {
        public double CalculateRating(List<Rating> ratings, int workoutId)
        {
            if(ratings.Count == 0) 
            { 
                return 0;
            }

            int totalRating = 0;
            int highRatings = 0;

            foreach( var rating in ratings)
            {
                totalRating++;
                if(rating.GetRatingValue() >= 4)
                {
                    highRatings++;
                }
            }
            return (double)highRatings / totalRating * 100;



        }
    }
}
