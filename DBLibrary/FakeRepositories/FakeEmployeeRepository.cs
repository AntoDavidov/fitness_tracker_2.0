using System.Collections.Generic;
using System.Linq;
using DBLibrary.IRepositories;
using NameLibrary;

namespace DBLibrary.FakeRepositories
{
    public class FakeEmployeeRepository : IEmployeeRepository
    {
        private readonly List<Employee> _employees;

        public FakeEmployeeRepository()
        {
            _employees = new List<Employee>
            {
                new Employee("John", "Doe", "trainer", "password", "trainer@example.com", "TRAINER"),
                new Employee("Jane", "Doe", "admin", "password", "admin@example.com", "ADMIN")
                // Add more fake employees as needed
            };
        }

        public bool VerifyEmployeeCredentials(string username, string password)
        {
            return _employees.Any(e => e.GetUsername() == username && e.GetPassword() == password);
        }

        public Employee GetEmployeeByUsername(string username)
        {
            return _employees.FirstOrDefault(e => e.GetUsername() == username);
        }

        public string GetEmployeeRole(string username, string password)
        {
            var employee = _employees.FirstOrDefault(e => e.GetUsername() == username && e.GetPassword() == password);
            return employee?.Role();
        }

        public bool AddEmployee(string firstName, string lastName, string username, string password, string email, string role)
        {
            if (_employees.Any(e => e.GetUsername() == username))
                return false;

            var newEmployee = new Employee(firstName, lastName, username, password, email, role);
            _employees.Add(newEmployee);
            return true;
        }

        public bool UpdateEmployeeInfo(string username, string firstName, string lastName, string password, string email, string role)
        {
            var employee = _employees.FirstOrDefault(e => e.GetUsername() == username);
            if (employee == null)
                return false;

            employee.SetFirstName(firstName);
            employee.SetLastName(lastName);
            employee.SetPassword(password);
            employee.SetEmail(email);
            employee.SetRole(role);
            return true;
        }

        public bool DeleteEmployee(int id)
        {
            var employee = _employees.FirstOrDefault(e => e.GetId() == id);
            if (employee == null)
                return false;

            _employees.Remove(employee);
            return true;
        }

        public List<Employee> GetAllEmployees()
        {
            return _employees;
        }

        // Implement other methods as needed
    }
}
