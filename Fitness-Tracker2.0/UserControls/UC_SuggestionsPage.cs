using ExerciseLibrary;
using ManagerLibrary;
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
    public partial class UC_SuggestionsPage : UserControl
    {
        private ExerciseManager manager; 
        public UC_SuggestionsPage()
        {
            InitializeComponent();
            manager = new ExerciseManager();
            PopulateListBox();
        }

        private void PopulateListBox()
        {
            foreach(Exercise exercise in manager.GetExerciseList())
            {
                lstbExercises.Items.Add(exercise.ToString());

            }
        }

        private void btnAddWorkout_Click(object sender, EventArgs e)
        {

        }
    }
}
