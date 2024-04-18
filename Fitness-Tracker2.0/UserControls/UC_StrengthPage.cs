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
        private ExerciseManager exerciseManager;
        public UC_StrengthPage()
        {
            exerciseManager = new ExerciseManager();
            InitializeComponent();
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
                exerciseManager.AddStrengthExercise(newStrength);
                MessageBox.Show("Exercise created successfully!");
            }
            else
            {
                MessageBox.Show("Invalid muscle group selected!");
            }
        }
    }
}
