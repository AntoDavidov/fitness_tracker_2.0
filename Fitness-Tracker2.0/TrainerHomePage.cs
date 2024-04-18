using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ExerciseLibrary;
using ManagerLibrary;

namespace Fitness_Tracker2._0
{
    public partial class frmTrainerHomePage : Form
    {
        private ExerciseManager exerciseManager;
        public frmTrainerHomePage()
        {
            InitializeComponent();
            exerciseManager = new ExerciseManager();
            //PopulateListBox();

        }
        //public void PopulateListBox()
        //{
        //    listBox1.Items.Clear();
        //    List<Exercise> exercises = exerciseManager.GetExercises();
        //    foreach (Exercise ex in exercises)
        //    {
        //        listBox1.Items.Add(ex.ToString());
        //    }
        //}

        private void btnCreate_Click(object sender, EventArgs e)
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
                exerciseManager.AddStrengthExercise(newStrength);
                MessageBox.Show("Exercise created successfully!");
            }
            else
            {
                MessageBox.Show("Invalid muscle group selected!");
            }
            //PopulateListBox();

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
        //    if (listBox1.SelectedIndex >= 0)
        //    {
        //        string selectedExercise = listBox1.SelectedItem.ToString();
        //        string[] parts = selectedExercise.Split(':');

        //        if (int.TryParse(parts[0], out int id))
        //        {
        //            exerciseManager.DeleteExercise(id);
        //            PopulateListBox();
        //        }
        //        else
        //        {
        //            MessageBox.Show("Invalid exercise ID format.");
        //        }
        //    }
        //    else
        //    {
        //        MessageBox.Show("Please select an exercise to delete.");
        //    }
        }
    }
}
