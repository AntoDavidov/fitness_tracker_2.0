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

        [TestMethod]
        [ExpectedException(typeof(DuplicateUsernameException))]
        public void UpdateEmployeeInfo_ShouldThrowDuplicateUsernameException_WhenUsernameAlreadyExists()
        {
            // Arrange
            var existingEmployee = new Employee(1, "John", "Doe", "existingUser", "password", "email@example.com", "role");
            _employeeManager.AddEmployee(existingEmployee);
            var anotherEmployee = new Employee(2, "Jane", "Smith", "anotherUser", "password", "another@example.com", "role");
            _employeeManager.AddEmployee(anotherEmployee);

            // Act
            anotherEmployee.SetUsername("existingUser");
            _employeeManager.UpdateEmployeeInfo(anotherEmployee);

            // Assert
            // Expecting a DuplicateUsernameException
        }

        [TestMethod]
        [ExpectedException(typeof(DuplicateEmailException))]
        public void UpdateEmployeeInfo_ShouldThrowDuplicateEmailException_WhenEmailAlreadyExists()
        {
            // Arrange
            var existingEmployee = new Employee(3, "John", "Doe", "user1", "password", "existing@example.com", "TRAINER");
            _employeeManager.AddEmployee(existingEmployee);
            var anotherEmployee = new Employee(4, "Jane", "Smith", "newUser", "password", "another@example.com", "TRAINER");
            _employeeManager.AddEmployee(anotherEmployee);

            // Act
            anotherEmployee.SetEmail("existing@example.com");
            _employeeManager.UpdateEmployeeInfo(anotherEmployee);

            // Assert
            // Expecting a DuplicateEmailException
        }

        [TestMethod]
        public void UpdateEmployeeInfo_ShouldUpdateEmployee_WhenUsernameAndEmailAreUnique()
        {
            // Arrange
            var existingEmployee = new Employee(3, "John", "Davidov", "user1", "password", "existing@example.com", "TRAINER");
            _employeeManager.AddEmployee(existingEmployee);

            // Act
            existingEmployee.SetFirstName("Updated");
            existingEmployee.SetLastName("Name");
            existingEmployee.SetUsername("updatedUser");
            existingEmployee.SetEmail("updated@example.com");
            _employeeManager.UpdateEmployeeInfo(existingEmployee);


            List<Employee> allEmployees = _employeeManager.GetEmployees();
            // Assert
            var updatedEmployee = _employeeManager.GetEmployeeByUsername("updatedUser");
            Assert.IsNotNull(updatedEmployee);
            Assert.AreEqual("Updated", updatedEmployee.GetFirstName());
            Assert.AreEqual("updated@example.com", updatedEmployee.GetEmail());
        }
    }
}
