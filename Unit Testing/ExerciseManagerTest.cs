using Microsoft.VisualStudio.TestTools.UnitTesting;
using ManagerLibrary;
using ExerciseLibrary;
using Unit_Testing.FakeRepo;
using IRepositories;
using System.Collections.Generic;

namespace Unit_Testing.Tests
{
    [TestClass]
    public class ExerciseManagerTests
    {
        private IExerciseRepo _fakeExerciseRepo;
        private ExerciseManager _exerciseManager;

        [TestInitialize]
        public void Setup()
        {
            _fakeExerciseRepo = new FakeExerciseRepo();
            _exerciseManager = new ExerciseManager(_fakeExerciseRepo);
        }

        [TestMethod]
        public void AddExercise_ShouldAddStrengthExercise()
        {
            // Arrange
            var strengthExercise = new Strength(8, "Lunges", "Lunges exercise", MuscleGroup.Legs, 12, 3, 50);

            // Act
            _exerciseManager.AddExercise(strengthExercise);

            // Assert
            var addedExercise = _exerciseManager.GetExerciseById(8);
            Assert.IsNotNull(addedExercise);
            Assert.IsInstanceOfType(addedExercise, typeof(Strength));
            Assert.AreEqual("Lunges", addedExercise.GetName());
        }

        [TestMethod]
        public void AddExercise_ShouldAddCardioExercise()
        {
            // Arrange
            var cardioExercise = new Cardio(9, "Swimming", "Swimming exercise", TimeSpan.FromMinutes(30));

            // Act
            _exerciseManager.AddExercise(cardioExercise);

            // Assert
            var addedExercise = _exerciseManager.GetExerciseById(9);
            Assert.IsNotNull(addedExercise);
            Assert.IsInstanceOfType(addedExercise, typeof(Cardio));
            Assert.AreEqual("Swimming", addedExercise.GetName());
        }


        [TestMethod]
        public void SearchExercisesByName_ShouldReturnMatchingExercises()
        {
            // Arrange
            var name = "Push";

            // Act
            var exercises = _exerciseManager.SearchExercisesByName(name);

            // Assert
            Assert.IsNotNull(exercises);
            Assert.AreEqual(1, exercises.Count);
            Assert.AreEqual("Push Up", exercises[0].GetName());
        }

        [TestMethod]
        public void SearchExercisesByTypeAndName_ShouldReturnMatchingStrengthExercises()
        {
            // Arrange
            var type = "Strength";
            var name = "Press";

            // Act
            var exercises = _exerciseManager.SearchExercisesByTypeAndName(type, name);

            // Assert
            Assert.IsNotNull(exercises);
            Assert.AreEqual(1, exercises.Count);
            Assert.AreEqual("Bench Press", exercises[0].GetName());
        }

        [TestMethod]
        public void SearchExercisesByTypeAndName_ShouldReturnMatchingCardioExercises()
        {
            // Arrange
            var type = "Cardio";
            var name = "Running";

            // Act
            var exercises = _exerciseManager.SearchExercisesByTypeAndName(type, name);

            // Assert
            Assert.IsNotNull(exercises);
            Assert.AreEqual(1, exercises.Count);
            Assert.AreEqual("Running", exercises[0].GetName());
        }

        [TestMethod]
        public void GetExerciseById_ShouldReturnExercise()
        {
            // Act
            var exercise = _exerciseManager.GetExerciseById(1);

            // Assert
            Assert.IsNotNull(exercise);
            Assert.AreEqual("Push Up", exercise.GetName());
        }

        [TestMethod]
        public void DeleteExercise_ShouldRemoveStrengthExercise()
        {
            // Arrange
            var strengthExercise = new Strength(5, "Bicep Curl", "Dumbbell bicep curls", MuscleGroup.Bicep, 15, 3, 20);

            // Act
            _exerciseManager.DeleteExercise(strengthExercise);

            // Assert
            var deletedExercise = _exerciseManager.GetExerciseById(5);
            Assert.IsNull(deletedExercise);
        }

        [TestMethod]
        public void DeleteExercise_ShouldRemoveCardioExercise()
        {
            // Arrange
            var cardioExercise = new Cardio(6, "Running", "Running on treadmill", TimeSpan.FromMinutes(30));

            // Act
            _exerciseManager.DeleteExercise(cardioExercise);

            // Assert
            var deletedExercise = _exerciseManager.GetExerciseById(6);
            Assert.IsNull(deletedExercise);
        }
    }
}
