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
        private Employee _employee;
        private EmployeeManager _employeeManager;
        private ExerciseManager _exerciseManager;
        private WorkoutManager _workoutManager;

        public frmTrainerUCPage(Employee loggedInEmployee, EmployeeManager employeeManager, ExerciseManager exerciseManager, WorkoutManager workoutManager)
        {
            InitializeComponent();
            _employee = loggedInEmployee;
            _employeeManager = employeeManager;
            _exerciseManager = exerciseManager;
            _workoutManager = workoutManager;
        }

        private void AddUserControl(UserControl userControl)
        {
            panelContainer.Controls.Clear();
            panelContainer.Controls.Add(userControl);
            userControl.BringToFront();
        }

        private void btnStrength_Click(object sender, EventArgs e)
        {
            UC_StrengthPage ucStrengthPage = new UC_StrengthPage(_exerciseManager);
            AddUserControl(ucStrengthPage);
        }

        //private void btnCardio_Click(object sender, EventArgs e)
        //{
        //    ucCardioPage ucCardioPage = new ucCardioPage(_exerciseManager);
        //    AddUserControl(ucCardioPage);
        //}

        private void btnSuggestions_Click(object sender, EventArgs e)
        {
            UC_SuggestionsPage ucSuggestionsPage = new UC_SuggestionsPage(_exerciseManager, _workoutManager);
            AddUserControl(ucSuggestionsPage);
        }

        //private void btnProfile_Click(object sender, EventArgs e)
        //{
        //    ucProfilePage ucProfilePage = new ucProfilePage(_employee, _employeeManager);
        //    AddUserControl(ucProfilePage);
        //}

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
            frmLoginPage frmLoginPage = new frmLoginPage(_employeeManager, _exerciseManager, _workoutManager); 
            frmLoginPage.Show();
        }
    }
}
