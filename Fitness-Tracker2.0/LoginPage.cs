using NameLibrary;
using ManagerLibrary;
using System;
using System.Windows.Forms;

namespace Fitness_Tracker2._0
{
    public partial class frmLoginPage : Form
    {
        private EmployeeManager manager;
        private ExerciseManager exerciseManager;
        private WorkoutManager workoutManager;

        public frmLoginPage(EmployeeManager employeeManager, ExerciseManager exerciseManager, WorkoutManager workoutManager)
        {
            InitializeComponent();
            manager = employeeManager;
            this.exerciseManager = exerciseManager;
            txtbPassword.PasswordChar = '*';
            this.workoutManager = workoutManager;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtbUsername.Text;
            string password = txtbPassword.Text;

            // Get the logged-in employee object
            Employee loggedInEmployee = manager.VerifyEmployeeCredentials(username, password);

            if (username == "default" && password == "password")
            {
                var adminHomePage = new HRMenuPage(manager, exerciseManager, workoutManager);
                adminHomePage.Show();
                this.Hide();
                return;
            }

            if (loggedInEmployee != null)
            {
                MessageBox.Show("Welcome " + username);
                string role = loggedInEmployee.Role()?.Trim();

                if (loggedInEmployee.Role() == "Trainer")
                {
                    var trainerUCPage = new frmTrainerUCPage(loggedInEmployee, manager, exerciseManager, workoutManager);
                    trainerUCPage.Show();
                }
                else if (loggedInEmployee.Role() == "HR")
                {
                    var adminHomePage = new HRMenuPage(manager, exerciseManager, workoutManager);
                    adminHomePage.Show();
                }
                else if (loggedInEmployee.Role() == "Nutritionist")
                {
                    MessageBox.Show("Nutritionist still not implemented!");
                }
                else
                {
                    MessageBox.Show("Unknown role");
                }

                this.Hide();
            }
            else
            {
                MessageBox.Show("Incorrect username or password");
            }
        }
    }
}
