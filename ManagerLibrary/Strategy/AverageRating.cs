using IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExerciseLibrary.Rating;

namespace ManagerLibrary.ConcreteStrategyClasses
{
    public class AverageRating : ICalculateRating
    {
        public double CalculateRating(List<Rating> ratings, int workoutId)
        {
            if (ratings.Count == 0)
            {
                return 0;
            }

            int totalRating = 0;
            int count = 0;

            foreach (var rating in ratings)
            {
                totalRating += rating.GetRatingValue();
                count++;
            }

            return (double)totalRating / count;
        }
    }
}
