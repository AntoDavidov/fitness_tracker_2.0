using ExerciseLibrary.Rating;
using IRepositories;

public class RatingManager
{
    private readonly IRatingRepo ratingRepo;
    private ICalculateRating calculator;

    public RatingManager(IRatingRepo ratingRepo)
    {
        this.ratingRepo = ratingRepo;
    }

    public void SetRatingsStrategy(ICalculateRating calculateRatingsStrategy)
    {
        this.calculator = calculateRatingsStrategy;
    }

    public double GetCalculatedRatings(int workoutId)
    {
        return calculator.CalculateRating(workoutId);
    }

    public void AddRating(int workoutId, int customerId, int ratingValue)
    {
        var rating = new Rating(workoutId, customerId, ratingValue);
        ratingRepo.AddRating(rating);
    }

    public IRatingRepo GetRatingRepo()
    {
        return ratingRepo;
    }
    public int GetRatingCount(int workoutId)
    {
        return ratingRepo.GetRatingCount(workoutId);
    }
}
