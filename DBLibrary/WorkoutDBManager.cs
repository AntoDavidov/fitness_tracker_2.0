﻿using ExerciseLibrary;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IRepositories;
using NameLibrary;
using System.Reflection.PortableExecutable;

namespace DBLibrary
{
    public class WorkoutDBManager : DBDal, IWorkoutRepo
    {
        private ExerciseDBManager ExerciseDBManager;
        public WorkoutDBManager() 
        { 
            ExerciseDBManager = new ExerciseDBManager();
        }

        public bool AddWorkoutWithoutExercises(Workouts workout)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(GetConnectionString()))
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
            using SqlConnection connection = new SqlConnection(GetConnectionString());
            try
            {
                // Check if the exercise already exists in the workout
                if (ExerciseAlreadyExistsInWorkout(workoutId, exerciseId))
                {
                    Console.WriteLine("Exercise already exists in the workout.");
                    return;
                }

                // If the exercise doesn't exist in the workout, add it
                using (SqlCommand sqlCommand = connection.CreateCommand())
                {
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
        public Workouts GetWorkoutById(int workoutId)
        {
            Workouts workout = null;
            try
            {
                using (SqlConnection connection = new SqlConnection(GetConnectionString()))
                {
                    connection.Open();

                    // Query to get the workout details
                    string workoutQuery = "SELECT id, Name, Description, workout_level FROM Workout WHERE id = @WorkoutId";
                    SqlCommand workoutCmd = new SqlCommand(workoutQuery, connection);
                    workoutCmd.Parameters.AddWithValue("@WorkoutId", workoutId);

                    using (SqlDataReader workoutReader = workoutCmd.ExecuteReader())
                    {
                        if (workoutReader.Read())
                        {
                            int id = workoutReader.GetInt32(workoutReader.GetOrdinal("id"));
                            string name = workoutReader.GetString(workoutReader.GetOrdinal("Name"));
                            string description = workoutReader.GetString(workoutReader.GetOrdinal("Description"));
                            Level workoutLevel = (Level)workoutReader.GetInt32(workoutReader.GetOrdinal("workout_level"));

                            // Initialize the workout object
                            workout = new Workouts(id, name, description, workoutLevel);
                        }
                    }

                    // Query to get exercises associated with the workout
                    string exerciseQuery = "SELECT ExerciseId FROM WorkoutExercise WHERE WorkoutId = @WorkoutId";
                    SqlCommand exerciseCmd = new SqlCommand(exerciseQuery, connection);
                    exerciseCmd.Parameters.AddWithValue("@WorkoutId", workoutId);

                    using (SqlDataReader exerciseReader = exerciseCmd.ExecuteReader())
                    {
                        while (exerciseReader.Read())
                        {
                            int exerciseId = exerciseReader.GetInt32(exerciseReader.GetOrdinal("ExerciseId"));
                            // Fetch the exercise details using the GetExerciseById method
                            Exercise exercise = ExerciseDBManager.GetExerciseById(exerciseId);
                            if (exercise != null)
                            {
                                workout.AddExercise(exercise);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }

            return workout;
        }
        public List<Workouts> GetWorkoutsByPage(int pageIndex, int pageSize)
        {
            List<Workouts> workouts = new List<Workouts>();

            try
            {
                using (SqlConnection connection = new SqlConnection(GetConnectionString()))
                {
                    connection.Open();

                    string query = @"SELECT * FROM Workout
                                     ORDER BY id
                                     OFFSET @Offset ROWS
                                     FETCH NEXT @PageSize ROWS ONLY";

                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@Offset", (pageIndex - 1) * pageSize);
                        cmd.Parameters.AddWithValue("@PageSize", pageSize);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                int id = reader.GetInt32(reader.GetOrdinal("id"));
                                string name = reader.GetString(reader.GetOrdinal("Name"));
                                string description = reader.GetString(reader.GetOrdinal("Description"));
                                Level workoutLevel = (Level)reader.GetInt32(reader.GetOrdinal("workout_level"));

                                // Create a new Workout object and add it to the list
                                Workouts workout = new Workouts(id, name, description, workoutLevel);
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

        public int GetTotalWorkoutsCount()
        {
            int count = 0;

            try
            {
                using (SqlConnection connection = new SqlConnection(GetConnectionString()))
                {
                    connection.Open();

                    string query = "SELECT COUNT(*) FROM Workout";

                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        count = (int)cmd.ExecuteScalar();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }

            return count;
        }
        public List<Workouts> GetFilteredWorkouts(int? level, bool includeLevel, int pageIndex, int pageSize)
        {
            List<Workouts> workouts = new List<Workouts>();
            int offset = (pageIndex - 1) * pageSize;

            try
            {
                using (SqlConnection connection = new SqlConnection(GetConnectionString()))
                {
                    connection.Open();

                    string query = @"
                SELECT w.Id, w.Name, w.Description, w.workout_level
                FROM Workout w
                WHERE (@Level IS NULL 
                       OR (@IncludeLevel = 1 AND w.workout_level = @Level)
                       OR (@IncludeLevel = 0 AND w.workout_level <> @Level))
                ORDER BY w.Id
                OFFSET @Offset ROWS
                FETCH NEXT @PageSize ROWS ONLY";

                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@Level", level.HasValue ? (object)level.Value : DBNull.Value);
                        cmd.Parameters.AddWithValue("@IncludeLevel", includeLevel ? 1 : 0);
                        cmd.Parameters.AddWithValue("@Offset", offset);
                        cmd.Parameters.AddWithValue("@PageSize", pageSize);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                int id = reader.GetInt32(reader.GetOrdinal("Id"));
                                string name = reader.GetString(reader.GetOrdinal("Name"));
                                string description = reader.GetString(reader.GetOrdinal("Description"));
                                Level workoutLevel = (Level)reader.GetInt32(reader.GetOrdinal("workout_level"));

                                Workouts workout = new Workouts(id, name, description, workoutLevel);
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
        public List<Workouts> SearchWorkouts(string name, int? level)
        {
            List<Workouts> workouts = new List<Workouts>();

            try
            {
                using (SqlConnection connection = new SqlConnection(GetConnectionString()))
                {
                    connection.Open();

                    string query = @"
                        SELECT id, Name, Description, workout_level 
                        FROM Workout as w
                        WHERE Name LIKE '%' + @Name + '%'
                        AND (@Level IS NULL OR w.workout_level = @Level)
                        ORDER BY id";

                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@Name", name);
                        cmd.Parameters.AddWithValue("@Level", level.HasValue ? (object)level.Value : DBNull.Value);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                int id = reader.GetInt32(reader.GetOrdinal("id"));
                                string workoutName = reader.GetString(reader.GetOrdinal("Name"));
                                string description = reader.GetString(reader.GetOrdinal("Description"));
                                Level workoutLevel = (Level)reader.GetInt32(reader.GetOrdinal("workout_level"));

                                Workouts workout = new Workouts(id, workoutName, description, workoutLevel);
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


        public int GetFilteredWorkoutsCount(int? level, bool includeLevel)
        {
            int count = 0;

            try
            {
                using (SqlConnection connection = new SqlConnection(GetConnectionString()))
                {
                    connection.Open();

                    string query = @"
                SELECT COUNT(*)
                FROM Workout w
                WHERE (@Level IS NULL 
                       OR (@IncludeLevel = 1 AND w.workout_level = @Level)
                       OR (@IncludeLevel = 0 AND w.workout_level <> @Level))";

                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@Level", level.HasValue ? (object)level.Value : DBNull.Value);
                        cmd.Parameters.AddWithValue("@IncludeLevel", includeLevel ? 1 : 0);

                        count = (int)cmd.ExecuteScalar();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }

            return count;
        }

        public List<Workouts> GetTopRatedWorkouts(int topN)
        {
            var topRatedWorkouts = new List<Workouts>();

            try
            {
                using (SqlConnection conn = new SqlConnection(GetConnectionString()))
                {
                    conn.Open();

                    string query = @"SELECT TOP (@TopN) WorkoutId, AVG(RatingValue) as AvgRating 
                                     FROM Rating 
                                     GROUP BY WorkoutId 
                                     ORDER BY AvgRating DESC";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@TopN", topN);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                int workoutId = reader.GetInt32(reader.GetOrdinal("WorkoutId"));
                                Workouts workout = GetWorkoutById(workoutId);
                                topRatedWorkouts.Add(workout);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex.Message}");
            }

            return topRatedWorkouts;
        }


       
        public bool ExerciseAlreadyExistsInWorkout(int workoutId, int exerciseId)
        {
            bool exists = false;
            try
            {
                using (SqlConnection connection = new SqlConnection(GetConnectionString()))
                {
                    connection.Open();
                    string query = "SELECT COUNT(*) FROM WorkoutExercise WHERE WorkoutId = @WorkoutId AND ExerciseId = @ExerciseId";
                    SqlCommand cmd = new SqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@WorkoutId", workoutId);
                    cmd.Parameters.AddWithValue("@ExerciseId", exerciseId);
                    exists = (int)cmd.ExecuteScalar() > 0;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            return exists;
        }
        public void DeleteWorkout(int workoutId)
        {
            using SqlConnection connection = new SqlConnection(GetConnectionString());
            try
            {
                connection.Open();

                // Delete entries from WorkoutExercise connecting table first
                var deleteWorkoutExerciseQuery = "DELETE FROM WorkoutExercise WHERE WorkoutId = @WorkoutId";
                using SqlCommand deleteWorkoutExerciseCommand = new SqlCommand(deleteWorkoutExerciseQuery, connection);
                deleteWorkoutExerciseCommand.Parameters.AddWithValue("@WorkoutId", workoutId);
                deleteWorkoutExerciseCommand.ExecuteNonQuery();

                // Now, delete the workout from the Workout table
                var deleteWorkoutQuery = "DELETE FROM Workout WHERE id = @WorkoutId";
                using SqlCommand deleteWorkoutCommand = new SqlCommand(deleteWorkoutQuery, connection);
                deleteWorkoutCommand.Parameters.AddWithValue("@WorkoutId", workoutId);
                deleteWorkoutCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                // Handle exceptions appropriately
                Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                if (connection.State != ConnectionState.Closed)
                    connection.Close();
            }
        }
        public List<int> GetWorkoutIdsContainingExercise(int exerciseId)
        {
            List<int> workoutIds = new List<int>();
            using (SqlConnection connection = new SqlConnection(GetConnectionString()))
            {
                try
                {
                    connection.Open();

                    // Query to select all workout IDs containing the given exercise ID
                    string query = "SELECT WorkoutId FROM WorkoutExercise WHERE ExerciseId = @ExerciseId";
                    SqlCommand cmd = new SqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@ExerciseId", exerciseId);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int workoutId = reader.GetInt32(reader.GetOrdinal("WorkoutId"));
                            workoutIds.Add(workoutId);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error retrieving workout IDs containing exercise: {ex.Message}", "Error");
                }
            }
            return workoutIds;
        }

        public List<Workouts>? GetAllWorkouts()
        {
            List<Workouts> workouts = new List<Workouts>();

            try
            {
                using (SqlConnection connection = new SqlConnection(GetConnectionString()))
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
                                Level workoutLevel = (Level)reader.GetInt32(reader.GetOrdinal("workout_level"));

                                // Create a new Workout object and add it to the list
                                Workouts workout = new Workouts(id, name, description, workoutLevel);
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
        public List<Exercise>? GetExercisesForWorkout(int workoutId)
        {
            List<Exercise> exercises = new List<Exercise>();

            try
            {
                using (SqlConnection connection = new SqlConnection(GetConnectionString()))
                {
                    connection.Open();

                    // Query the WorkoutExercise table to get exercise IDs for the specified workout
                    string query = "SELECT ExerciseId FROM WorkoutExercise WHERE WorkoutId = @WorkoutId";
                    SqlCommand cmd = new SqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@WorkoutId", workoutId);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int exerciseId = reader.GetInt32(reader.GetOrdinal("ExerciseId"));

                            // Get the exercise details based on its ID using the existing GetExerciseById method
                            Exercise exercise = ExerciseDBManager.GetExerciseById(exerciseId);

                            if (exercise != null)
                            {
                                exercises.Add(exercise);
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
        public void RemoveExerciseFromWorkout(int workoutId, int exerciseId)
        {
            using (SqlConnection conn = new SqlConnection(GetConnectionString()))
            {
                conn.Open();
                string query = "DELETE FROM WorkoutExercise WHERE WorkoutId = @WorkoutId AND ExerciseId = @ExerciseId";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@WorkoutId", workoutId);
                cmd.Parameters.AddWithValue("@ExerciseId", exerciseId);
                cmd.ExecuteNonQuery();
            }
        }
    }
}
