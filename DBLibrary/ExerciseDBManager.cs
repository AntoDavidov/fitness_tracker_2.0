using System;
using System.Collections.Generic;
using System.Data;
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
        public bool AddWorkoutToDBWithoutExercises(Workouts workout)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Insert into Workout table
                    string insertWorkoutQuery = "INSERT INTO Workout (Name, Description, workout_level) VALUES (@Name, @Description, @WorkoutLevel); SELECT SCOPE_IDENTITY();";
                    SqlCommand insertWorkoutCommand = new SqlCommand(insertWorkoutQuery, connection);
                    insertWorkoutCommand.Parameters.AddWithValue("@Name", workout.GetName());
                    insertWorkoutCommand.Parameters.AddWithValue("@Description", workout.GetDescription());
                    insertWorkoutCommand.Parameters.AddWithValue("@WorkoutLevel", workout.GetWorkoutLevel());
                    int workoutId = Convert.ToInt32(insertWorkoutCommand.ExecuteScalar());
                }
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                return false;
            }
        }
        public void AddExerciseToWorkout(int workoutId, int exerciseId)
        {
            using SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                
                {
                    using SqlCommand sqlCommand = connection.CreateCommand();
                    sqlCommand.CommandText = "INSERT INTO WorkoutExercise (WorkoutId, ExerciseId)" +
                        "VALUES (@WorkoutId, @ExerciseId);";
                    sqlCommand.Parameters.AddWithValue("@WorkoutId", workoutId);
                    sqlCommand.Parameters.AddWithValue("@ExerciseId", exerciseId);
                    connection.Open();
                    sqlCommand.ExecuteNonQuery();
                }
            }
            catch (Exception ex) 
            {
                throw new Exception($"Unable to add an exercise to the desired workout: {ex}");
            }
            finally
            {
                if (connection.State != ConnectionState.Closed)
                    connection.Close();
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
        public Exercise? GetExerciseById(int exerciseId)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Check if the exercise exists in the CardioExercise table
                    string cardioQuery = "SELECT TOP 1 * FROM CardioExercise WHERE exercise_id = @ExerciseId";
                    SqlCommand cardioCmd = new SqlCommand(cardioQuery, connection);
                    cardioCmd.Parameters.AddWithValue("@ExerciseId", exerciseId);

                    using (SqlDataReader cardioReader = cardioCmd.ExecuteReader())
                    {
                        if (cardioReader.Read())
                        {
                            // If a record is found, it's a cardio exercise
                            Cardio cardioExercise = GetCardioExerciseById(exerciseId);
                            return cardioExercise;
                        }
                    }

                    // Check if the exercise exists in the StrengthExercise table
                    string strengthQuery = "SELECT TOP 1 * FROM StrengthExercise WHERE exercise_id = @ExerciseId";
                    SqlCommand strengthCmd = new SqlCommand(strengthQuery, connection);
                    strengthCmd.Parameters.AddWithValue("@ExerciseId", exerciseId);

                    using (SqlDataReader strengthReader = strengthCmd.ExecuteReader())
                    {
                        if (strengthReader.Read())
                        {
                            // If a record is found, it's a strength exercise
                            Strength strengthExercise = GetStrengthExerciseById(exerciseId);
                            return strengthExercise;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }

            return null; // Return null if exercise with the given ID is not found or an error occurs
        }
        public Cardio? GetCardioExerciseById(int exerciseId)
        {
            Cardio cardioExercise = null;

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string query = "SELECT * FROM Exercise JOIN CardioExercise ON Exercise.id = CardioExercise.exercise_id WHERE Exercise.id = @ExerciseId";
                    SqlCommand cmd = new SqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@ExerciseId", exerciseId);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            int id = reader.GetInt32(reader.GetOrdinal("id"));
                            string name = reader.GetString(reader.GetOrdinal("name"));
                            string description = reader.GetString(reader.GetOrdinal("description"));
                            TimeSpan duration = reader.GetTimeSpan(reader.GetOrdinal("duration"));

                            cardioExercise = new Cardio(id, name, description, duration);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }

            return cardioExercise;
        }

        public Strength? GetStrengthExerciseById(int exerciseId)
        {
            Strength strengthExercise = null;

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string query = "SELECT * FROM Exercise JOIN StrengthExercise ON Exercise.id = StrengthExercise.exercise_id WHERE Exercise.id = @ExerciseId";
                    SqlCommand cmd = new SqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@ExerciseId", exerciseId);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            int id = reader.GetInt32(reader.GetOrdinal("id"));
                            string name = reader.GetString(reader.GetOrdinal("name"));
                            string description = reader.GetString(reader.GetOrdinal("description"));
                            string muscleGroupString = reader.GetString(reader.GetOrdinal("muscle"));
                            MuscleGroup muscleGroup = (MuscleGroup)Enum.Parse(typeof(MuscleGroup), muscleGroupString);
                            int repetitions = reader.GetInt32(reader.GetOrdinal("repetitions"));
                            int sets = reader.GetInt32(reader.GetOrdinal("sets"));
                            double weight = reader.GetDouble(reader.GetOrdinal("weight"));

                            strengthExercise = new Strength(id, name, description, muscleGroup, repetitions, sets, weight);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }

            return strengthExercise;
        }
        public Workouts? GetWorkout(Workouts workout)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    using (SqlCommand command = connection.CreateCommand())
                    {
                        command.CommandText =
                            "SELECT Id, Name, Description, workout_level" +
                            "FROM Workout " +
                            "WHERE Name = @name " +
                            "AND Description = @description " +
                            "AND workout_level = @workout_level;";
                        connection.Open();
                        command.Parameters.AddWithValue("@name", workout.GetName());
                        command.Parameters.AddWithValue("@description", workout.GetDescription());
                        command.Parameters.AddWithValue("@workout_level", workout.GetWorkoutLevel());
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            Workouts retrievedWorkout = null;
                            if (reader.HasRows)
                            {
                                while (reader.Read())
                                {
                                    retrievedWorkout = new Workouts(
                                        (int)reader["ID"],
                                        (string)reader["Name"],
                                        (string)reader["Description"],
                                        (string)reader["workout_level"]
                                    );
                                }
                            }
                            return retrievedWorkout;
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception($"Unable to load workout: {ex}");
                }
                finally
                {
                    if (connection.State != ConnectionState.Closed)
                        connection.Close();
                }
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
        public List<Workouts>? GetAllWorkoutsFromDB()
        {
            List<Workouts> workouts = new List<Workouts>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string query = "SELECT * FROM Workout";

                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                int id = reader.GetInt32(reader.GetOrdinal("id"));
                                string name = reader.GetString(reader.GetOrdinal("Name"));
                                string description = reader.GetString(reader.GetOrdinal("Description"));

                                // Create a new Workout object and add it to the list
                                Workouts workout = new Workouts(id, name, description);
                                workouts.Add(workout);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }

            return workouts;
        }
        public List<Cardio>? GetCardioExercises()
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
        public List<Strength>? GetStrengthExercises()
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








