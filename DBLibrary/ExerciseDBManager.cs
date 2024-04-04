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
    public class ExerciseDBManager
    {
        private string connectionString;

        public ExerciseDBManager()
        {
            connectionString = "Server=mssqlstud.fhict.local;Database=dbi530206_fitnestrak;User Id=dbi530206_fitnestrak;Password=1234;";
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
                    insertStrengthExerciseCommand.Parameters.AddWithValue("@Muscle", strength.GetMuscleGroup());
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
    }


    
}
   



    //public List<Strength> GetAllStrengthExercisesFromDB()
    //{
    //    List<Strength> exercises = new List<Strength>();
    //    using (SqlConnection connection = new SqlConnection(connectionString))
    //    {
    //        connection.Open();
    //        string query = "SELECT * FROM StrengthExercise";

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

    //                    MuscleGroup muscleGroup = Enum.Parse<MuscleGroup>(muscleGroupString);

    //                    Exercise exercise = new Exercise(id, name, description, muscleGroup);
    //                    exercises.Add(exercise);

    //                }
    //            }
    //        }
    //    }
    //    return exercises;
    //}



