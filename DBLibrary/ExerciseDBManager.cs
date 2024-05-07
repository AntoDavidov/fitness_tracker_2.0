using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using ExerciseLibrary;


namespace DBLibrary
{
    public class ExerciseDBManager : DBDal
    {

        public ExerciseDBManager()
        {

        }

        public bool AddStrengthExerciseToDB(Strength strength)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Insert into Exercise table
                    string insertExerciseQuery = "INSERT INTO Exercise ([name], [description]) VALUES (@Name, @Description); SELECT SCOPE_IDENTITY();";
                    SqlCommand insertExerciseCommand = new SqlCommand(insertExerciseQuery, connection);
                    insertExerciseCommand.Parameters.AddWithValue("@Name", strength.GetName());
                    insertExerciseCommand.Parameters.AddWithValue("@Description", strength.GetDescription());
                    int exerciseId = Convert.ToInt32(insertExerciseCommand.ExecuteScalar());

                    // Insert into StrengthExercise table
                    string insertStrengthExerciseQuery = "INSERT INTO StrengthExercise ([exercise_id], [muscle], [repetitions], [sets], [weight]) " +
                                                          "VALUES (@ExerciseId, @Muscle, @Repetitions, @Sets, @Weight);";
                    SqlCommand insertStrengthExerciseCommand = new SqlCommand(insertStrengthExerciseQuery, connection);
                    insertStrengthExerciseCommand.Parameters.AddWithValue("@ExerciseId", exerciseId);
                    insertStrengthExerciseCommand.Parameters.AddWithValue("@Muscle", strength.GetMuscleGroup().ToString());
                    insertStrengthExerciseCommand.Parameters.AddWithValue("@Repetitions", strength.GetReps());
                    insertStrengthExerciseCommand.Parameters.AddWithValue("@Sets", strength.GetSets());
                    insertStrengthExerciseCommand.Parameters.AddWithValue("@Weight", strength.GetWeight());
                    insertStrengthExerciseCommand.ExecuteNonQuery();

                }
                Console.WriteLine("Exercise added successfully.");
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                return false;
            }
        }
        public bool AddCardioExerciseToDB(Cardio cardio)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Insert into Exercise table
                    string insertExerciseQuery = "INSERT INTO Exercise ([name], [description]) VALUES (@Name, @Description); SELECT SCOPE_IDENTITY();";
                    SqlCommand insertExerciseCommand = new SqlCommand(insertExerciseQuery, connection);
                    insertExerciseCommand.Parameters.AddWithValue("@Name", cardio.GetName());
                    insertExerciseCommand.Parameters.AddWithValue("@Description", cardio.GetDescription());
                    int exerciseId = Convert.ToInt32(insertExerciseCommand.ExecuteScalar());

                    string insertCardioExerciseQuery = "INSERT INTO CardioExercise ([exercise_id], [duration]) VALUES (@ExerciseId, @Duration);";
                    SqlCommand insertCardioExerciseCommand = new SqlCommand(insertCardioExerciseQuery, connection);
                    insertCardioExerciseCommand.Parameters.AddWithValue("@ExerciseId", exerciseId);
                    insertCardioExerciseCommand.Parameters.AddWithValue("@Duration", cardio.GetDuration().ToString(@"hh\:mm\:ss"));
                    insertCardioExerciseCommand.ExecuteNonQuery();
                }
                Console.WriteLine("Cardio exercise added successfully.");
                return true;
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
        public bool AddWorkoutToDB(Workouts workout)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Insert into Workout table
                    string insertWorkoutQuery = "INSERT INTO Workout (Name, Description) VALUES (@Name, @Description); SELECT SCOPE_IDENTITY();";
                    SqlCommand insertWorkoutCommand = new SqlCommand(insertWorkoutQuery, connection);
                    insertWorkoutCommand.Parameters.AddWithValue("@Name", workout.GetName());
                    insertWorkoutCommand.Parameters.AddWithValue("@Description", workout.GetDescription());
                    int workoutId = Convert.ToInt32(insertWorkoutCommand.ExecuteScalar());

                    // Insert into WorkoutExercise table for each exercise in the workout
                    foreach (var exercise in workout.GetExercises())
                    {
                        string insertWorkoutExerciseQuery = "INSERT INTO WorkoutExercise (WorkoutId, ExerciseId) VALUES (@WorkoutId, @ExerciseId);";
                        SqlCommand insertWorkoutExerciseCommand = new SqlCommand(insertWorkoutExerciseQuery, connection);
                        insertWorkoutExerciseCommand.Parameters.AddWithValue("@WorkoutId", workoutId);
                        insertWorkoutExerciseCommand.Parameters.AddWithValue("@ExerciseId", exercise.GetId());
                        insertWorkoutExerciseCommand.ExecuteNonQuery();
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                return false;
            }
        }
        public bool DeleteExercise(int id)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Delete from Exercise table
                    var query = "DELETE FROM Exercise WHERE id=@id";
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("id", id);
                        cmd.ExecuteNonQuery();
                    }

                    // Delete from specific exercise type table (e.g., StrengthExercise)
                    query = "DELETE FROM StrengthExercise WHERE id=@id";
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("id", id);
                        cmd.ExecuteNonQuery();
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public List<Cardio> GetCardioExercises()
        {
            List<Cardio> cardioExercises = new List<Cardio>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string query = "SELECT * FROM Exercise JOIN CardioExercise ON Exercise.id = CardioExercise.exercise_id";

                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                int id = reader.GetInt32(reader.GetOrdinal("id"));
                                string name = reader.GetString(reader.GetOrdinal("name"));
                                string description = reader.GetString(reader.GetOrdinal("description"));
                                TimeSpan duration = reader.GetTimeSpan(reader.GetOrdinal("duration"));

                                Cardio cardioExercise = new Cardio(id, name, description, duration);
                                cardioExercises.Add(cardioExercise);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }

            return cardioExercises;
        }
        public List<Strength> GetStrengthExercises()
        {
            List<Strength> strengthExercises = new List<Strength>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string query = "SELECT * FROM Exercise JOIN StrengthExercise ON Exercise.id = StrengthExercise.exercise_id";

                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                int id = reader.GetInt32(reader.GetOrdinal("id"));
                                string name = reader.GetString(reader.GetOrdinal("name"));
                                string description = reader.GetString(reader.GetOrdinal("description"));
                                string muscleGroupString = reader.GetString(reader.GetOrdinal("muscle"));
                                MuscleGroup muscleGroup = (MuscleGroup)Enum.Parse(typeof(MuscleGroup), muscleGroupString);

                                int repetitions = reader.GetInt32(reader.GetOrdinal("repetitions"));
                                int sets = reader.GetInt32(reader.GetOrdinal("sets"));
                                double weight = reader.GetDouble(reader.GetOrdinal("weight"));

                                Strength strengthExercise = new Strength(id, name, description, muscleGroup, repetitions, sets, weight);
                                strengthExercises.Add(strengthExercise);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }

            return strengthExercises;
        }

    }



}








