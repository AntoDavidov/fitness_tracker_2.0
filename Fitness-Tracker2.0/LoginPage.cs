using Microsoft.VisualBasic.ApplicationServices;
using NameLibrary;
using ManagerLibrary;
namespace Fitness_Tracker2._0
{
    public partial class frmLoginPage : Form
    {
        NameLibrary.User user;
        Employee loggedEmployee;
        EmployeeManager manager;

        frmAdminHomePage adminHomePage;
        frmTrainerUCPage trainerUCPage;
        public frmLoginPage()
        {
            InitializeComponent();
            manager = new EmployeeManager();
            adminHomePage = new frmAdminHomePage();
            user = new NameLibrary.User("Default", "User", "default", "password", "default@example.com");
            txtbPassword.PasswordChar = '*';


        }
        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtbUsername.Text;
            string password = txtbPassword.Text;

            bool loggedIn = manager.VerifyEmployeeCredentials(username, password);

            if (username == "default" && password == "password")
            {
                adminHomePage.Show();
                this.Hide();
                return;
            }

            if (loggedIn)
            {
                MessageBox.Show("Welcome " + username);
                string role = manager.GetEmployeeRole(username, password)?.Trim();// Trim because the role was giving unknown

                if (role == "TRAINER")
                {
                    loggedEmployee = manager.GetEmployeeByUsername(username); // Assuming you have a method to retrieve an employee by username
                    frmTrainerUCPage trainerUCPage = new frmTrainerUCPage(loggedEmployee); 
                    trainerUCPage.Show();

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
