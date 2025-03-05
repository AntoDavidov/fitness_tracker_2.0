using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using ExerciseLibrary;
using IRepositories;

namespace DBLibrary
{
    public class ExerciseDBManager : DBDal, IExerciseRepo
    {
        private WorkoutDBManager workoutDBManager;
        public ExerciseDBManager()
        {
        }

        public bool AddStrengthExercise(Strength strength)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(GetConnectionString()))
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
                    insertStrengthExerciseCommand.Parameters.AddWithValue("@Weight", Convert.ToDecimal(strength.GetWeight()));
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

        public bool AddCardioExercise(Cardio cardio)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(GetConnectionString()))
                {
                    connection.Open();

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
       
        public Exercise? GetExerciseById(int exerciseId)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(GetConnectionString()))
                {
                    connection.Open();

                    string cardioQuery = "SELECT TOP 1 * FROM CardioExercise WHERE exercise_id = @ExerciseId";
                    SqlCommand cardioCmd = new SqlCommand(cardioQuery, connection);
                    cardioCmd.Parameters.AddWithValue("@ExerciseId", exerciseId);

                    using (SqlDataReader cardioReader = cardioCmd.ExecuteReader())
                    {
                        if (cardioReader.Read())
                        {
                            Cardio cardioExercise = GetCardioExerciseById(exerciseId);
                            return cardioExercise;
                        }
                    }

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
                using (SqlConnection connection = new SqlConnection(GetConnectionString()))
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
                using (SqlConnection connection = new SqlConnection(GetConnectionString()))
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
                            double weight = Convert.ToDouble(reader.GetDecimal(reader.GetOrdinal("weight")));

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
        
        public void DeleteStrengthExercise(Strength strengthExercise)
        {
            using (SqlConnection connection = new SqlConnection(GetConnectionString()))
            {
                try
                {
                    connection.Open();

                    workoutDBManager = new WorkoutDBManager();
                    List<int> workoutIds = workoutDBManager.GetWorkoutIdsContainingExercise(strengthExercise.GetId());
                    foreach (int workoutId in workoutIds)
                    {
                        string deleteFromWorkoutQuery = "DELETE FROM WorkoutExercise WHERE WorkoutId = @WorkoutId AND ExerciseId = @ExerciseId";
                        SqlCommand deleteFromWorkoutCmd = new SqlCommand(deleteFromWorkoutQuery, connection);
                        deleteFromWorkoutCmd.Parameters.AddWithValue("@WorkoutId", workoutId);
                        deleteFromWorkoutCmd.Parameters.AddWithValue("@ExerciseId", strengthExercise.GetId());
                        deleteFromWorkoutCmd.ExecuteNonQuery();
                    }

                    string deleteStrengthQuery = "DELETE FROM StrengthExercise WHERE exercise_id = @ExerciseId";
                    SqlCommand deleteStrengthCmd = new SqlCommand(deleteStrengthQuery, connection);
                    deleteStrengthCmd.Parameters.AddWithValue("@ExerciseId", strengthExercise.GetId());
                    deleteStrengthCmd.ExecuteNonQuery();

                    string deleteExerciseQuery = "DELETE FROM Exercise WHERE id = @ExerciseId";
                    SqlCommand deleteExerciseCmd = new SqlCommand(deleteExerciseQuery, connection);
                    deleteExerciseCmd.Parameters.AddWithValue("@ExerciseId", strengthExercise.GetId());
                    deleteExerciseCmd.ExecuteNonQuery();

                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error deleting strength exercise: {ex.Message}", "Error");
                }
            }
        }
        public List<Exercise> SearchExercisesByNameAndType(string exerciseType, string exerciseName)
        {
            List<Exercise> exercises = new List<Exercise>();

            try
            {
                using (SqlConnection connection = new SqlConnection(GetConnectionString()))
                {
                    connection.Open();

                    string query = @"
                        SELECT e.id, e.name, e.description, 
                               se.muscle, se.repetitions, se.sets, se.weight, 
                               ce.duration
                        FROM Exercise e
                        LEFT JOIN StrengthExercise se ON e.id = se.exercise_id
                        LEFT JOIN CardioExercise ce ON e.id = ce.exercise_id
                        WHERE (@ExerciseType IS NULL 
                               OR (@ExerciseType = 'Strength' AND se.exercise_id IS NOT NULL)
                               OR (@ExerciseType = 'Cardio' AND ce.exercise_id IS NOT NULL))
                          AND (@ExerciseName IS NULL 
                               OR e.name LIKE '%' + @ExerciseName + '%')
                        ORDER BY e.id;";

                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@ExerciseType", (object)exerciseType ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@ExerciseName", (object)exerciseName ?? DBNull.Value);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                int id = reader.GetInt32(reader.GetOrdinal("id"));
                                string name = reader.GetString(reader.GetOrdinal("name"));
                                string description = reader.GetString(reader.GetOrdinal("description"));

                                if (exerciseType == "Strength" && !reader.IsDBNull(reader.GetOrdinal("muscle")))
                                {
                                    string muscle = reader.GetString(reader.GetOrdinal("muscle"));
                                    int repetitions = reader.GetInt32(reader.GetOrdinal("repetitions"));
                                    int sets = reader.GetInt32(reader.GetOrdinal("sets"));
                                    double weight = Convert.ToDouble(reader.GetDecimal(reader.GetOrdinal("weight")));

                                    exercises.Add(new Strength(id, name, description, (MuscleGroup)Enum.Parse(typeof(MuscleGroup), muscle), repetitions, sets, weight));
                                }
                                else if (exerciseType == "Cardio" && !reader.IsDBNull(reader.GetOrdinal("duration")))
                                {
                                    TimeSpan duration = reader.GetTimeSpan(reader.GetOrdinal("duration"));

                                    exercises.Add(new Cardio(id, name, description, duration));
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }

            return exercises;
        }

        public void DeleteCardioExercise(Cardio cardioExercise)
        {
            using SqlConnection connection = new SqlConnection(GetConnectionString());
            try
            {
                connection.Open();
                workoutDBManager = new WorkoutDBManager();
                List<int> workoutIds = workoutDBManager.GetWorkoutIdsContainingExercise(cardioExercise.GetId());
                foreach (int workoutId in workoutIds)
                {
                    string deleteFromWorkoutQuery = "DELETE FROM WorkoutExercise WHERE WorkoutId = @WorkoutId AND ExerciseId = @ExerciseId";
                    SqlCommand deleteFromWorkoutCmd = new SqlCommand(deleteFromWorkoutQuery, connection);
                    deleteFromWorkoutCmd.Parameters.AddWithValue("@WorkoutId", workoutId);
                    deleteFromWorkoutCmd.Parameters.AddWithValue("@ExerciseId", cardioExercise.GetId());
                    deleteFromWorkoutCmd.ExecuteNonQuery();
                }
                string deleteCardioQuery = "DELETE FROM CardioExercise WHERE exercise_id = @ExerciseId";
                SqlCommand sqlCommand = new SqlCommand(deleteCardioQuery, connection);
                sqlCommand.Parameters.AddWithValue("@ExerciseId", cardioExercise.GetId());
                sqlCommand.ExecuteNonQuery();

                string deleteExerciseQuery = "DELETE FROM Exercise WHERE id = @ExerciseId";
                SqlCommand deleteExerciseCmd = new SqlCommand(deleteExerciseQuery, connection);
                deleteExerciseCmd.Parameters.AddWithValue("@ExerciseId", cardioExercise.GetId());
                deleteExerciseCmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            finally
            {
                if (connection.State != ConnectionState.Closed)
                    connection.Close();
            }
        }
        public List<Cardio>? GetCardioExercises()
        {
            List<Cardio> cardioExercises = new List<Cardio>();

            try
            {
                using (SqlConnection connection = new SqlConnection(GetConnectionString()))
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
        public List<Exercise> SearchExercisesByName(string name)
        {
            List<Exercise> exercises = new List<Exercise>();

            try
            {
                using (SqlConnection connection = new SqlConnection(GetConnectionString()))
                {
                    connection.Open();

                    string query = @"
                        SELECT e.id, e.name, e.description, c.duration, s.muscle, s.repetitions, s.sets, s.weight 
                        FROM Exercise e
                        LEFT JOIN CardioExercise c ON e.id = c.exercise_id
                        LEFT JOIN StrengthExercise s ON e.id = s.exercise_id
                        WHERE e.name LIKE @Name";

                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@Name", "%" + name + "%");

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                int id = reader.GetInt32(reader.GetOrdinal("id"));
                                string exerciseName = reader.GetString(reader.GetOrdinal("name"));
                                string description = reader.GetString(reader.GetOrdinal("description"));

                                if (!reader.IsDBNull(reader.GetOrdinal("duration")))
                                {
                                    TimeSpan duration = reader.GetTimeSpan(reader.GetOrdinal("duration"));
                                    Cardio cardioExercise = new Cardio(id, exerciseName, description, duration);
                                    exercises.Add(cardioExercise);
                                }
                                else
                                {
                                    string muscleGroupString = reader.GetString(reader.GetOrdinal("muscle"));
                                    MuscleGroup muscleGroup = (MuscleGroup)Enum.Parse(typeof(MuscleGroup), muscleGroupString);
                                    int repetitions = reader.GetInt32(reader.GetOrdinal("repetitions"));
                                    int sets = reader.GetInt32(reader.GetOrdinal("sets"));
                                    double weight = Convert.ToDouble(reader.GetDecimal(reader.GetOrdinal("weight")));

                                    Strength strengthExercise = new Strength(id, exerciseName, description, muscleGroup, repetitions, sets, weight);
                                    exercises.Add(strengthExercise);
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }

            return exercises;
        }
        public List<Strength>? GetStrengthExercises()
        {
            List<Strength> strengthExercises = new List<Strength>();

            try
            {
                using (SqlConnection connection = new SqlConnection(GetConnectionString()))
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
                                double weight = Convert.ToDouble(reader.GetDecimal(reader.GetOrdinal("weight")));

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
