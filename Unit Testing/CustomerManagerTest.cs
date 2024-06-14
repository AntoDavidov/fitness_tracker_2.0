using Microsoft.VisualStudio.TestTools.UnitTesting;
using ManagerLibrary;
using NameLibrary;
using ManagerLibrary.Exceptions;
using IRepositories;
using Unit_Testing.FakeRepo;
using System.Collections.Generic;
using System.Linq;

namespace Unit_Testing.Tests
{
    [TestClass]
    public class CustomerManagerTests
    {
        private ICustomerRepo _fakeCustomerRepository;
        private CustomerManager _customerManager;

        [TestInitialize]
        public void Setup()
        {
            _fakeCustomerRepository = new FakeCustomerRepo();
            _customerManager = new CustomerManager(_fakeCustomerRepository);
        }

        [TestMethod]
        public void VerifyCustomerCredentials_ShouldReturnCustomer_ForValidCredentials()
        {
            // Arrange
            var email = "1customer1@example.com";
            var password = "password";

            // Act
            Customer result = _customerManager.VerifyCustomerCredentials(email, password);

            // Assert
            Assert.IsNotNull(result); 
            Assert.AreEqual(email, result.GetEmail()); 
        }

        [TestMethod]
        public void VerifyCustomerCredentials_ShouldReturnNull_ForInvalidCredentials()
        {
            // Arrange
            var email = "nonExistingEmail@example.com";
            var password = "invalidPassword";

            // Act
            Customer result = _customerManager.VerifyCustomerCredentials(email, password);

            // Assert
            Assert.IsNull(result);
        }

        [TestMethod]
        [ExpectedException(typeof(DuplicateUsernameException))]
        public void AddCustomer_ShouldThrowDuplicateUsernameException_WhenUsernameAlreadyExists()
        {
            // Arrange
            var existingCustomer = new Customer(3, "John", "Doe", "customer1", "password", "email@example.com", 70, Level.Beginner); // BEGINNER = 1
            _customerManager.AddCustomer(existingCustomer.GetFirstName(), existingCustomer.GetLastName(), existingCustomer.GetUsername(), existingCustomer.GetPassword(), existingCustomer.GetEmail(), existingCustomer.GetWeight(), existingCustomer.GetLevel(), existingCustomer.GetAge());

            // Act
            _customerManager.AddCustomer("Jane", "Smith", "customer1", "password", "newemail@example.com", 65, Level.Intermediate, 20); // INTERMEDIATE = 2

            // Assert
            // Expecting a DuplicateUsernameException
        }

        [TestMethod]
        [ExpectedException(typeof(DuplicateEmailException))]
        public void AddCustomer_ShouldThrowDuplicateEmailException_WhenEmailAlreadyExists()
        {
            // Arrange
            var existingCustomer = new Customer(5, "John", "Doe", "user1", "password", "samecustomer@example.com", 70, Level.Beginner); // BEGINNER = 1
            _customerManager.AddCustomer(existingCustomer.GetFirstName(), existingCustomer.GetLastName(), existingCustomer.GetUsername(), existingCustomer.GetPassword(), existingCustomer.GetEmail(), existingCustomer.GetWeight(), existingCustomer.GetLevel(), existingCustomer.GetAge());

            // Act
            _customerManager.AddCustomer("Jane", "Smith", "newUser", "password", "samecustomer@example.com", 65, Level.Intermediate, 23); // INTERMEDIATE = 2

            // Assert
            // Expecting a DuplicateEmailException
        }

        [TestMethod]
        public void AddCustomer_ShouldAddCustomer_WhenUsernameAndEmailAreUnique()
        {
            // Arrange
            var newCustomer = new Customer(7, "John", "Doe", "uniqueUser", "password", "unique@example.com", 70, Level.Beginner); // BEGINNER = 1

            // Act
            _customerManager.AddCustomer(newCustomer.GetFirstName(), newCustomer.GetLastName(), newCustomer.GetUsername(), newCustomer.GetPassword(), newCustomer.GetEmail(), newCustomer.GetWeight(), newCustomer.GetLevel(), newCustomer.GetAge());
            var addedCustomer = _fakeCustomerRepository.GetAllCustomers().FirstOrDefault(c => c.GetUsername() == "uniqueUser");

            // Assert
            Assert.IsNotNull(addedCustomer);
            Assert.AreEqual(newCustomer.GetFirstName(), addedCustomer.GetFirstName());
        }

