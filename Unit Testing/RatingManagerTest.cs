using ExerciseLibrary;
using ExerciseLibrary.Rating;
using ManagerLibrary;
using ManagerLibrary.Exceptions;
using ManagerLibrary.Strategy;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NameLibrary;
using System.Collections.Generic;
using Unit_Testing.FakeRepo;

namespace Unit_Testing.Tests
{
    [TestClass]
    public class RatingManagerTest
    {
        private FakeRatingRepo _fakeRatingRepo;
        private RatingManager _ratingManager;
        private RatingClient _ratingClient;
        private RatingCalculator _ratingCalculator;

        [TestInitialize]
        public void Setup()
        {
            _fakeRatingRepo = new FakeRatingRepo();
            _ratingManager = new RatingManager(_fakeRatingRepo);
            _ratingCalculator = new RatingCalculator();
            _ratingClient = new RatingClient(_ratingManager, _ratingCalculator);
        }

        [TestMethod]
        public void AddRating_ShouldAddRating_WhenRatingDoesNotExist()
        {
            // Arrange
            var workout = new Workouts(4, "Workout 4", "Description for Workout 4", Level.Beginner);
            var customer = new Customer(3, "Sam", "Smith", "samsmith", "password", "samsmith@example.com", 75, Level.Beginner, 30);
            var rating = new Rating(workout, customer, 5);

            // Act
            _ratingManager.AddRating(rating);
            var ratings = _fakeRatingRepo.GetRatingsByWorkoutId(workout.GetId());

            // Assert
            Assert.AreEqual(1, ratings.Count);
            Assert.AreEqual(5, ratings[0].GetRatingValue());
        }

        [TestMethod]
        [ExpectedException(typeof(RatingAlreadyExistsException))]
        public void AddRating_ShouldThrowException_WhenRatingAlreadyExists()
        {
            // Arrange
            var workout = new Workouts(1, "Workout 1", "Description for Workout 1", Level.Beginner);
            var customer = new Customer(1, "John", "Doe", "johndoe", "password", "johndoe@example.com", 70, Level.Beginner, 25);
            var rating = new Rating(workout, customer, 5);

            // Act
            _ratingManager.AddRating(rating);

            // Assert is handled by the ExpectedException attribute
        }

        [TestMethod]
        public void GetRatingsByWorkoutId_ShouldReturnRatings_ForGivenWorkoutId()
        {
            // Arrange
            var workoutId = 1;

            // Act
            var ratings = _ratingManager.GetRatingsByWorkoutId(workoutId);

            // Assert
            Assert.AreEqual(2, ratings.Count);
        }

        [TestMethod]
        public void GetRatingCount_ShouldReturnCorrectCount_ForGivenWorkoutId()
        {
            // Arrange
            var workoutId = 1;

            // Act
            var count = _ratingManager.GetRatingCount(workoutId);

            // Assert
            Assert.AreEqual(2, count);
        }

        [TestMethod]
        public void RatingClient_ShouldReturnAverageRating_ForGivenWorkoutId()
        {
            // Arrange
            var workoutId = 1;

            // Act
            _ratingClient.SetAverageRatingStrategy();
            var rating = _ratingClient.GetWorkoutRating(workoutId);

            // Assert
            Assert.AreEqual(4.5, rating[0], 0.1); // Expected average rating is 4.5
        }

        [TestMethod]
        public void RatingClient_ShouldReturnPercentageRating_ForGivenWorkoutId()
        {
            // Arrange
            var workoutId = 1;

            // Act
            _ratingClient.SetPercentageRatingStrategy();
            var ratingPercentages = _ratingClient.GetWorkoutRating(workoutId);

            // Assert
            Assert.AreEqual(0, ratingPercentages[0], 0.1);  // Percentage of 1-star ratings
            Assert.AreEqual(0, ratingPercentages[1], 0.1);  // Percentage of 2-star ratings
            Assert.AreEqual(0, ratingPercentages[2], 0.1);  // Percentage of 3-star ratings
            Assert.AreEqual(50, ratingPercentages[3], 0.1); // Percentage of 4-star ratings
            Assert.AreEqual(50, ratingPercentages[4], 0.1); // Percentage of 5-star ratings
        }
    }
}
