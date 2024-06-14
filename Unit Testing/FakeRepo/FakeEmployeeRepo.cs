using IRepositories;
using NameLibrary;
using System.Collections.Generic;

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
            foreach (var e in _employees)
            {
                if (e.GetUsername() == username && e.GetPassword() == password)
                {
                    return e;
                }
            }
            return null;
        }

        public Employee GetEmployeeByUsername(string username)
        {
            foreach (var e in _employees)
            {
                if (e.GetUsername() == username)
                {
                    return e;
                }
            }
            return null;
        }

        public Employee GetEmployeeById(int id)
        {
            foreach (var e in _employees)
            {
                if (e.GetId() == id)
                {
                    return e;
                }
            }
            return null;
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

        public bool UpdateEmployeeInfo(int userId, string firstName, string lastName, string username, string email, int roleId)
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

            var updatedEmployee = new Employee(userId, firstName, lastName, username, email, roleId);

            _employees.Remove(employee);
            _employees.Add(updatedEmployee);

            return true;
        }

        public bool UpdateEmployeePassword(int employeeId, string newPassword)
        {
            Employee employee = null;
            foreach (var e in _employees)
            {
                if (e.GetId() == employeeId)
                {
                    employee = e;
                    break;
                }
            }

            if (employee == null)
                return false;

            Employee updatedEmployee = new Employee(employeeId, employee.GetFirstName(), employee.GetLastName(), employee.GetUsername(), newPassword, employee.GetEmail(), employee.RoleId());

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

        public List<Employee> SearchEmployeesByName(string name)
        {
            var result = new List<Employee>();
            foreach (var e in _employees)
            {
                if (($"{e.GetFirstName()} {e.GetLastName()}").IndexOf(name, System.StringComparison.OrdinalIgnoreCase) >= 0)
                {
                    result.Add(e);
                }
            }
            return result;
        }
    }
}
