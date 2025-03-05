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

namespace Fitness_Tracker2._0
{
    public partial class frmTrainerWorkoutCreationPage : Form
    {
        private ExerciseManager exerciseManager;
        private Workouts currentWorkout;
        private Exercise selectedEx;

        public frmTrainerWorkoutCreationPage(Workouts workouts)
        {
            InitializeComponent();
            exerciseManager = new ExerciseManager();
            cmbFilter.SelectedIndexChanged += cmbFilter_SelectedIndexChanged;
            currentWorkout = workouts;
            PopulateExercisesListBox();
            PopulateWorkoutExercisesListBox();
            PopulateLabel();

            // Enable drag and drop for the list boxes
            lstbExercises.AllowDrop = true;
            lstbCurrentWorkoutExercises.AllowDrop = true;

            // Add event handlers for drag and drop events
            lstbExercises.MouseDown += lstbExercises_MouseDown;
            lstbCurrentWorkoutExercises.DragEnter += lstbCurrentWorkoutExercises_DragEnter;
            lstbCurrentWorkoutExercises.DragDrop += lstbExercises_DragDrop;
        }

        // Populate exercises list box
        private void PopulateExercisesListBox()
        {
            // Populate exercises list box with available exercises
            lstbExercises.Items.Clear();
            if (cmbFilter.SelectedIndex == 0)
            {
                foreach (Strength strengthExercise in exerciseManager.GetOnlyStrengthExercises())
                {
                    lstbExercises.Items.Add(strengthExercise.ToString()); // Add the object itself, not the ToString() representation
                }
            }
            else if (cmbFilter.SelectedIndex == 1)
            {
                foreach (Cardio cardioExercise in exerciseManager.GetOnlyCardioExercises())
                {
                    lstbExercises.Items.Add(cardioExercise.ToString()); // Add the object itself, not the ToString() representation
                }
            }
        }

        // Populate workout exercises list box
        private void PopulateWorkoutExercisesListBox()
        {
            // Populate workout exercises list box with exercises in current workout
            lstbCurrentWorkoutExercises.Items.Clear();
            if (currentWorkout != null)
            {
                foreach (Exercise exercise in exerciseManager.GetCurrentWorkoutExercises(currentWorkout))
                {
                    lstbCurrentWorkoutExercises.Items.Add(exercise.ToString());
                }
            }
        }

        // Populate label with workout name
        private void PopulateLabel()
        {
            if (currentWorkout != null)
            {
                lblWorkoutName.Text = currentWorkout.GetName();
            }
            else
            {
                lblWorkoutName.Text = "";
            }
        }

        // Handle mouse down event for the available exercises list box
        private void lstbExercises_MouseDown(object sender, MouseEventArgs e)
        {
            if (lstbExercises.SelectedItem != null)
            {
                // Start drag and drop operation
                lstbExercises.DoDragDrop(lstbExercises.SelectedItem.ToString(), DragDropEffects.Copy);
            }
        }

        // Handle drag enter event for the workout exercises list box
        private void lstbCurrentWorkoutExercises_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Text))
            {
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }

        }
        private void lstbExercises_DragDrop(object sender, DragEventArgs e)
        {
            lstbExercises.DataSource = null;
            string ex = (string)e.Data.GetData(DataFormats.Text);
            int id = Convert.ToInt32(ex.Split(":")[0]);
            Exercise exercise = exerciseManager.GetExerciseById(id);

            // Check if the exercise already exists in the workout
            if (currentWorkout != null && exerciseManager.ExerciseExistsInWorkout(currentWorkout, exercise))
            {
                MessageBox.Show("This exercise is already added to the workout.", "Duplicate Exercise", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // If the exercise doesn't exist in the workout, add it
            if (currentWorkout != null)
            {
                exerciseManager.AddExerciseToWorkout(currentWorkout, exercise);
                PopulateWorkoutExercisesListBox();
            }
        }

        private void lstbExercises_SelectedIndexChanged(object sender, EventArgs e)
        {
            // You can handle selection change event if needed
        }

        private void cmbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            PopulateExercisesListBox();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }

}
