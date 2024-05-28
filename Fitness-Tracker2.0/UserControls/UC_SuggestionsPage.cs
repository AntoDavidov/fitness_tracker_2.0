﻿using ExerciseLibrary;
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
            foreach (Workouts workout in _workoutManager.GetWorkouts())
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
            _workoutManager.AddWorkoutWithoutExercises(newWorkout);

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

            Workouts selectedWorkout = _workoutManager.GetWorkouts()[lstbWorkout.SelectedIndex];

            // Pass the selected workout to the _workoutCreationPage
            _workoutCreationPage = new frmTrainerWorkoutCreationPage(selectedWorkout, _manager, _workoutManager);
            _workoutCreationPage.Show();
        }

        private void txtbSeachName_TextChanged(object sender, EventArgs e)
        {
            string searchText = txtbSeachName.Text.ToLower();

            lstbWorkout.Items.Clear();

            foreach (Workouts workout in _workoutManager.GetWorkouts())
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

            Workouts selectedWorkout = _workoutManager.GetWorkouts()[lstbWorkout.SelectedIndex];

            DialogResult result = MessageBox.Show("Are you sure you want to delete this workout?", "Confirm Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                _workoutManager.DeleteWorkout(selectedWorkout);
                lstbWorkout.Items.RemoveAt(lstbWorkout.SelectedIndex);

            }
        }
    }
}
