using ExerciseLibrary.Rating;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRepositories
{
    public interface ICalculateRating
    {
        double[] CalculateRating(List<Rating> ratings, int workoutId);
    }
}
