using NameLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExerciseLibrary
{
    public class Cardio : Exercise
    {
        private TimeSpan duration;

        public Cardio(int id, string name, string description, TimeSpan duriation) : base(id, name, description) 
        {
            this.duration = duriation;
        }
        public Cardio(string name, string description, TimeSpan duriation) : base(name, description)
        {
            this.duration = duriation;
        }

        public TimeSpan GetDuration()
        {
            return duration;
        }
        public override string ToString()
        {
            return base.ToString() + $" Duriation: {duration}";
        }
        public override int CalculateCaloriesBurned(Customer customer)
        {
            double weight = customer.GetWeight();
            int age = customer.GetAge();

            // Using a simplified version of the BMR calculation
            double basalMetabolicRate = 10 * weight - 5 * age;
            double MET = 8;
            double totalHours = duration.TotalHours;
            int totalCaloriesBurned = (int)(basalMetabolicRate * MET * totalHours);
            return totalCaloriesBurned;
        }
    }
}
