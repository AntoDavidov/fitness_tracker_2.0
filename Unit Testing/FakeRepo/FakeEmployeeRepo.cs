using IRepositories;
using NameLibrary;
using System.Collections.Generic;
using System.Linq;

namespace Unit_Testing.FakeRepo
{
    public class FakeEmployeeRepo : IEmployeeRepo
    {
        private readonly List<Employee> _employees;

        public FakeEmployeeRepo()
        {
            _employees = new List<Employee>
            {
                new Employee(1, "John", "Doe", "trainer", "5e884898da28047151d0e56f8dc6292773603d0d6aabbdd62a11ef721d1542d8", "trainer@example.com", 1),
                new Employee(2, "Jane", "Doe", "admin", "5e884898da28047151d0e56f8dc6292773603d0d6aabbdd62a11ef721d1542d8", "admin@example.com", 2)
            };
        }

        public Employee VerifyEmployeeCredentials(string username, string password)
        {
            return _employees.FirstOrDefault(e => e.GetUsername() == username && e.GetPassword() == password);
        }

        public Employee GetEmployeeByUsername(string username)
        {
            return _employees.FirstOrDefault(e => e.GetUsername() == username);
        }

        public string GetEmployeeRole(string username, string password)
        {
            foreach (var employee in _employees)
            {
                if (employee.GetUsername() == username && employee.GetPassword() == password)
                {
                    return employee.Role().ToString();
                }
            }
            return null;
        }

        public bool AddEmployee(string firstName, string lastName, string username, string password, string email, int roleId)
        {
            foreach (var employee in _employees)
            {
                if (employee.GetUsername() == username || employee.GetEmail() == email)
                {
                    return false;
                }
            }

            int newId = 1;
            foreach (var employee in _employees)
            {
                if (employee.GetId() >= newId)
                {
                    newId = employee.GetId() + 1;
                }
            }
            var newEmployee = new Employee(newId, firstName, lastName, username, password, email, roleId);
            _employees.Add(newEmployee);
            return true;
        }

        public bool UpdateEmployeeInfo(int userId, string firstName, string lastName, string username, string password, string email, int roleId)
        {
            Employee employee = null;
            foreach (var emp in _employees)
            {
                if (emp.GetId() == userId)
                {
                    employee = emp;
                    break;
                }
            }

            if (employee == null)
                return false;

            var updatedEmployee = new Employee(userId, firstName, lastName, username, password, email, roleId);

            // Remove the old employee and add the updated employee to the list
            _employees.Remove(employee);
            _employees.Add(updatedEmployee);

            return true;
        }

        public bool DeleteEmployee(int userId)
        {
            Employee employee = null;
            foreach (var emp in _employees)
            {
                if (emp.GetId() == userId)
                {
                    employee = emp;
                    break;
                }
            }

            if (employee == null)
                return false;

            _employees.Remove(employee);
            return true;
        }

        public List<Employee> GetAllEmployees()
        {
            return _employees;
        }
    }
}
