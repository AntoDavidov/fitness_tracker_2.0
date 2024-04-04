using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExerciseLibrary
{
    public class Strength : Exercise
    {
        private int reps;
        private int sets;
        private double weightLifted;
        private MuscleGroup muscleGroup;
        public Strength(int id, string name, string description, MuscleGroup muscleGroup, int reps, int sets, double weight) : base(id, name, description) 
        { 
            this.reps = reps;
            this.sets = sets;
            this.weightLifted = weight;
            this.muscleGroup = muscleGroup;
        }
        public Strength(string name, string description, MuscleGroup muscleGroup, int reps, int sets, double weight) : base(name, description) 
        { 
            this.reps = reps;
            this.sets = sets;
            this.weightLifted = weight;
            this.muscleGroup = muscleGroup;
        }
        public int GetReps() {  return reps; }
        public int GetSets() { return sets; }
        public double GetWeight() { return weightLifted; }
        public MuscleGroup GetMuscleGroup() { return muscleGroup; }
        public override string ToString()
        {
            return base.ToString() + $"Primary muscle: {muscleGroup}";
        }
        public override int CalculateCaloriesBurned(double userWeight)
        {
            int caloriesPerRep = 2;
            int totalReps = reps * sets;
            double caloriesBurnedPerRep = caloriesPerRep * (weightLifted / 100); //kilograms
            int totalCaloriesBurned = (int)(totalReps * caloriesBurnedPerRep);
            return totalCaloriesBurned;
        }
    }
}
