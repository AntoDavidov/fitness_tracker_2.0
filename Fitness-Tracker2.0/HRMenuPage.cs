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
        private readonly PasswordManager _passwordManager;

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
            rdbDeleteEmployee.CheckedChanged += rdbDeleteEmployee_CheckedChanged;
            _passwordManager = new PasswordManager();
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
                UpdateEmployee(firstName, lastName, username, email, roleId);
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

        private void UpdateEmployee(string firstName, string lastName, string username, string email, int roleId)
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

                        if (!string.IsNullOrEmpty(txtbPassword.Text))
                        {
                            string newPassword = txtbPassword.Text;
                            _employeeManager.ChangeEmployeePassword(existingEmployee.GetId(), existingEmployee.GetPassword(), newPassword);
                            MessageBox.Show("Password updated successfully!");
                        }

                        Employee updatedEmployee = new Employee(id, firstName, lastName, username, existingEmployee.GetPassword(), email, roleId);
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
                catch (InvalidOldPasswordException ex)
                {
                    MessageBox.Show("The old password is incorrect.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                            txtbPassword.Text = ""; // Don't show the hashed password
                            txtbEmail.Text = existingEmployee.GetEmail();
                            cmbRole.SelectedIndex = existingEmployee.RoleId() - 1;
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
                ResetInputs();
                lstbEmployees.ClearSelected();
                txtbPassword.ReadOnly = false;
            }
        }

        private void rdbEditEmployee_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbEditEmployee.Checked)
            {
                ResetInputs();
                lstbEmployees.ClearSelected();
                txtbPassword.ReadOnly = false;
            }
        }

        private void rdbDeleteEmployee_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbDeleteEmployee.Checked)
            {
                ResetInputs();
                lstbEmployees.ClearSelected();
                txtbPassword.ReadOnly = true;
            }
        }

        private void pctbLogOut_Click(object sender, EventArgs e)
        {
            this.Close();
            frmLoginPage frmLoginPage = new frmLoginPage(_employeeManager, _exerciseManager, _workoutManager);
            frmLoginPage.Show();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string searchName = txtbSearchName.Text.Trim();
            if (string.IsNullOrEmpty(searchName))
            {
                MessageBox.Show("Please enter a name to search.");
                return;
            }

            List<Employee> employees = _employeeManager.SearchEmployeeByName(searchName);
            if (employees.Count > 0)
            {
                lstbEmployees.Items.Clear();
                foreach (Employee employee in employees)
                {
                    lstbEmployees.Items.Add($"{employee.GetId()}: {employee.GetFirstName()} {employee.GetLastName()} ({employee.GetUsername()})");
                }
            }
            else
            {
                MessageBox.Show("No employees found with the given name.");
            }
            txtbSearchName.Text = "";
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            lstbEmployees.Items.Clear();
        }
    }
}
