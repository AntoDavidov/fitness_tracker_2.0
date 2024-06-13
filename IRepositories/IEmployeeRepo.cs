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
        public List<Employee> SearchEmployeesByName(string fullName);
        Employee GetEmployeeByUsername(string username);
        Employee GetEmployeeById(int id);
        Employee VerifyEmployeeCredentials(string username, string password);
        bool DeleteEmployee(int id);
        bool UpdateEmployeeInfo(int userId, string firstName, string lastName, string username, string email, int roleId);
        bool UpdateEmployeePassword(int employeeId, string newHashedPassword);
    }
}
