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
        public ucProfilePage(Employee loggedInEmployee)
        {
            InitializeComponent();
            this.loggedInEmployee = loggedInEmployee;
            PopulateTextBoxes();
        }

        private void PopulateTextBoxes()
        {
            // Populate the text boxes with the logged-in employee's information
            txtbFirstName.Text = loggedInEmployee.GetFirstName();
            txtbLastName.Text = loggedInEmployee.GetLastName();
            txtbUsername.Text = loggedInEmployee.GetUsername();
            txtbPassword.Text = loggedInEmployee.GetPassword();
            txtbEmail.Text = loggedInEmployee.GetEmail();
            cmbbRole.Text = loggedInEmployee.Role();

            // You can populate other text boxes similarly if needed
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            loggedInEmployee.SetFirstName(txtbFirstName.Text);
            loggedInEmployee.SetLastName(txtbLastName.Text);
            loggedInEmployee.SetUsername(txtbUsername.Text);
            loggedInEmployee.SetPassword(txtbPassword.Text);
            loggedInEmployee.SetEmail(txtbEmail.Text);
            // You can update other properties similarly if needed

            // Call the method to update the employee's information in the database
            EmployeeManager employeeManager = new EmployeeManager();
            bool updateResult = employeeManager.UpdateEmployeeInfo(loggedInEmployee);

            if (updateResult)
            {
                MessageBox.Show("Profile updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Failed to update profile.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            PopulateTextBoxes();

        }
    }
}
