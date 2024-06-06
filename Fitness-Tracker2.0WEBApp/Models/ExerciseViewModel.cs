namespace Fitness_Tracker2._0WEBApp.Models
{
    public class ExerciseViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsCompleted { get; set; }

        public ExerciseViewModel(int id, string name)
        {
            Id = id;
            Name = name;
            IsCompleted = false;
        }
    }
}
