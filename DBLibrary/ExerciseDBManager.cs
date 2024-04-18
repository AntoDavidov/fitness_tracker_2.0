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
        //public List<Exercise> GetAllExercisesFromDB()
        //{
        //    List<Exercise> exercises = new List<Exercise>();
        //    using (SqlConnection connection = new SqlConnection(connectionString))
        //    {
        //        connection.Open();
        //        string query = "SELECT * FROM Exercise";

        //        using (SqlCommand cmd = new SqlCommand(query, connection))
        //        {
        //            using (SqlDataReader reader = cmd.ExecuteReader())
        //            {
        //                while (reader.Read())
        //                {
        //                    int id = reader.GetInt32(reader.GetOrdinal("id"));
        //                    string name = reader.GetString(reader.GetOrdinal("name"));
        //                    string description = reader.GetString(reader.GetOrdinal("description"));
        //                    string muscleGroupString = reader.GetString(reader.GetOrdinal("muscle"));
        //                    string exerciseTypeString = reader.GetString(reader.GetOrdinal("exercise_type"));

        //                    MuscleGroup muscleGroup = Enum.Parse<MuscleGroup>(muscleGroupString);

        //                    Exercise exercise;
        //                    if ()
        //                    {
        //                        Strength strengthExercise = new Strength();
        //                        // Populate additional properties specific to StrengthExercise
        //                        strengthExercise.GetReps() = reader.GetInt32(reader.GetOrdinal("repetitions"));
        //                        strengthExercise.Sets = reader.GetInt32(reader.GetOrdinal("sets"));
        //                        strengthExercise.Weight = reader.GetInt32(reader.GetOrdinal("weight"));
        //                        exercise = strengthExercise;
        //                    }
        //                    else
        //                    {
        //                        CardioExercise cardioExercise = new CardioExercise();
        //                        // Populate additional properties specific to CardioExercise
        //                        cardioExercise.Duration = reader.GetInt32(reader.GetOrdinal("duration"));
        //                        exercise = cardioExercise;
        //                    }

        //                    exercise.Id = id;
        //                    exercise.Name = name;
        //                    exercise.Description = description;
        //                    exercise.MuscleGroup = muscleGroup;

        //                    exercises.Add(exercise);
        //                }
        //            }
        //        }
        //    }
        //    return exercises;
        //}

    }



}








