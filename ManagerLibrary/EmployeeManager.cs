using System;
using System.Collections.Generic;
using System.Linq;
using DBLibrary;
using DBLibrary.IRepositories;
using ManagerLibrary.Exceptions;
using NameLibrary;

namespace ManagerLibrary
{
    public class EmployeeManager : PasswordManager
    {
        private readonly IEmployeeRepository _employeeRepository;
        private List<Employee> cachedEmployees;

        public EmployeeManager(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
            cachedEmployees = null;
        }

        public void AddEmployee(Employee employee)
        {
            if (_employeeRepository.GetAllEmployees().Any(e => e.GetUsername() == employee.GetUsername()))
            {
                throw new DuplicateUsernameException();
            }

            if (_employeeRepository.GetAllEmployees().Any(e => e.GetEmail() == employee.GetEmail()))
            {
                throw new DuplicateEmailException();
            }

            string passwordHashed = HashPassword(employee.GetPassword());
            _employeeRepository.AddEmployee(employee.GetFirstName(), employee.GetLastName(), employee.GetUsername(), passwordHashed, employee.GetEmail(), employee.Role());
            cachedEmployees = null;
        }


        public List<Employee> GetEmployees()
        {
            if (cachedEmployees == null)
            {
                cachedEmployees = _employeeRepository.GetAllEmployees();
            }
            return cachedEmployees;
        }

        public bool VerifyEmployeeCredentials(string username, string password)
        {
            string hashedPassword = HashPassword(password);
            try
            {
                return _employeeRepository.VerifyEmployeeCredentials(username, hashedPassword);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error verifying employee credentials: " + ex.Message);
                return false;
            }
        }


        public string GetEmployeeRole(string username, string password)
        {
            string hashedPassword = HashPassword(password);
            return _employeeRepository.GetEmployeeRole(username, hashedPassword);
        }

        public bool UpdateEmployeeInfo(Employee employee)
        {
            string hashedPassword = HashPassword(employee.GetPassword());
            try
            {
                return _employeeRepository.UpdateEmployeeInfo(employee.GetFirstName(), employee.GetLastName(), employee.GetUsername(), hashedPassword, employee.GetEmail(), employee.Role());
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error updating employee information: " + ex.Message);
                return false;
            }
        }

        public Employee GetEmployeeByUsername(string username)
        {
            return _employeeRepository.GetEmployeeByUsername(username);
        }

        public void DeleteEmployee(int id)
        {
            _employeeRepository.DeleteEmployee(id);
            cachedEmployees = null;
        }
    }
}
