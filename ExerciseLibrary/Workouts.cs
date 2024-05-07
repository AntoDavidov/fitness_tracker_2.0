using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExerciseLibrary
{
    public class Workouts
    {
        private int id;
        private string name;
        private string description;
        private List<Exercise> exercises;

        public Workouts(int id, string name, string description)
        {
            this.id = id;
            this.name = name;
            this.description = description;
            exercises = new List<Exercise>();
        }
        public int GetId() { return id; }
        public string GetName() { return name; }
        public string GetDescription() { return description; }
        public List<Exercise> GetExercises()
        {
            return exercises;
        }



    }
}
