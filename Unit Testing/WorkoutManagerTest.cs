using Microsoft.VisualStudio.TestTools.UnitTesting;
using ManagerLibrary;
using NameLibrary;
using ExerciseLibrary;
using Unit_Testing.FakeRepo;
using System.Collections.Generic;

namespace Unit_Testing.Tests
{
    [TestClass]
    public class WorkoutManagerTests
    {
        private FakeWorkoutRepo _fakeWorkoutRepo;
        private WorkoutManager _workoutManager;

        [TestInitialize]
        public void Setup()
        {
            _fakeWorkoutRepo = new FakeWorkoutRepo();
            _workoutManager = new WorkoutManager(_fakeWorkoutRepo);
        }

        [TestMethod]
        public void AddWorkoutWithoutExercises_ShouldAddWorkout()
        {
            // Arrange
            var newWorkout = new Workouts(6, "New Workout", "Description for New Workout", Level.Beginner);

            // Act
            var result = _workoutManager.AddWorkoutWithoutExercises(newWorkout);

            // Assert
            Assert.IsTrue(result);
            Assert.IsNotNull(_fakeWorkoutRepo.GetWorkoutById(6));
        }

        [TestMethod]
        public void GetWorkoutById_ShouldReturnWorkout_WhenWorkoutExists()
        {
            // Arrange
            var workoutId = 1;

            // Act
            var result = _workoutManager.GetWorkoutById(workoutId);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("Workout 1", result.GetName());
        }

        [TestMethod]
        public void GetWorkoutById_ShouldReturnNull_WhenWorkoutDoesNotExist()
        {
            // Arrange
            var workoutId = 999;

            // Act
            var result = _workoutManager.GetWorkoutById(workoutId);

            // Assert
            Assert.IsNull(result);
        }

        [TestMethod]
        public void GetTopRatedWorkouts_ShouldReturnTopNWorkouts()
        {
            // Act
            var result = _workoutManager.GetTopRatedWorkouts(3);

            // Assert
            Assert.AreEqual(3, result.Count);
        }

        [TestMethod]
        public void GetFilteredWorkouts_ShouldReturnFilteredWorkouts()
        {
            // Act
            var result = _workoutManager.GetFilteredWorkouts((int)Level.Beginner, true, 1, 2);

            // Assert
            Assert.AreEqual(1, result.Count);
            Assert.AreEqual("Workout 1", result[0].GetName());
        }

        [TestMethod]
        public void SearchWorkouts_ShouldReturnMatchingWorkouts()
        {
            // Act
            var result = _workoutManager.SearchWorkouts("Workout 2", (int)Level.Intermediate);

            // Assert
            Assert.AreEqual(1, result.Count);
            Assert.AreEqual("Workout 2", result[0].GetName());
        }

        [TestMethod]
        public void GetFilteredWorkoutsCount_ShouldReturnCorrectCount()
        {
            // Act
            var result = _workoutManager.GetFilteredWorkoutsCount((int)Level.Intermediate, true);

            // Assert
            Assert.AreEqual(2, result);
        }

        [TestMethod]
        public void AddExerciseToWorkout_ShouldAddExercise()
        {
            // Arrange
            var workout = _workoutManager.GetWorkoutById(1);
            var exercise = new Strength(6, "New Strength", "Description", MuscleGroup.Chest, 10, 3, 100);

            // Act
            _workoutManager.AddExerciseToWorkout(workout, exercise);

            // Assert
            var exercises = _workoutManager.GetCurrentWorkoutExercises(workout);
            Assert.AreEqual(3, exercises.Count);
            Assert.IsNotNull(_fakeWorkoutRepo.GetExercisesForWorkout(1).Find(e => e.GetId() == 6));
        }

        [TestMethod]
        public void ExerciseExistsInWorkout_ShouldReturnTrue_WhenExerciseExists()
        {
            // Arrange
            var workout = _workoutManager.GetWorkoutById(1);
            var exercise = _fakeWorkoutRepo.GetExercisesForWorkout(1)[0];

            // Act
            var result = _workoutManager.ExerciseExistsInWorkout(workout, exercise);

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void ExerciseExistsInWorkout_ShouldReturnFalse_WhenExerciseDoesNotExist()
        {
            // Arrange
            var workout = _workoutManager.GetWorkoutById(1);
            var exercise = new Strength(999, "Non-existing Exercise", "Description", MuscleGroup.Chest, 10, 3, 100);

            // Act
            var result = _workoutManager.ExerciseExistsInWorkout(workout, exercise);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void DeleteWorkout_ShouldRemoveWorkoutAndItsExercises()
        {
            // Arrange
            var workout = _workoutManager.GetWorkoutById(1);

            // Act
            _workoutManager.DeleteWorkout(workout);

            // Assert
            Assert.IsNull(_fakeWorkoutRepo.GetWorkoutById(1));
            Assert.AreEqual(0, _fakeWorkoutRepo.GetExercisesForWorkout(1).Count);
        }

        [TestMethod]
        public void RemoveExerciseFromWorkout_ShouldRemoveExercise()
        {
            // Arrange
            var workout = _workoutManager.GetWorkoutById(1);
            var exercise = _fakeWorkoutRepo.GetExercisesForWorkout(1)[0];

            // Act
            _workoutManager.RemoveExerciseFromWorkout(workout, exercise);

            // Assert
            Assert.IsNull(_fakeWorkoutRepo.GetExercisesForWorkout(1).Find(e => e.GetId() == exercise.GetId()));
        }
    }
}
