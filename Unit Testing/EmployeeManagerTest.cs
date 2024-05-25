using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ManagerLibrary;
using DBLibrary.IRepositories;
using NameLibrary;
using System.Collections.Generic;

namespace YourProject.Tests
{
    [TestClass]
    public class EmployeeManagerTests
    {
        private Mock<IEmployeeRepository> _mockEmployeeRepository;
        private EmployeeManager _employeeManager;
        private PasswordManager _passwordManager;

        [TestInitialize]
        public void Setup()
        {
            _mockEmployeeRepository = new Mock<IEmployeeRepository>();
            _passwordManager = new PasswordManager();
            _employeeManager = new EmployeeManager(_mockEmployeeRepository.Object);
        }

        [TestMethod]
        public void VerifyEmployeeCredentials_ShouldReturnTrue_ForValidCredentials()
        {
            // Arrange
            var email = "validUser@example.com";
            var password = "validPassword";
            var hashedPassword = _passwordManager.HashPassword(password);
            _mockEmployeeRepository.Setup(repo => repo.VerifyEmployeeCredentials(email, hashedPassword)).Returns(true);

            // Act
            var result = _employeeManager.VerifyEmployeeCredentials(email, password);

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void VerifyEmployeeCredentials_ShouldReturnFalse_ForInvalidCredentials()
        {
            // Arrange
            var email = "invalidUser@example.com";
            var password = "invalidPassword";
            var hashedPassword = _passwordManager.HashPassword(password);
            _mockEmployeeRepository.Setup(repo => repo.VerifyEmployeeCredentials(email, hashedPassword)).Returns(false);

            // Act
            var result = _employeeManager.VerifyEmployeeCredentials(email, password);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void GetEmployeeByUsername_ShouldReturnEmployee_WhenEmployeeExists()
        {
            // Arrange
            var username = "existingUser";
            var expectedEmployee = new Employee("First", "Last", username, "password", "email@example.com", "role");
            _mockEmployeeRepository.Setup(repo => repo.GetEmployeeByUsername(username)).Returns(expectedEmployee);

            // Act
            var result = _employeeManager.GetEmployeeByUsername(username);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(expectedEmployee, result);
        }

        [TestMethod]
        public void GetEmployeeByUsername_ShouldReturnNull_WhenEmployeeDoesNotExist()
        {
            // Arrange
            var username = "nonExistingUser";
            _mockEmployeeRepository.Setup(repo => repo.GetEmployeeByUsername(username)).Returns((Employee)null);

            // Act
            var result = _employeeManager.GetEmployeeByUsername(username);

            // Assert
            Assert.IsNull(result);
        }

        [TestMethod]
        public void AddEmployee_ShouldInvokeRepositoryAddMethod()
        {
            // Arrange
            var newEmployee = new Employee("First", "Last", "newUser", "password", "email@example.com", "role");
            var hashedPassword = _passwordManager.HashPassword(newEmployee.GetPassword());

            // Act
            _employeeManager.AddEmployee(newEmployee);

            // Assert
            _mockEmployeeRepository.Verify(repo => repo.AddEmployee(
                newEmployee.GetFirstName(),
                newEmployee.GetLastName(),
                newEmployee.GetUsername(),
                hashedPassword,
                newEmployee.GetEmail(),
                newEmployee.Role()
            ), Moq.Times.Once);
        }

        [TestMethod]
        public void DeleteEmployee_ShouldInvokeRepositoryDeleteMethod()
        {
            // Arrange
            var employeeId = 1;

            // Act
            _employeeManager.DeleteEmployee(employeeId);

            // Assert
            _mockEmployeeRepository.Verify(repo => repo.DeleteEmployee(employeeId), Moq.Times.Once);
        }

    }
}
