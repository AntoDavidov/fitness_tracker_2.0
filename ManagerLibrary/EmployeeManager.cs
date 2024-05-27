using DBLibrary.IRepositories;
using ManagerLibrary.Exceptions;
using ManagerLibrary;
using NameLibrary;

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
        if (cachedEmployees == null)
        {
            cachedEmployees = _employeeRepository.GetAllEmployees();
        }

        foreach (var e in cachedEmployees)
        {
            if (e.GetUsername() == employee.GetUsername())
            {
                throw new DuplicateUsernameException();
            }
        }
        //Do this in a separeate method, private method
        foreach (var e in cachedEmployees)
        {
            if (e.GetEmail() == employee.GetEmail())
            {
                throw new DuplicateEmailException();
            }
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
        if (cachedEmployees == null)
        {
            cachedEmployees = _employeeRepository.GetAllEmployees();
        }

        foreach (var e in cachedEmployees)
        {
            if (e.GetUsername() == employee.GetUsername() && e.GetId() != employee.GetId())
            {
                throw new DuplicateUsernameException();
            }
        }

        foreach (var e in cachedEmployees)
        {
            if (e.GetEmail() == employee.GetEmail() && e.GetId() != employee.GetId())
            {
                throw new DuplicateEmailException();
            }
        }

        string hashedPassword = HashPassword(employee.GetPassword());
        bool result = _employeeRepository.UpdateEmployeeInfo(employee.GetFirstName(), employee.GetLastName(), employee.GetUsername(), hashedPassword, employee.GetEmail(), employee.Role());
        if (result)
        {
            cachedEmployees = _employeeRepository.GetAllEmployees();
        }
        return result;
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
