using Microsoft.VisualStudio.TestTools.UnitTesting;
using ManagerLibrary;
using NameLibrary;
using ManagerLibrary.Exceptions;
using IRepositories;
using Unit_Testing.FakeRepo;

namespace Unit_Testing.Tests
{
    [TestClass]
    public class EmployeeManagerTests
    {
        private IEmployeeRepo _fakeEmployeeRepository;
        private EmployeeManager _employeeManager;

        [TestInitialize]
        public void Setup()
        {
            _fakeEmployeeRepository = new FakeEmployeeRepo();
            _employeeManager = new EmployeeManager(_fakeEmployeeRepository);
        }

        [TestMethod]
        public void VerifyEmployeeCredentials_ShouldReturnEmployee_ForValidCredentials()
        {
            // Arrange
            var username = "trainer";
            var password = "password";

            // Act
            Employee result = _employeeManager.VerifyEmployeeCredentials(username, password);

            // Assert
            Assert.IsNotNull(result); // Ensure that the result is not null
            Assert.AreEqual(username, result.GetUsername()); // Ensure that the returned employee has the correct username
        }

        [TestMethod]
        public void VerifyEmployeeCredentials_ShouldReturnNull_ForInvalidCredentials()
        {
            // Arrange
            var username = "nonExistingUser";
            var password = "invalidPassword";

            // Act
            Employee result = _employeeManager.VerifyEmployeeCredentials(username, password);

            // Assert
            Assert.IsNull(result);
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
            var existingEmployee = new Employee(1, "John", "Doe", "existingUser", "password", "email@example.com", 1);
            _employeeManager.AddEmployee(existingEmployee);
            var newEmployeeWithSameUsername = new Employee(2, "Jane", "Smith", "existingUser", "password", "newemail@example.com", 1);

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
            var existingEmployee = new Employee(1, "John", "Doe", "user1", "password", "existing@example.com", 1);
            _employeeManager.AddEmployee(existingEmployee);
            var newEmployeeWithSameEmail = new Employee(2, "Jane", "Smith", "newUser", "password", "existing@example.com", 1);

            // Act
            _employeeManager.AddEmployee(newEmployeeWithSameEmail);

            // Assert
            // Expecting a DuplicateEmailException
        }

        [TestMethod]
        public void AddEmployee_ShouldAddEmployee_WhenUsernameAndEmailAreUnique()
        {
            // Arrange
            var newEmployee = new Employee(3, "John", "Doe", "uniqueUser", "password", "unique@example.com", 1);

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

        [TestMethod]
        [ExpectedException(typeof(DuplicateUsernameException))]
        public void UpdateEmployeeInfo_ShouldThrowDuplicateUsernameException_WhenUsernameAlreadyExists()
        {
            // Arrange
            var existingEmployee = new Employee(1, "John", "Doe", "existingUser", "password", "email@example.com", 1);
            _employeeManager.AddEmployee(existingEmployee);
            var anotherEmployee = new Employee(2, "Jane", "Smith", "anotherUser", "password", "another@example.com", 1);
            _employeeManager.AddEmployee(anotherEmployee);

            // Act
            var updatedAnotherEmployee = new Employee(anotherEmployee.GetId(), anotherEmployee.GetFirstName(), anotherEmployee.GetLastName(), "existingUser", anotherEmployee.GetPassword(), anotherEmployee.GetEmail(), anotherEmployee.RoleId());
            _employeeManager.UpdateEmployeeInfo(updatedAnotherEmployee);

            // Assert
            // Expecting a DuplicateUsernameException
        }

        [TestMethod]
        [ExpectedException(typeof(DuplicateEmailException))]
        public void UpdateEmployeeInfo_ShouldThrowDuplicateEmailException_WhenEmailAlreadyExists()
        {
            // Arrange
            var existingEmployee = new Employee(3, "John", "Doe", "user1", "password", "existing@example.com", 1);
            _employeeManager.AddEmployee(existingEmployee);
            var anotherEmployee = new Employee(4, "Jane", "Smith", "newUser", "password", "another@example.com", 1);
            _employeeManager.AddEmployee(anotherEmployee);

            // Act
            var updatedAnotherEmployee = new Employee(anotherEmployee.GetId(), anotherEmployee.GetFirstName(), anotherEmployee.GetLastName(), anotherEmployee.GetUsername(), anotherEmployee.GetPassword(), "existing@example.com", anotherEmployee.RoleId());
            _employeeManager.UpdateEmployeeInfo(updatedAnotherEmployee);

            // Assert
            // Expecting a DuplicateEmailException
        }

        [TestMethod]
        public void UpdateEmployeeInfo_ShouldUpdateEmployee_WhenUsernameAndEmailAreUnique()
        {
            // Arrange
            var existingEmployee = new Employee(3, "John", "Davidov", "user1", "password", "existing@example.com", 1);
            _employeeManager.AddEmployee(existingEmployee);

            // Act
            var updatedEmployee = new Employee(existingEmployee.GetId(), "Updated", "Name", "updatedUser", existingEmployee.GetPassword(), "updated@example.com", existingEmployee.RoleId());
            _employeeManager.UpdateEmployeeInfo(updatedEmployee);

            // Assert
            var result = _employeeManager.GetEmployeeByUsername("updatedUser");
            Assert.IsNotNull(result);
            Assert.AreEqual("Updated", result.GetFirstName());
            Assert.AreEqual("updated@example.com", result.GetEmail());
        }
        [TestMethod]
        public void ChangeEmployeePassword_ShouldReturnTrue_WhenPasswordIsChanged()
        {
            // Arrange
            var employeeId = 1;
            var oldPassword = "5e884898da28047151d0e56f8dc6292773603d0d6aabbdd62a11ef721d1542d8";
            var newPassword = "newPassword";

            // Act
            var result = _employeeManager.ChangeEmployeePassword(employeeId, oldPassword, newPassword);

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOldPasswordException))]
        public void ChangeEmployeePassword_ShouldThrowException_WhenOldPasswordIsInvalid()
        {
            // Arrange
            var employeeId = 1;
            var oldPassword = "wrongPassword";
            var newPassword = "newPassword";

            // Act
            _employeeManager.ChangeEmployeePassword(employeeId, oldPassword, newPassword);

            // Assert
            // Expecting InvalidOldPasswordException
        }
        [TestMethod]
        public void SearchEmployeeByName_ShouldReturnEmployees_WhenNameMatches()
        {
            // Arrange
            var name = "Doe";

            // Act
            var result = _employeeManager.SearchEmployeeByName(name);

            // Assert
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Count > 0);
        }

        [TestMethod]
        public void SearchEmployeeByName_ShouldReturnEmptyList_WhenNoNameMatches()
        {
            // Arrange
            var name = "NonExistingName";

            // Act
            var result = _employeeManager.SearchEmployeeByName(name);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(0, result.Count);
        }

    }
}
