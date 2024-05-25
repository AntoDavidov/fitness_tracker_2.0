using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DBLibrary;
using NameLibrary;
using ManagerLibrary;

namespace Fitness_Tracker2._0
{
    public partial class frmAdminHomePage : Form
    {
        private EmployeeManager manager;

        public frmAdminHomePage(EmployeeManager employeeManager)
        {
            InitializeComponent();
            manager = employeeManager;
            PopulateListBox();
        }
        public void PopulateListBox()
        {
            lstbEmployees.Items.Clear();
            List<Employee> employees = manager.GetEmployees();
            foreach (Employee employee in employees)
            {
                lstbEmployees.Items.Add(employee.ToString());
            }

        }
        private void btnAddEmployee_Click(object sender, EventArgs e)
        {
            {
                string firstName = txtbFirstName.Text;
                string lastName = txtbLastName.Text;
                string username = txtbUsername.Text;
                string password = txtbPassword.Text;
                string email = txtbEmail.Text;
                string role = cmbRole.Text;

                Employee newEmployee = new Employee(firstName, lastName, username, password, email, role);
                manager.AddEmployee(newEmployee);
                PopulateListBox();


            }
        }

            
         //private void btnDelete_Click(object sender, EventArgs e)
        
            //if (lstbEmployees.SelectedIndex >= 0)
            //{
            //    // Get the selected employee's information
            //    string selectedEmployeeInfo = lstbEmployees.SelectedItem.ToString();
            //    string[] parts = selectedEmployeeInfo.Split(":");

            //    // Parse the ID string to an integer
            //    if (int.TryParse(parts[0], out int id))
            //    {
            //        // Delete the employee
            //        manager.DeleteEmployee(id);

            //        // Refresh the list after deletion
            //        PopulateListBox();
            //    }
            //    else
            //    {
            //        MessageBox.Show("Invalid employee ID format.");
            //    }
            //}
            //else
            //{
            //    MessageBox.Show("Please select an employee to delete.");
            //}
        
    }
}
