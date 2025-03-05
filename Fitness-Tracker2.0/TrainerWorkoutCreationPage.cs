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
        private WorkoutManager workoutManager;
        private Workouts currentWorkout;
        private Exercise selectedEx;

        public frmTrainerWorkoutCreationPage(Workouts workouts, ExerciseManager _exerciseManager, WorkoutManager _workoutManager)
        {
            InitializeComponent();
            this.exerciseManager = _exerciseManager;
            this.workoutManager = _workoutManager;
            cmbFilter.SelectedIndexChanged += cmbFilter_SelectedIndexChanged;
            currentWorkout = workouts;
            PopulateExercisesListBox();
            PopulateWorkoutExercisesListBox();
            PopulateLabel();

            lstbExercises.AllowDrop = true;
            lstbCurrentWorkoutExercises.AllowDrop = true;

            lstbExercises.MouseDown += lstbExercises_MouseDown;
            lstbCurrentWorkoutExercises.DragEnter += lstbCurrentWorkoutExercises_DragEnter;
            lstbCurrentWorkoutExercises.DragDrop += lstbExercises_DragDrop;
            //btnRemoveExercise.Click += btnRemoveExercise_Click;
        }

        private void PopulateExercisesListBox()
        {
            
        }

        private void PopulateWorkoutExercisesListBox()
        {
            lstbCurrentWorkoutExercises.Items.Clear();
            if (currentWorkout != null)
            {
                foreach (Exercise exercise in workoutManager.GetCurrentWorkoutExercises(currentWorkout))
                {
                    lstbCurrentWorkoutExercises.Items.Add(exercise.ToString());
                }
            }
        }

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

        private void lstbExercises_MouseDown(object sender, MouseEventArgs e)
        {
            if (lstbExercises.SelectedItem != null)
            {
                // Start drag and drop operation
                lstbExercises.DoDragDrop(lstbExercises.SelectedItem.ToString(), DragDropEffects.Copy);
            }
        }

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
            if (currentWorkout != null && workoutManager.ExerciseExistsInWorkout(currentWorkout, exercise))
            {
                MessageBox.Show("This exercise is already added to the workout.", "Duplicate Exercise", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // If the exercise doesn't exist in the workout, add it
            if (currentWorkout != null)
            {
                workoutManager.AddExerciseToWorkout(currentWorkout, exercise);
                PopulateWorkoutExercisesListBox();
            }
        }

        private void lstbExercises_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cmbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            PopulateExercisesListBox();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnRemoveExercise_Click(object sender, EventArgs e)
        {
            if (lstbCurrentWorkoutExercises.SelectedItem == null)
            {
                MessageBox.Show("Please select an exercise to remove.", "No Exercise Selected", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;


            }
            string ex = lstbCurrentWorkoutExercises.SelectedItem.ToString();
            int id = Convert.ToInt32(ex.Split(":")[0]);
            Exercise exercise = exerciseManager.GetExerciseById(id);

            if (currentWorkout != null)
            {
                workoutManager.RemoveExerciseFromWorkout(currentWorkout, exercise);
                PopulateWorkoutExercisesListBox();
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string searchName = textBox1.Text;
            string exerciseType = null;

            if(cmbFilter.SelectedIndex == -1) 
            {
                MessageBox.Show("Please select a type of exercise to search from.");
            }
            else if (cmbFilter.SelectedIndex == 0)
            {
                exerciseType = "Strength";
            }
            else if (cmbFilter.SelectedIndex == 1)
            {
                exerciseType = "Cardio";
            }

            List<Exercise> exercises = exerciseManager.SearchExercisesByTypeAndName(exerciseType, searchName);

            lstbExercises.Items.Clear();
            foreach (Exercise exercise in exercises)
            {
                lstbExercises.Items.Add($"{exercise.GetId()}: {exercise.GetName()}");
            }

            textBox1.Text = "";
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            lstbExercises.Items.Clear ();
        }
    }

}
