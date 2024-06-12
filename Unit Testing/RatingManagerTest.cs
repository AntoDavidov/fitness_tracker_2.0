using ExerciseLibrary;
using ExerciseLibrary.Rating;
using IRepositories;
using ManagerLibrary;
using ManagerLibrary.ConcreteStrategyClasses;
using ManagerLibrary.Strategy;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NameLibrary;
using System;
using System.Collections.Generic;
using Unit_Testing.FakeRepo;

namespace Unit_Testing.Tests
{
    //[TestClass]
    //public class RatingManagerTests
    //{
    //    private IRatingRepo _fakeRatingRepo;
    //    private RatingManager _ratingManager;
    //    private RatingClient _ratingClient;

    //    [TestInitialize]
    //    public void Setup()
    //    {
    //        _fakeRatingRepo = new FakeRatingRepo();
    //        _ratingManager = new RatingManager(_fakeRatingRepo);
    //        _ratingClient = new RatingClient(_ratingManager);
    //    }

    //    [TestMethod]
    //    public void AddRating_ShouldAddRating()
    //    {
    //        // Arrange
    //        Workouts workout = new Workouts(1, "Workout 1", "Description 1", "Beginner");
    //        Customer customer = new Customer(1, "John", "Doe", "john", "password", "john@example.com", 70, 1, 25);
    //        Rating rating = new Rating(workout, customer, 5);

    //        // Act
    //        _ratingManager.AddRating(rating);

    //        // Assert
    //        var ratings = _fakeRatingRepo.GetRatingsByWorkoutId(workout.GetId());
    //        Assert.AreEqual(1, ratings.Count);
    //        Assert.AreEqual(5, ratings[0].GetRatingValue());
    //    }

    //    [TestMethod]
    //    [ExpectedException(typeof(InvalidOperationException))]
    //    public void AddRating_ShouldThrowException_WhenRatingAlreadyExists()
    //    {
    //        // Arrange
    //        Workouts workout = new Workouts(1, "Workout 1", "Description 1", "Beginner");
    //        Customer customer = new Customer(1, "John", "Doe", "john", "password", "john@example.com", 70, 1, 25);
    //        Rating rating = new Rating(workout, customer, 4);

    //        // Act
    //        _ratingManager.AddRating(rating);

    //        // Adding the same rating again should throw an exception
    //        _ratingManager.AddRating(rating);
    //    }

    //    [TestMethod]
    //    public void AddRating_ShouldIncreaseRatingCount()
    //    {
    //        // Arrange
    //        Workouts workout = new Workouts(1, "Workout 1", "Description 1", "Beginner");
    //        Customer customer = new Customer(1, "John", "Doe", "john", "password", "john@example.com", 70, 1, 25);
    //        Rating rating = new Rating(workout, customer, 5);

    //        // Act
    //        _ratingManager.AddRating(rating);
    //        int count = _ratingManager.GetRatingCount(workout.GetId());

    //        // Assert
    //        Assert.AreEqual(1, count);
    //    }

    //    [TestMethod]
    //    public void GetRatingCount_ShouldReturnCorrectCount()
    //    {
    //        // Arrange
    //        Workouts workout = new Workouts(1, "Workout 1", "Description 1", "Beginner");
    //        Customer customer1 = new Customer(1, "John", "Doe", "john", "password", "john@example.com", 70, 1, 25);
    //        Customer customer2 = new Customer(2, "Jane", "Doe", "jane", "password", "jane@example.com", 65, 2, 30);
    //        Rating rating1 = new Rating(workout, customer1, 4);
    //        Rating rating2 = new Rating(workout, customer2, 5);

    //        // Act
    //        _ratingManager.AddRating(rating1);
    //        _ratingManager.AddRating(rating2);
    //        int count = _ratingManager.GetRatingCount(workout.GetId());

    //        // Assert
    //        Assert.AreEqual(2, count);
    //    }

    //    [TestMethod]
    //    public void GetRatingCount_ShouldReturnZeroForNoRatings()
    //    {
    //        // Arrange
    //        Workouts workout = new Workouts(1, "Workout 1", "Description 1", "Beginner");

    //        // Act
    //        int count = _ratingManager.GetRatingCount(workout.GetId());

    //        // Assert
    //        Assert.AreEqual(0, count);
    //    }

    //    [TestMethod]
    //    public void CalculateAverageRating_ShouldReturnCorrectAverage()
    //    {
    //        // Arrange
    //        Workouts workout = new Workouts(1, "Workout 1", "Description 1", "Beginner");
    //        Customer customer1 = new Customer(1, "John", "Doe", "john", "password", "john@example.com", 70, 1, 25);
    //        Customer customer2 = new Customer(2, "Jane", "Doe", "jane", "password", "jane@example.com", 65, 2, 30);
    //        _ratingManager.AddRating(new Rating(workout, customer1, 5));
    //        _ratingManager.AddRating(new Rating(workout, customer2, 3));

    //        .SetRatingStrategy(new AverageRating());

    //        // Act
    //        double averageRating = _ratingManager.GetCalculatedRating(workout.GetId());

    //        // Assert
    //        Assert.AreEqual(4.0, averageRating);
    //    }

    //    [TestMethod]
    //    public void CalculatePercentageRating_ShouldReturnCorrectPercentage()
    //    {
    //        // Arrange
    //        Workouts workout = new Workouts(1, "Workout 1", "Description 1", "Beginner");
    //        Customer customer1 = new Customer(1, "John", "Doe", "john", "password", "john@example.com", 70, 1, 25);
    //        Customer customer2 = new Customer(2, "Jane", "Doe", "jane", "password", "jane@example.com", 65, 2, 30);
    //        Customer customer3 = new Customer(3, "Bob", "Smith", "bob", "password", "bob@example.com", 80, 3, 35);
    //        _ratingManager.AddRating(new Rating(workout, customer1, 5));
    //        _ratingManager.AddRating(new Rating(workout, customer2, 3));
    //        _ratingManager.AddRating(new Rating(workout, customer3, 4));

    //        RatingClient rating = new RatingClient();
    //        rating.SetRatingStrategy(new PercantageRating());

    //        // Act
    //        double percentageRating = _ratingManager.(workout.GetId());

    //        // Assert
    //        Assert.AreEqual(66.67, percentageRating, 0.01);
    //    }
    //}
}
