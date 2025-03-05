using System;
using System.Collections.Generic;
using NameLibrary;

namespace ExerciseLibrary
{
    public class Workouts
    {
        private int id;
        private string name;
        private string description;
        private Level workout_level;
        private List<Exercise> exercises;

        public Workouts(int id, string name, string description)
        {
            this.id = id;
            this.name = name;
            this.description = description;
            exercises = new List<Exercise>();
        }
        public Workouts(int id, string name, string description, Level workout_level)
        {
            this.id = id;
            this.name = name;
            this.description = description;
            this.workout_level = workout_level;
            exercises = new List<Exercise>();
        }
        public Workouts(string name, string description, Level workout_level)
        {
            this.name = name;
            this.description = description;
            this.workout_level = workout_level;
            exercises = new List<Exercise>();
        }
        public Workouts(string name, string description)
        {
            this.name = name;
            this.description = description;
        }
        public Workouts() { }

        public int GetId() { return id; }
        public string GetName() { return name; }
        public string GetDescription() { return description; }
        public Level GetWorkoutLevel()
        {
            return workout_level;
        }
        public override string ToString()
        {
            return $"{id}: {name}";
        }
        public int CalculateCaloriesBurnedForTheWholeWorkout(Customer customer)
        {
            int totalCalories = 0;
            foreach (var exercise in exercises)
            {
                totalCalories += exercise.CalculateCaloriesBurned(customer);
            }
            return totalCalories;
        }
        public void AddExercise(Exercise exercise)
        {
            exercises.Add(exercise);
        }
        public List<Exercise> GetExercises()
        {
            return exercises;
        }
    }
}
