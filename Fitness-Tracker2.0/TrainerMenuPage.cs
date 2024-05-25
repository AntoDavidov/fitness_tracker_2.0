using Fitness_Tracker2._0.UserControls;
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

namespace Fitness_Tracker2._0
{
    public partial class frmTrainerUCPage : Form
    {
        Employee _employee;
        EmployeeManager EmployeeManager;
        public frmTrainerUCPage(Employee loggedInEmployee)
        {
            _employee = loggedInEmployee;
            InitializeComponent();
        }
        private void AddUserControl(UserControl userControl)
        {
            panelContainer.Controls.Clear();
            panelContainer.Controls.Add(userControl);
            userControl.BringToFront();

        }

        private void btnStrength_Click(object sender, EventArgs e)
        {
            UC_StrengthPage ucStrengthPage = new UC_StrengthPage();
            AddUserControl(ucStrengthPage);
        }

        private void btnCardio_Click(object sender, EventArgs e)
        {
            ucCardioPage ucCardioPage = new ucCardioPage();
            AddUserControl(ucCardioPage);
        }

        private void btnSuggestions_Click(object sender, EventArgs e)
        {
            UC_SuggestionsPage ucSuggestionsPage = new UC_SuggestionsPage();
            AddUserControl(ucSuggestionsPage);
        }

        private void btnProfile_Click(object sender, EventArgs e)
        {
            ucProfilePage ucProfilePage = new ucProfilePage(_employee);
            AddUserControl(ucProfilePage);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
            frmLoginPage frmLoginPage = new frmLoginPage(EmployeeManager);
            frmLoginPage.Show();
        }
    }
}
