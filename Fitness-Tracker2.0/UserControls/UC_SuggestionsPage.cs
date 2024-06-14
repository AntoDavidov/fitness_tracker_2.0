using ExerciseLibrary;
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

namespace Fitness_Tracker2._0.UserControls
{
    public partial class UC_SuggestionsPage : UserControl
    {
        private frmTrainerWorkoutCreationPage _workoutCreationPage;
        private ExerciseManager _manager;
        private WorkoutManager _workoutManager;
        private List<Exercise> selectedExercises;
        private Workouts currentWorkout;
        public UC_SuggestionsPage(ExerciseManager exerciseManager, WorkoutManager workoutManager)
        {
            InitializeComponent();
            _manager = exerciseManager;
            _workoutManager = workoutManager;
            _workoutCreationPage = new frmTrainerWorkoutCreationPage(currentWorkout, _manager, _workoutManager);
            PopulateListBox();
        }

        private void PopulateListBox()
        {
            lstbWorkout.Items.Clear();
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
        private void lstbWorkout_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void txtbSeachName_TextChanged(object sender, EventArgs e)
        {


        }

        private void btnCreateWorkout_Click(object sender, EventArgs e)
        {
            string name = txtName.Text;
            string description = rchtxtbDescription.Text;
            Level level = (Level)cmbSearchLevel.SelectedIndex;


            Workouts newWorkout = new Workouts(name, description, level);
            _workoutManager.AddWorkoutWithoutExercises(newWorkout);

            txtName.Text = "";
            rchtxtbDescription.Text = "";
        }



        private void btnSearch_Click(object sender, EventArgs e)
        {
            string searchName = txtbSeachName.Text;
            string levelText = cmbSearchLevel.Text;

            int? level = null;
            if (!string.IsNullOrEmpty(levelText))
            {
                if (Enum.TryParse(typeof(Level), levelText, out var result))
                {
                    level = (int)result;
                }
            }

            List<Workouts> workouts = _workoutManager.SearchWorkouts(searchName, level);
            if (string.IsNullOrEmpty(searchName))
            {
                MessageBox.Show("Please enter a name to search.");
                return;
            }

            if (workouts.Count > 0)
            {
                lstbWorkout.Items.Clear();
                foreach (Workouts workout in workouts)
                {
                    lstbWorkout.Items.Add($"{workout.GetId()}: {workout.GetName()}");
                }
            }
            else
            {
                MessageBox.Show("No workouts found with the given name and level.");
            }
            txtbSeachName.Text = "";
            cmbSearchLevel.SelectedIndex = -1; // Reset the ComboBox
        }

        private void btnEditWorkout_Click_1(object sender, EventArgs e)
        {
            if (lstbWorkout.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a workout to edit.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string selectedWorkoutInfo = lstbWorkout.SelectedItem.ToString();
            string[] parts = selectedWorkoutInfo.Split(":");

            if (int.TryParse(parts[0], out int id))
            {
                Workouts selectedWorkout = _workoutManager.GetWorkoutById(id);

                // Pass the selected workout to the _workoutCreationPage
                _workoutCreationPage = new frmTrainerWorkoutCreationPage(selectedWorkout, _manager, _workoutManager);
                _workoutCreationPage.Show();
            }
            else
            {
                MessageBox.Show("Invalid workout ID format.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDeleteWorkout_Click(object sender, EventArgs e)
        {
            if (lstbWorkout.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a workout to delete.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string selectedWorkoutInfo = lstbWorkout.SelectedItem.ToString();
            string[] parts = selectedWorkoutInfo.Split(":");

            if (int.TryParse(parts[0], out int id))
            {
                Workouts selectedWorkout = _workoutManager.GetWorkoutById(id);

                DialogResult result = MessageBox.Show("Are you sure you want to delete this workout?", "Confirm Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    _workoutManager.DeleteWorkout(selectedWorkout);
                    lstbWorkout.Items.RemoveAt(lstbWorkout.SelectedIndex);
                }
            }
            else
            {
                MessageBox.Show("Invalid workout ID format.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



    }
}
