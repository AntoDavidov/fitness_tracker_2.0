using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExerciseLibrary
{
    public abstract class Exercise
    {
        private int id;
        private string name;
        private string description;

        public Exercise(int id, string name, string description)
        {
            this.id = id;
            this.name = name;
            this.description = description;
        }
        public Exercise(string name, string description)
        {
            this.name = name;
            this.description = description;
        }
        public int GetId() { return id; }
        public string GetName() { return name; }
        public string GetDescription() { return description; }
        public virtual string ToString()
        {
            return $"{id}:{name}";
        }
        public abstract int CalculateCaloriesBurned(double userWeight);
    }
}