        [TestMethod]
        public void AddWorkoutToFavourites_ShouldReturnTrue_WhenWorkoutIsAdded()
        {
            // Arrange
            var customerId = _fakeCustomerRepository.GetCustomerIdByEmail("customer1@example.com");
            var workoutId = 1;

            // Act
            var result = _customerManager.AddWorkoutToFavourites(customerId, workoutId);

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void AddWorkoutToFavourites_ShouldReturnFalse_WhenWorkoutAlreadyInFavourites()
        {
            // Arrange
            var customerId = _fakeCustomerRepository.GetCustomerIdByEmail("customer1@example.com");
            var workoutId = 1;

            _customerManager.AddWorkoutToFavourites(customerId, workoutId);

            // Act
            var result = _customerManager.AddWorkoutToFavourites(customerId, workoutId);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void GetCustomerIdByEmail_ShouldReturnCustomerId_WhenEmailExists()
        {
            // Arrange
            var email = "1customer1@example.com";

            // Act
            var result = _customerManager.GetCustomerIdByEmail(email);

            // Assert
            Assert.AreEqual(1, result);
        }

        [TestMethod]
        public void GetCustomerIdByEmail_ShouldReturnMinusOne_WhenEmailDoesNotExist()
        {
            // Arrange
            var email = "nonExistingEmail@example.com";

            // Act
            var result = _customerManager.GetCustomerIdByEmail(email);

            // Assert
            Assert.AreEqual(-1, result);
        }

        [TestMethod]
        public void GetAllCustomers_ShouldReturnAllCustomers()
        {
            // Act
            var result = _customerManager.GetAllCustomers();

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.Count); 
        }
        [TestMethod]
        public void RemoveWorkoutFromFavourites_ShouldReturnTrue_WhenWorkoutIsRemoved()
        {
            // Arrange
            var customerId = _fakeCustomerRepository.GetCustomerIdByEmail("1customer1@example.com");
            var workoutId = 1;

            // Act
            var result = _customerManager.RemoveWorkoutFromFavourites(customerId, workoutId);

            // Assert
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void RemoveWorkoutFromFavourites_ShouldReturnFalse_WhenWorkoutIsNotInFavourites()
        {
            // Arrange
            var customerId = _fakeCustomerRepository.GetCustomerIdByEmail("1customer1@example.com");
            var workoutId = 99; 

            // Act
            var result = _customerManager.RemoveWorkoutFromFavourites(customerId, workoutId);

            // Assert
            Assert.IsFalse(result);
        }
        [TestMethod]
        public void GetCustomerById_ShouldReturnCustomer_WhenIdExists()
        {
            // Arrange
            var customerId = 1;

            // Act
            var result = _customerManager.GetCustomerById(customerId);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(customerId, result.GetId());
        }
        [TestMethod]
        public void GetCustomerById_ShouldReturnNull_WhenIdDoesNotExist()
        {
            // Arrange
            var customerId = 99; 

            // Act
            var result = _customerManager.GetCustomerById(customerId);

            // Assert
            Assert.IsNull(result);
        }
        [TestMethod]
        public void GetFavoriteWorkoutsByPage_ShouldReturnPagedWorkouts_WhenCustomerIdExists()
        {
            // Arrange
            var customerId = _fakeCustomerRepository.GetCustomerIdByEmail("1customer1@example.com");
            var pageIndex = 1;
            var pageSize = 2;

            // Act
            var result = _customerManager.GetFavoriteWorkoutsByPage(customerId, pageIndex, pageSize);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.Count); 
        }
        [TestMethod]
        public void GetFavoriteWorkoutsByPage_ShouldReturnEmptyList_WhenCustomerIdDoesNotExist()
        {
            // Arrange
            var customerId = 99; 
            var pageIndex = 1;
            var pageSize = 2;

            // Act
            var result = _customerManager.GetFavoriteWorkoutsByPage(customerId, pageIndex, pageSize);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(0, result.Count);
        }
        [TestMethod]
        public void GetTotalFavoriteWorkoutsCount_ShouldReturnCount_WhenCustomerIdExists()
        {
            // Arrange
            var customerId = _fakeCustomerRepository.GetCustomerIdByEmail("1customer1@example.com");

            // Act
            var result = _customerManager.GetTotalFavoriteWorkoutsCount(customerId);

            // Assert
            Assert.AreEqual(3, result); 
        }
        [TestMethod]
        public void GetFavoriteWorkouts_ShouldReturnFavoriteWorkouts_WhenCustomerIdExists()
        {
            // Arrange
            var customerId = _fakeCustomerRepository.GetCustomerIdByEmail("1customer1@example.com");

            // Act
            var result = _customerManager.GetFavoriteWorkouts(customerId);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(3, result.Count); 
        }







    }
}
