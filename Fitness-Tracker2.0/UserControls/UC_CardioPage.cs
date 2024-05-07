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
    public partial class ucCardioPage : UserControl
    {
        private ExerciseManager exerciseManager;
        public ucCardioPage()
        {
            InitializeComponent();
            exerciseManager = new ExerciseManager();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string name = txtbName.Text;
            string description = rchtxtbDescription.Text;

            int hours = Convert.ToInt32(nudHours.Value);
            int minutes = Convert.ToInt32(nudMinutes.Value);
            int seconds = Convert.ToInt32(nudSeconds.Value);

            Console.WriteLine($"Selected values: Hours = {hours}, Minutes = {minutes}, Seconds = {seconds}");

            // Create TimeSpan from converted values
            TimeSpan duration = new TimeSpan(hours, minutes, seconds);

            // Log or display the TimeSpan for debugging
            Console.WriteLine($"Duration: {duration}");

            Cardio newCardioEx = new Cardio(name, description, duration);
            exerciseManager.AddCardioExercise(newCardioEx);

        }
    }
}
