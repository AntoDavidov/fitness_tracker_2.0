using NameLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBLibrary.IRepositories
{
    public interface IEmployeeRepository
    {
        bool AddEmployee(string firstName, string lastName, string username, string hashedPassword, string email, string role);
        List<Employee> GetAllEmployees();
        Employee GetEmployeeByUsername(string username);
        bool VerifyEmployeeCredentials(string username, string password);
        string GetEmployeeRole(string username, string password);
        bool DeleteEmployee(int id);
        bool UpdateEmployeeInfo(string firstName, string lastName, string username, string hashedPassword, string email, string role);
    }
}
