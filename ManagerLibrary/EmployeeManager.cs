using System;
using System.Collections.Generic;
using System.Linq;
using DBLibrary;
using NameLibrary;

namespace ManagerLibrary
{
    public class EmployeeManager
    {
        private EmployeeDBManager employeeDBManager;
        private List<Employee> cachedEmployees;

        public EmployeeManager()
        {
            employeeDBManager = new EmployeeDBManager();
            cachedEmployees = null;
        }

        public void AddEmployee(Employee employee)
        {
            employeeDBManager.AddEmployeeToDB(employee);
            cachedEmployees = null;
        }
        public List<Employee> GetEmployees()
        {
            // Lazy loading and caching employees
            if (cachedEmployees == null)
            {
                cachedEmployees = employeeDBManager.GetAllEmployeesFromDB();
            }
            return cachedEmployees;
        }

        public bool VerifyUserCredentials(string email, string password)
        {
            try
            {
                return employeeDBManager.VerifyUserCredentials(email, password);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error verifying employee credentials: " + ex.Message);
                return false;
            }
        }
        public bool VerifyEmployeeCredentials(string email, string password)
        {
            try
            {
                return employeeDBManager.VerifyEmployeeCredentials(email, password);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error verifying employee credentials: " + ex.Message);
                return false;
            }
        }
        public string GetEmployeeRole(string username, string password)
        {
            return employeeDBManager.GetEmployeeRole(username, password);
        }

        public bool UpdateEmployeeInfo(Employee employee)
        {
            try
            {
                return employeeDBManager.UpdateEmployeeInfo(employee);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error updating employee information: " + ex.Message);
                return false;
            }
        }
        public Employee GetEmployeeByUsername(string username)
        {
            return employeeDBManager.GetEmployeeByUsername(username);
        }

        public void DeleteEmployee(int id)
        {
            employeeDBManager.DeleteEmployee(id);
            cachedEmployees = null;
        }

        //public Employee GetEmployeeByUsernameAndPassword(string username, string password)
        //{
        //    return GetEmployees().FirstOrDefault(emp => emp.GetFirstName() == username && emp.GetPassword() == password);
        //}
    }
}
