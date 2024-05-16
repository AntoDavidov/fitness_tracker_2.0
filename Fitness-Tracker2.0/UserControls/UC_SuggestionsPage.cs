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
        private frmTrainerWorkoutCreationPage _workoutCreationPage;
        private ExerciseManager manager;
        private List<Exercise> selectedExercises;
        private Workouts currentWorkout;
        public UC_SuggestionsPage()
        {
            InitializeComponent();
            manager = new ExerciseManager();
            _workoutCreationPage = new frmTrainerWorkoutCreationPage(currentWorkout);
            PopulateListBox();
        }

        private void PopulateListBox()
        {
            foreach (Workouts workout in manager.GetWorkouts())
            {
                lstbWorkout.Items.Add(workout.ToString());
            }
        }

        private void btnEditWorkout_Click(object sender, EventArgs e)
        {
            //string name = txtbName.Text;
            //string description = rchtxtbDescription.Text;


        }

        private void lstbExercises_SelectedIndexChanged(object sender, EventArgs e)
        {
            //selectedExercises.Clear();
            //foreach (var item in lstbExercises.SelectedItems)
            //{
            //    Retrieve the Exercise object from the ListBox
            //    //var exercise = manager.GetExerciseByName(item.ToString());
            //    if (exercise != null)
            //    {
            //        selectedExercises.Add(exercise);
            //    }
            //}
        }

        private void btnCreateWorkout_Click(object sender, EventArgs e)
        {
            string name = txtName.Text;
            string description = rchtxtbDescription.Text;
            string level = cmbLevel.Text;


            Workouts newWorkout = new Workouts(name, description, level);
            manager.AddWorkoutWithoutExercises(newWorkout);

            txtName.Text = "";
            rchtxtbDescription.Text = "";
        }

        private void lstbWorkout_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnEditWorkout_Click_1(object sender, EventArgs e)
        {
            if (lstbWorkout.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a workout to edit.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Workouts selectedWorkout = manager.GetWorkouts()[lstbWorkout.SelectedIndex];

            // Pass the selected workout to the _workoutCreationPage
            _workoutCreationPage = new frmTrainerWorkoutCreationPage(selectedWorkout);
            _workoutCreationPage.Show();
        }

        private void txtbSeachName_TextChanged(object sender, EventArgs e)
        {
            string searchText = txtbSeachName.Text.ToLower();

            lstbWorkout.Items.Clear();

            foreach (Workouts workout in manager.GetWorkouts())
            {
                if (workout.GetName().ToLower().StartsWith(searchText))
                {
                    lstbWorkout.Items.Add(workout.ToString());
                }
            }

        }

        private void btnDeleteWorkout_Click(object sender, EventArgs e)
        {
            if (lstbWorkout.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a workout to delete.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Workouts selectedWorkout = manager.GetWorkouts()[lstbWorkout.SelectedIndex];

            DialogResult result = MessageBox.Show("Are you sure you want to delete this workout?", "Confirm Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                manager.DeleteWorkout(selectedWorkout);
                lstbWorkout.Items.RemoveAt(lstbWorkout.SelectedIndex);

            }
        }
    }
}
