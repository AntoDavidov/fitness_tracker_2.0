﻿using ManagerLibrary.Exceptions;
using ManagerLibrary;
using NameLibrary;
using IRepositories;

public class EmployeeManager
{
    private readonly IEmployeeRepo _employeeRepository;
    private List<Employee> cachedEmployees;
    private PasswordManager passwordManager;

    public EmployeeManager(IEmployeeRepo employeeRepository)
    {
        _employeeRepository = employeeRepository;
        passwordManager = new PasswordManager();
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

        string passwordHashed = passwordManager.HashPassword(employee.GetPassword());
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

    public Employee VerifyEmployeeCredentials(string username, string password)
    {
        string hashedPassword = passwordManager.HashPassword(password);
        try
        {
            return _employeeRepository.VerifyEmployeeCredentials(username, hashedPassword);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error verifying employee credentials: " + ex.Message);
            return null;
        }
    }


    public string GetEmployeeRole(string username, string password)
    {
        string hashedPassword = passwordManager.HashPassword(password);
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

        string hashedPassword = passwordManager.HashPassword(employee.GetPassword());
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
