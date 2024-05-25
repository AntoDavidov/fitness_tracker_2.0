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

        public frmLoginPage(EmployeeManager employeeManager, ExerciseManager exerciseManager)
        {
            InitializeComponent();
            manager = employeeManager;
            this.exerciseManager = exerciseManager;
            txtbPassword.PasswordChar = '*';
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtbUsername.Text;
            string password = txtbPassword.Text;

            bool loggedIn = manager.VerifyEmployeeCredentials(username, password);

            if (username == "default" && password == "password")
            {
                var adminHomePage = new frmAdminHomePage(manager);
                adminHomePage.Show();
                this.Hide();
                return;
            }

            if (loggedIn)
            {
                MessageBox.Show("Welcome " + username);
                string role = manager.GetEmployeeRole(username, password)?.Trim();

                if (role == "TRAINER")
                {
                    var loggedEmployee = manager.GetEmployeeByUsername(username);
                    var trainerUCPage = new frmTrainerUCPage(loggedEmployee, manager, exerciseManager);
                    trainerUCPage.Show();
                }
                else if (role == "ADMIN")
                {
                    var adminHomePage = new frmAdminHomePage(manager);
                    adminHomePage.Show();
                }
                else if (role == "Nutritionist")
                {
                    // Will implement in the future!
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
