using Microsoft.VisualStudio.TestTools.UnitTesting;
using ManagerLibrary;
using DBLibrary.IRepositories;
using NameLibrary;
using DBLibrary.FakeRepositories;
using ManagerLibrary.Exceptions;

namespace YourProject.Tests
{
    [TestClass]
    public class EmployeeManagerTests
    {
        private IEmployeeRepository _fakeEmployeeRepository;
        private EmployeeManager _employeeManager;

        [TestInitialize]
        public void Setup()
        {
            _fakeEmployeeRepository = new FakeEmployeeRepository();
            _employeeManager = new EmployeeManager(_fakeEmployeeRepository);
        }

        [TestMethod]
        public void VerifyEmployeeCredentials_ShouldReturnTrue_ForValidCredentials()
        {
            // Arrange
            var username = "trainer";
            var password = "password";

            // Act
            var result = _employeeManager.VerifyEmployeeCredentials(username, password);

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void VerifyEmployeeCredentials_ShouldReturnFalse_ForInvalidCredentials()
        {
            // Arrange
            var username = "nonExistingUser";
            var password = "invalidPassword";

            // Act
            var result = _employeeManager.VerifyEmployeeCredentials(username, password);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void GetEmployeeByUsername_ShouldReturnEmployee_WhenEmployeeExists()
        {
            // Arrange
            var username = "trainer";
            var expectedEmployee = _fakeEmployeeRepository.GetEmployeeByUsername(username);

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

            // Act
            var result = _employeeManager.GetEmployeeByUsername(username);

            // Assert
            Assert.IsNull(result);
        }

        [TestMethod]
        [ExpectedException(typeof(DuplicateUsernameException))]
        public void AddEmployee_ShouldThrowDuplicateUsernameException_WhenUsernameAlreadyExists()
        {
            // Arrange
            var existingEmployee = new Employee("John", "Doe", "existingUser", "password", "email@example.com", "role");
            _employeeManager.AddEmployee(existingEmployee);
            var newEmployeeWithSameUsername = new Employee("Jane", "Smith", "existingUser", "password", "newemail@example.com", "role");

            // Act
            _employeeManager.AddEmployee(newEmployeeWithSameUsername);

            // Assert
            // Expecting a DuplicateUsernameException
        }

        [TestMethod]
        [ExpectedException(typeof(DuplicateEmailException))]
        public void AddEmployee_ShouldThrowDuplicateEmailException_WhenEmailAlreadyExists()
        {
            // Arrange
            var existingEmployee = new Employee("John", "Doe", "user1", "password", "existing@example.com", "role");
            _employeeManager.AddEmployee(existingEmployee);
            var newEmployeeWithSameEmail = new Employee("Jane", "Smith", "newUser", "password", "existing@example.com", "role");

            // Act
            _employeeManager.AddEmployee(newEmployeeWithSameEmail);

            // Assert
            // Expecting a DuplicateEmailException
        }

        [TestMethod]
        public void AddEmployee_ShouldAddEmployee_WhenUsernameAndEmailAreUnique()
        {
            // Arrange
            var newEmployee = new Employee("John", "Doe", "uniqueUser", "password", "unique@example.com", "role");

            // Act
            _employeeManager.AddEmployee(newEmployee);
            var addedEmployee = _fakeEmployeeRepository.GetEmployeeByUsername("uniqueUser");

            // Assert
            Assert.IsNotNull(addedEmployee);
            Assert.AreEqual(newEmployee.GetFirstName(), addedEmployee.GetFirstName());
        }


        [TestMethod]
        public void DeleteEmployee_ShouldRemoveEmployeeFromRepository()
        {
            // Arrange
            var existingEmployee = _fakeEmployeeRepository.GetAllEmployees().First();

            // Act
            _employeeManager.DeleteEmployee(existingEmployee.GetId());
            var deletedEmployee = _fakeEmployeeRepository.GetEmployeeByUsername(existingEmployee.GetUsername());

            // Assert
            Assert.IsNull(deletedEmployee);
        }
    }
}
