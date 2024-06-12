using ManagerLibrary;
using ManagerLibrary.Exceptions;
using NameLibrary;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Fitness_Tracker2._0
{
    public partial class HRMenuPage : Form
    {
        private readonly EmployeeManager _employeeManager;
        private readonly ExerciseManager _exerciseManager;
        private readonly WorkoutManager _workoutManager;

        public HRMenuPage(EmployeeManager employeeManager, ExerciseManager exerciseManager, WorkoutManager workoutManager)
        {
            InitializeComponent();
            _employeeManager = employeeManager;
            _exerciseManager = exerciseManager;
            _workoutManager = workoutManager;
            txtbPassword.PasswordChar = '*';
            PopulateComboBox();
            PopulateListBox();
            lstbEmployees.SelectedIndexChanged += lstbEmployees_SelectedIndexChanged;
            rdbAddEmployee.CheckedChanged += rdbAddEmployee_CheckedChanged;
            rdbEditEmployee.CheckedChanged += rdbEditEmployee_CheckedChanged;
        }

        private void PopulateComboBox()
        {
            cmbRole.Items.Clear();
            cmbRole.Items.Add("Trainer");
            cmbRole.Items.Add("HR");
            cmbRole.Items.Add("Nutritionist");
            cmbRole.SelectedIndex = 0;
        }

        private void ResetInputs()
        {
            txtbFirstName.Text = "";
            txtbLastName.Text = "";
            txtbPassword.Text = "";
            txtbUsername.Text = "";
            txtbEmail.Text = "";
            cmbRole.SelectedIndex = 0;
            txtbPassword.ReadOnly = false;
        }

        private void PopulateListBox()
        {
            lstbEmployees.Items.Clear();
            List<Employee> employees = _employeeManager.GetEmployees();
            foreach (Employee employee in employees)
            {
                lstbEmployees.Items.Add($"{employee.GetId()}: {employee.GetFirstName()} {employee.GetLastName()} ({employee.GetUsername()})");
            }
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            string firstName = txtbFirstName.Text;
            string lastName = txtbLastName.Text;
            string username = txtbUsername.Text;
            string password = txtbPassword.Text;
            string email = txtbEmail.Text;
            int roleId = cmbRole.SelectedIndex + 1;

            if (rdbAddEmployee.Checked)
            {
                AddEmployee(firstName, lastName, username, password, email, roleId);
                ResetInputs();
            }
            else if (rdbEditEmployee.Checked)
            {
                UpdateEmployee(firstName, lastName, username, password, email, roleId);
                ResetInputs();
            }
            else if (rdbDeleteEmployee.Checked)
            {
                DeleteEmployee();
                ResetInputs();
            }
        }

        private void AddEmployee(string firstName, string lastName, string username, string password, string email, int roleId)
        {
            try
            {
                Employee newEmployee = new Employee(firstName, lastName, username, password, email, roleId);
                _employeeManager.AddEmployee(newEmployee);
                MessageBox.Show("Employee added successfully!");
                PopulateListBox();
            }
            catch (DuplicateUsernameException ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (DuplicateEmailException ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateEmployee(string firstName, string lastName, string username, string password, string email, int roleId)
        {
            if (lstbEmployees.SelectedIndex >= 0)
            {
                try
                {
                    string selectedEmployeeInfo = lstbEmployees.SelectedItem.ToString();
                    string[] parts = selectedEmployeeInfo.Split(":");

                    if (int.TryParse(parts[0], out int id))
                    {
                        Employee updatedEmployee = new Employee(id, firstName, lastName, username, password, email, roleId);
                        _employeeManager.UpdateEmployeeInfo(updatedEmployee);
                        MessageBox.Show("Employee updated successfully!");
                        PopulateListBox();
                    }
                    else
                    {
                        MessageBox.Show("Invalid employee ID format.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (DuplicateUsernameException ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (DuplicateEmailException ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Please select an employee to edit.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void DeleteEmployee()
        {
            if (lstbEmployees.SelectedIndex >= 0)
            {
                try
                {
                    string selectedEmployeeInfo = lstbEmployees.SelectedItem.ToString();
                    string[] parts = selectedEmployeeInfo.Split(":");

                    if (int.TryParse(parts[0], out int id))
                    {
                        var confirmationResult = MessageBox.Show("Are you sure you want to delete this employee?", "Confirm Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        if (confirmationResult == DialogResult.Yes)
                        {
                            _employeeManager.DeleteEmployee(id);
                            MessageBox.Show("Employee deleted successfully!");
                            PopulateListBox();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Invalid employee ID format.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An unexpected error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Please select an employee to delete.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void lstbEmployees_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstbEmployees.SelectedIndex >= 0)
            {
                try
                {
                    string selectedEmployeeInfo = lstbEmployees.SelectedItem.ToString();
                    string[] parts = selectedEmployeeInfo.Split(":");

                    if (int.TryParse(parts[0], out int id))
                    {
                        Employee existingEmployee = _employeeManager.GetEmployeeById(id);
                        if (existingEmployee != null)
                        {
                            txtbFirstName.Text = existingEmployee.GetFirstName();
                            txtbLastName.Text = existingEmployee.GetLastName();
                            txtbUsername.Text = existingEmployee.GetUsername();
                            txtbPassword.Text = existingEmployee.GetPassword(); // Be careful with storing passwords in plain text
                            txtbEmail.Text = existingEmployee.GetEmail();
                            cmbRole.SelectedIndex = existingEmployee.RoleId() - 1; // Adjust roleId to match combo box index
                        }
                        else
                        {
                            MessageBox.Show("Employee not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Invalid employee ID format.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An unexpected error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void rdbAddEmployee_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbAddEmployee.Checked)
            {
                txtbPassword.ReadOnly = false;
            }
        }

        private void rdbEditEmployee_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbEditEmployee.Checked)
            {
                txtbPassword.ReadOnly = true;
            }
        }
    }
}
