using System;
using System.Windows.Forms;
using ManagerLibrary;
using ManagerLibrary.Exceptions;
using NameLibrary;

namespace Fitness_Tracker2._0
{
    public partial class frmAdminHomePage : Form
    {
        private EmployeeManager _employeeManager;
        private ExerciseManager _exerciseManager;
        private WorkoutManager _workoutManager;

        public frmAdminHomePage(EmployeeManager employeeManager, ExerciseManager exerciseManager, WorkoutManager workoutManager)
        {
            InitializeComponent();
            _employeeManager = employeeManager;
            _exerciseManager = exerciseManager;
            _workoutManager = workoutManager;
            PopulateListBox();
        }

        private void PopulateListBox()
        {
            lstbEmployees.Items.Clear();
            List<Employee> employees = _employeeManager.GetEmployees();
            foreach (Employee employee in employees)
            {
                lstbEmployees.Items.Add(employee.ToString());
            }
        }

        private void btnAddEmployee_Click(object sender, EventArgs e)
        {
            try
            {
                string firstName = txtbFirstName.Text;
                string lastName = txtbLastName.Text;
                string username = txtbUsername.Text;
                string password = txtbPassword.Text;
                string email = txtbEmail.Text;
                string role = cmbRole.Text;

                Employee newEmployee = new Employee(firstName, lastName, username, password, email, role);
                _employeeManager.AddEmployee(newEmployee);
                PopulateListBox();
                MessageBox.Show("Employee added successfully!");
            }
            catch (DuplicateUsernameException ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (DuplicateEmailException ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An unexpected error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDeleteEmployee_Click(object sender, EventArgs e)
        {

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (lstbEmployees.SelectedIndex >= 0)
            {
                string selectedEmployeeInfo = lstbEmployees.SelectedItem.ToString();
                string[] parts = selectedEmployeeInfo.Split(":");

                if (int.TryParse(parts[0], out int id))
                {
                    var confirmationResult = MessageBox.Show("Are you sure you want to delete this employee?", "Confirm Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (confirmationResult == DialogResult.Yes)
                    {
                        _employeeManager.DeleteEmployee(id);
                        PopulateListBox();
                        MessageBox.Show("Employee deleted successfully!");
                    }
                }
                else
                {
                    MessageBox.Show("Invalid employee ID format.");
                }
            }
            else
            {
                MessageBox.Show("Please select an employee to delete.");
            }
        }

        private void pctbGoBack_Click(object sender, EventArgs e)
        {
            this.Close();
            frmLoginPage frmLoginPage = new frmLoginPage(_employeeManager, _exerciseManager, _workoutManager);
            frmLoginPage.Show();
        }
    }
}
