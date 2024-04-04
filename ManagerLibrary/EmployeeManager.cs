using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBLibrary;
using NameLibrary;

namespace ManagerLibrary
{
    public class EmployeeManager
    {
        //private List<Employee> Employees;
        private EmployeeDBManager employeeDBManager;

        public EmployeeManager()
        {
            //Employees = new List<Employee>();
            employeeDBManager = new EmployeeDBManager();
            //Employees = employeeDBManager.GetAllEmployeesFromDB();
        }
        public void AddEmployee(Employee employee)
        {
            employeeDBManager.AddEmployeeToDB(employee);
            //Employees = employeeDBManager.GetAllEmployeesFromDB();
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
        public bool VerifyCustomer(string username, string password)
        {
            try
            {
                return employeeDBManager.VerifyCustomerCredentials(username, password);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }

        }
        public bool VerifyLogin(LoginDTO login)
        {
            return employeeDBManager.VerifyCustomerCredentials(login.Email, login.Password);
        }
        public void AddCustomer(Customer customer)
        {
            employeeDBManager.AddCustomerToDB(customer);
        }
        //public List<Employee> GetEmployees()
        //{
        //    return Employees;
        //}
        //public void DeleteEmployee(int id)
        //{
        //    employeeDBManager.DeleteEmployee(id);
        //    Employees = employeeDBManager.GetAllEmployeesFromDB();
        //}
        //public Employee GetEmployeeByUsernameAndPassword(string username, string password)
        //{
        //    return Employees.FirstOrDefault(emp => emp.UserName == username && emp.Password == password);
        //}

    }
}
