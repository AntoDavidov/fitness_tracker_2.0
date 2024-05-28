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
                new Employee(1, "John", "Doe", "trainer", "5e884898da28047151d0e56f8dc6292773603d0d6aabbdd62a11ef721d1542d8", "trainer@example.com", "TRAINER"),
                new Employee(2, "Jane", "Doe", "admin", "5e884898da28047151d0e56f8dc6292773603d0d6aabbdd62a11ef721d1542d8", "admin@example.com", "ADMIN")
            };
        }

        public Employee VerifyEmployeeCredentials(string username, string password)
        {
            var employee = _employees.FirstOrDefault(e => e.GetUsername() == username && e.GetPassword() == password);
            return employee;
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
            if (_employees.Any(e => e.GetUsername() == username || e.GetEmail() == email))
                return false;

            int newId = _employees.Max(e => e.GetId()) + 1;
            var newEmployee = new Employee(newId, firstName, lastName, username, password, email, role);
            _employees.Add(newEmployee);
            return true;
        }

        public bool UpdateEmployeeInfo(string firstName, string lastName, string username, string password, string email, string role)
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
