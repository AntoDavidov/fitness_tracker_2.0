using IRepositories;
using ManagerLibrary.ConcreteStrategyClasses;
using ManagerLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unit_Testing.FakeRepo;

namespace Unit_Testing
{
    [TestClass]
    public class RatingManagerTests
    {
        private IRatingRepo _fakeRatingRepo;
        private RatingManager _ratingManager;

        [TestInitialize]
        public void Setup()
        {
            _fakeRatingRepo = new FakeRatingRepo();
            _ratingManager = new RatingManager(_fakeRatingRepo);
        }

        [TestMethod]
        public void AddRating_ShouldAddRating()
        {
            // Arrange
            int workoutId = 1;
            int customerId = 1;
            int ratingValue = 5;

            // Act
            _ratingManager.AddRating(workoutId, customerId, ratingValue);

            // Assert
            var ratings = _fakeRatingRepo.GetRatingsByWorkoutId(workoutId);
            Assert.AreEqual(1, ratings.Count);
            Assert.AreEqual(ratingValue, ratings[0].GetRatingValue());
        }

        [TestMethod]
        public void CalculateAverageRating_ShouldReturnCorrectAverage()
        {
            // Arrange
            int workoutId = 1;
            _ratingManager.AddRating(workoutId, 1, 5);
            _ratingManager.AddRating(workoutId, 2, 3);

            _ratingManager.SetRatingsStrategy(new AverageRating(_fakeRatingRepo));

            // Act
            double averageRating = _ratingManager.GetCalculatedRatings(workoutId);

            // Assert
            Assert.AreEqual(4.0, averageRating);
        }

        [TestMethod]
        public void CalculatePercentageRating_ShouldReturnCorrectPercentage()
        {
            // Arrange
            int workoutId = 1;
            _ratingManager.AddRating(workoutId, 1, 5);
            _ratingManager.AddRating(workoutId, 2, 3);
            _ratingManager.AddRating(workoutId, 3, 4);

            _ratingManager.SetRatingsStrategy(new PercantageRating(_fakeRatingRepo));

            // Act
            double percentageRating = _ratingManager.GetCalculatedRatings(workoutId);

            // Assert
            Assert.AreEqual(66.67, percentageRating, 0.01);
        }
        [TestMethod]
        public void AddRating_ShouldIncreaseRatingCount()
        {
            // Arrange
            int workoutId = 1;
            int customerId = 1;
            int ratingValue = 5;

            // Act
            _ratingManager.AddRating(workoutId, customerId, ratingValue);
            int count = _ratingManager.GetRatingCount(workoutId);

            // Assert
            Assert.AreEqual(1, count);
        }

        [TestMethod]
        public void GetRatingCount_ShouldReturnCorrectCount()
        {
            // Arrange
            int workoutId = 1;
            int customerId1 = 1;
            int customerId2 = 2;
            int ratingValue1 = 4;
            int ratingValue2 = 5;

            // Act
            _ratingManager.AddRating(workoutId, customerId1, ratingValue1);
            _ratingManager.AddRating(workoutId, customerId2, ratingValue2);
            int count = _ratingManager.GetRatingCount(workoutId);

            // Assert
            Assert.AreEqual(2, count);
        }

        [TestMethod]
        public void GetRatingCount_ShouldReturnZeroForNoRatings()
        {
            // Arrange
            int workoutId = 1;

            // Act
            int count = _ratingManager.GetRatingCount(workoutId);

            // Assert
            Assert.AreEqual(0, count);
        }
    }
}
