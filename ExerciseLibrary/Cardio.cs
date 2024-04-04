using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExerciseLibrary
{
    class Cardio : Exercise
    {
        private TimeSpan duration;
        private string equipment;


        public Cardio(int id, string name, string description, TimeSpan duriation, string equipment) : base(id, name, description) 
        {
            this.duration = duriation;
            this.equipment = equipment;
        }
        
        public override string ToString()
        {
            return base.ToString() + $"Duriation: {duration}";
        }
        public override int CalculateCaloriesBurned(double userWeight)
        {
            double basalMetabolicRate = 10 * userWeight;
            double totalHours = duration.TotalHours;
            int totalCaloriesBurned = (int)(basalMetabolicRate * totalHours);
            return totalCaloriesBurned;
        }
    }
}
