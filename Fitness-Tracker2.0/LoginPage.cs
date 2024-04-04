using Microsoft.VisualBasic.ApplicationServices;
using NameLibrary;
using ManagerLibrary;
namespace Fitness_Tracker2._0
{
    public partial class frmLoginPage : Form
    {
        NameLibrary.User employee;
        EmployeeManager manager;

        frmAdminHomePage adminHomePage;
        frmTrainerHomePage trainerHomePage;
        public frmLoginPage()
        {
            InitializeComponent();
            manager = new EmployeeManager();
            adminHomePage = new frmAdminHomePage();
            trainerHomePage = new frmTrainerHomePage();
            employee = new NameLibrary.User("Default", "User", "default", "password", "default@example.com");
            txtbPassword.PasswordChar = '*';


        }
        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtbUsername.Text;
            string password = txtbPassword.Text;

            Employee loggedInEmployee = manager.GetEmployeeByUsernameAndPassword(username, password);

            if (username == "default" && password == "password")
            {
                adminHomePage.Show();
                this.Hide();
                return;
            }

            if (loggedInEmployee != null)
            {
                MessageBox.Show("Welcome " + loggedInEmployee.ToString());
                string role = loggedInEmployee.Role.Trim(); // Trim because the role was giving unknown

                if (role == "TRAINER")
                {
                    trainerHomePage.Show();
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
