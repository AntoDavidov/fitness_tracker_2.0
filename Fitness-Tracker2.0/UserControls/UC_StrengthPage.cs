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
    public partial class UC_StrengthPage : UserControl
    {
        private ExerciseManager _exerciseManager;
        public UC_StrengthPage(ExerciseManager exerciseManager)
        {
            InitializeComponent();
            _exerciseManager = exerciseManager;
            PopulateExerciseListbox();
        }

        private void btnAddExercise_Click(object sender, EventArgs e)
        {
            string name = txtbName.Text;
            string description = rchtxtbDescription.Text;

            if (tabControl1.SelectedTab == tabPage1)
            {
                if (ValidateStrengthInputs(out MuscleGroup muscleGroup, out int reps, out int sets, out double weight))
                {
                    AddStrengthExercise(name, description, muscleGroup, reps, sets, weight);
                }
            }
            else if (tabControl1.SelectedTab == tabPage2)
            {
                if (ValidateCardioInputs(out int hours, out int minutes, out int seconds))
                {
                    AddCardioExercise(name, description, hours, minutes, seconds);
                }
            }
        }
        private bool ValidateStrengthInputs(out MuscleGroup muscleGroup, out int reps, out int sets, out double weight)
        {
            muscleGroup = default;
            reps = Convert.ToInt32(nmudReps.Value);
            sets = Convert.ToInt32(nmudSets.Value);
            weight = Convert.ToDouble(nmudWeight.Value);

            if (!Enum.TryParse(cmbMuscle.Text, out muscleGroup))
            {
                MessageBox.Show("Invalid muscle group selected!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (reps == 0 && sets == 0 && weight == 0)
            {
                MessageBox.Show("At least one of Reps, Sets, or Weight must be inputted with a number.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        private bool ValidateCardioInputs(out int hours, out int minutes, out int seconds)
        {
            hours = Convert.ToInt32(nudHours.Value);
            minutes = Convert.ToInt32(nudMinutes.Value);
            seconds = Convert.ToInt32(nudSeconds.Value);

            if (hours == 0 && minutes == 0 && seconds == 0)
            {
                MessageBox.Show("At least one of Hours, Minutes, or Seconds must be inputted with a number.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        private void AddStrengthExercise(string name, string description, MuscleGroup muscleGroup, int reps, int sets, double weight)
        {
            Exercise newStrength = new Strength(name, description, muscleGroup, reps, sets, weight);
            _exerciseManager.AddExercise(newStrength);
            MessageBox.Show("Strength exercise created successfully!");
            PopulateExerciseListbox();
        }

        private void AddCardioExercise(string name, string description, int hours, int minutes, int seconds)
        {
            TimeSpan duration = new TimeSpan(hours, minutes, seconds);
            Exercise newCardio = new Cardio(name, description, duration);
            _exerciseManager.AddExercise(newCardio);
            MessageBox.Show("Cardio exercise created successfully!");
            PopulateExerciseListbox();
        }

        private void PopulateExerciseListbox()
        {
            lstbExercises.Items.Clear();

        }

        private void btnDeleteExercise_Click(object sender, EventArgs e)
        {
            if (lstbExercises.SelectedIndex == -1)
            {
                MessageBox.Show("Please select an exercise to delete.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string selectedExerciseInfo = lstbExercises.SelectedItem.ToString();
            string[] parts = selectedExerciseInfo.Split(':');

            if (int.TryParse(parts[0], out int id))
            {
                Exercise selectedExercise = _exerciseManager.GetExerciseById(id);
                if (selectedExercise != null)
                {
                    DialogResult result = MessageBox.Show("Are you sure you want to delete this exercise? The selected exercise will be removed from every workout that is associated with it.", "Confirm Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        _exerciseManager.DeleteExercise(selectedExercise);
                        PopulateExerciseListbox();
                        MessageBox.Show("Exercise deleted successfully!");
                    }
                }
                else
                {
                    MessageBox.Show("Exercise not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Invalid exercise ID format.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string searchName = txtbSearch.Text.ToLower();
            List<Exercise> exercises = _exerciseManager.SearchExercisesByName(searchName);
            if (string.IsNullOrEmpty(searchName))
            {
                MessageBox.Show("Please enter a name to search.");
                return;
            }
            if (exercises.Count > 0)
            {
                lstbExercises.Items.Clear();
                foreach (Exercise ex in exercises)
                {
                    lstbExercises.Items.Add($"{ex.GetId()}: {ex.GetName()}");
                }
            }
            else
            {
                MessageBox.Show("No exercises found with the given name.");
            }
            txtbSearch.Text = "";
        }

        private void rchtxtbDescription_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            lstbExercises.Items.Clear();
        }
    }
}
