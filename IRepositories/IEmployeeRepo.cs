using NameLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRepositories
{
    public interface IEmployeeRepo
    {
        bool AddEmployee(string firstName, string lastName, string username, string hashedPassword, string email, int roleId);
        List<Employee> GetAllEmployees();
        Employee GetEmployeeByUsername(string username);
        Employee VerifyEmployeeCredentials(string username, string password);
        string GetEmployeeRole(string username, string password);
        bool DeleteEmployee(int id);
        bool UpdateEmployeeInfo(int userId, string firstName, string lastName, string username, string hashedPassword, string email, int roleId);
    }
}
