using IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagerLibrary.ConcreteStrategyClasses
{
    public class AverageRating : ICalculateRating
    {
        private readonly IRatingRepo _ratingRepo;

        public AverageRating(IRatingRepo ratingRepo)
        {
            _ratingRepo = ratingRepo;
        }

        public double CalculateRating(int workoutId)
        {
            var ratings = _ratingRepo.GetRatingsByWorkoutId(workoutId);
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
