using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ManagerLibrary;
using NameLibrary;

namespace Unit_Testing
{
    [TestClass]
    public class TestEmployeeManager
    {
        [TestMethod]
        public void CreateAnEmployee()
        {
            EmployeeManager employeeManager = new EmployeeManager();
            Employee employee = new Employee("John", "Doe", "johndoe", "password123", "johndoe@example.com", "Trainer");

            employeeManager.AddEmployee(employee);

            var employees = employeeManager.GetEmployees();
            Assert.IsNotNull(employees);  
            Assert.IsTrue(employees.Count > 0);  
            Assert.IsTrue(employees.Any(e => e.GetUsername() == "johndoe"));
        }
        [TestMethod]
        public void AddMultipleEmployees()
        {
            // Arrange
            EmployeeManager employeeManager = new EmployeeManager();
            Employee employee1 = new Employee("John", "Doe", "johndoe", "password123", "johndoe@example.com", "Trainer");
            Employee employee2 = new Employee("Jane", "Smith", "janesmith", "password456", "janesmith@example.com", "Manager");

            // Act
            employeeManager.AddEmployee(employee1);
            employeeManager.AddEmployee(employee2);

            // Assert
            var employees = employeeManager.GetEmployees();
            Assert.IsNotNull(employees);  
            Assert.IsTrue(employees.Count >= 2); 
            Assert.IsTrue(employees.Any(e => e.GetUsername() == "johndoe"));  
            Assert.IsTrue(employees.Any(e => e.GetUsername() == "janesmith")); 
        }
        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void AddEmployeesWithTheSameEmail()
        {
            EmployeeManager employeeManager = new EmployeeManager();
            Employee employee1 = new Employee("John", "Doe", "johndoe", "password123", "johndoe@example.com", "Trainer");

            employeeManager.AddEmployee(employee1);

            Employee employee2 = new Employee("Jane", "Smith", "janesmith", "password456", "johndoe@example.com", "Manager");
            employeeManager.AddEmployee(employee2);
        }
    }
}
