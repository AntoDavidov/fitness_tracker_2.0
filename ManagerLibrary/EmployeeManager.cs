﻿using ManagerLibrary.Exceptions;
using NameLibrary;
using IRepositories;
using System;
using System.Collections.Generic;

namespace ManagerLibrary
{
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

            CheckForDuplicateUsername(employee);
            CheckForDuplicateEmail(employee);

            string passwordHashed = passwordManager.HashPassword(employee.GetPassword());
            _employeeRepository.AddEmployee(employee.GetFirstName(), employee.GetLastName(), employee.GetUsername(), passwordHashed, employee.GetEmail(), employee.RoleId());

            cachedEmployees = null;
        }

        public List<Employee> SearchEmployeeByName(string fullname)
        {
           return _employeeRepository.SearchEmployeesByName(fullname);
        }

        public Employee VerifyEmployeeCredentials(string username, string password)
        {
            string hashedPassword = passwordManager.HashPassword(password);
            return _employeeRepository.VerifyEmployeeCredentials(username, hashedPassword);
        }

        public bool UpdateEmployeeInfo(Employee employee)
        {
            if (cachedEmployees == null)
            {
                cachedEmployees = _employeeRepository.GetAllEmployees();
            }

            CheckForDuplicateUsername(employee);
            CheckForDuplicateEmail(employee);

            bool result = _employeeRepository.UpdateEmployeeInfo(
                employee.GetId(),
                employee.GetFirstName(),
                employee.GetLastName(),
                employee.GetUsername(),
                employee.GetEmail(),
                employee.RoleId()
            );

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
        public Employee GetEmployeeById(int id)
        {
            return _employeeRepository.GetEmployeeById(id);
        }

        public void DeleteEmployee(int id)
        {
            _employeeRepository.DeleteEmployee(id);
            cachedEmployees = null;
        }

        private void CheckForDuplicateUsername(Employee employee)
        {
            foreach (var e in cachedEmployees)
            {
                if (e.GetUsername() == employee.GetUsername() && e.GetId() != employee.GetId())
                {
                    throw new DuplicateUsernameException();
                }
            }
        }

        private void CheckForDuplicateEmail(Employee employee)
        {
            foreach (var e in cachedEmployees)
            {
                if (e.GetEmail() == employee.GetEmail() && e.GetId() != employee.GetId())
                {
                    throw new DuplicateEmailException();
                }
            }
        }

        public bool ChangeEmployeePassword(int employeeId, string oldPassword, string newPassword)
        {
            var employee = GetEmployeeById(employeeId);

            if (!passwordManager.VerifyPassword(oldPassword, employee.GetPassword()))
            {
                throw new InvalidOldPasswordException();
            }

            string newHashedPassword = passwordManager.HashPassword(newPassword);
            return _employeeRepository.UpdateEmployeePassword(employeeId, newHashedPassword);
        }
    }
}
