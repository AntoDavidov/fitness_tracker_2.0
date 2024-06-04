using ManagerLibrary;
using NameLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fitness_Tracker2._0.UserControls
{
    public partial class ucProfilePage : UserControl
    {
        private Employee loggedInEmployee;
        private EmployeeManager employeeManager;

        public ucProfilePage(Employee loggedInEmployee, EmployeeManager _employeeManager)
        {
            InitializeComponent();
            this.loggedInEmployee = loggedInEmployee;
            this.employeeManager = _employeeManager;
            PopulateTextBoxes();
        }

        private void PopulateTextBoxes()
        {
            // Populate the text boxes with the logged-in employee's information
            txtbFirstName.Text = loggedInEmployee.GetFirstName();
            txtbLastName.Text = loggedInEmployee.GetLastName();
            txtbUsername.Text = loggedInEmployee.GetUsername();
            txtbEmail.Text = loggedInEmployee.GetEmail();
            cmbbRole.Text = loggedInEmployee.Role();

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtbPassword.Text != txtbConfirmPassword.Text)
            {
                MessageBox.Show("Passwords do not match. Please re-enter.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtbPassword.Text = "";
                txtbConfirmPassword.Text = "";
                return;
            }

            var updatedEmployee = new Employee(
                loggedInEmployee.GetId(),
                txtbFirstName.Text,
                txtbLastName.Text,
                txtbUsername.Text,
                txtbPassword.Text,
                txtbEmail.Text,
                cmbbRole.SelectedIndex + 1 
            );

            bool updateResult = employeeManager.UpdateEmployeeInfo(updatedEmployee);

            if (updateResult)
            {
                MessageBox.Show("Profile updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                loggedInEmployee = updatedEmployee; //!! Updating the loggedInEmployeeInfo
                PopulateTextBoxes();
            }
            else
            {
                MessageBox.Show("Failed to update profile.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                PopulateTextBoxes();
            }
        }
    }
}
