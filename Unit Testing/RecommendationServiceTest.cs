using Microsoft.VisualStudio.TestTools.UnitTesting;
using ManagerLibrary;
using NameLibrary;
using IRepositories;
using Unit_Testing.FakeRepo;
using System.Collections.Generic;
using ExerciseLibrary;

namespace Unit_Testing.Tests
{
    [TestClass]
    public class RecommendationServiceTests
    {
        private ICustomerRepo _fakeCustomerRepository;
        private RecommendationService _recommendationService;

        [TestInitialize]
        public void Setup()
        {
            _fakeCustomerRepository = new FakeCustomerRepo();
            _recommendationService = new RecommendationService(_fakeCustomerRepository);
        }

        [TestMethod]
        public void GetRecommendedWorkouts_ShouldReturnCorrectRecommendations()
        {
            // Arrange
            int customerId = 1; 

            // Act
            List<Workouts> recommendations = _recommendationService.GetRecommendedWorkouts(customerId);

            // Assert
            // For example, if customer 1 has workouts 1, 2, 3 and customer 2 has workouts 1, 5, 6,
            // we expect customer 1 to be recommended workouts 5 and 6.
            var expectedWorkoutNames = new List<string> { "Workout 5", "Workout 6" };
            foreach (var workout in recommendations)
            {
                Assert.IsTrue(expectedWorkoutNames.Contains(workout.GetName()));
            }
        }
    }
}
