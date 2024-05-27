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
            MuscleGroup muscleGroup;
            int reps = Convert.ToInt32(nmudReps.Value);
            int sets = Convert.ToInt32(nmudSets.Value);
            double weight = Convert.ToDouble(nmudWeight.Value);

            if (Enum.TryParse(cmbMuscle.Text, out muscleGroup))
            {
                Strength newStrength = new Strength(name, description, muscleGroup, reps, sets, weight);
                _exerciseManager.AddExercise(newStrength);
                MessageBox.Show("Exercise created successfully!");
                PopulateExerciseListbox();
            }
            else
            {
                MessageBox.Show("Invalid muscle group selected!");
            }
        }
        private void PopulateExerciseListbox()
        {
            lstbExercises.Items.Clear();
            foreach (Strength strengthExercise in _exerciseManager.GetOnlyStrengthExercises())
            {
                lstbExercises.Items.Add(strengthExercise.ToString());
            }
        }

        private void btnDeleteExercise_Click(object sender, EventArgs e)
        {
            if (lstbExercises.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a strenght exercise to delete.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Strength selectedStrength = _exerciseManager.GetOnlyStrengthExercises()[lstbExercises.SelectedIndex];
            DialogResult result = MessageBox.Show("Are you sure you want to delete this exercise? The selected exercise is going to be removed from" +
                "every workout that is associated with!", "Confirm Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                _exerciseManager.DeleteExercise(selectedStrength);
                lstbExercises.Items.Remove(lstbExercises.SelectedIndex);
                PopulateExerciseListbox();
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string searchingString = txtbSearch.Text.ToLower();
            lstbExercises.Items.Clear();
            foreach (Strength strength in _exerciseManager.GetOnlyStrengthExercises())
            {
                if (strength.GetName().ToLower().StartsWith(searchingString))
                {
                    lstbExercises.Items.Add(strength.ToString());
                }
            }
        }

        private void UC_StrengthPage_Load(object sender, EventArgs e)
        {

        }
    }
}
