/*
 * Learning Journey - Data Access Layer
 * Key Learning Points:
 * - SQLite database operations in C#
 * - Using parameterized queries for security
 * - Connection management with 'using' statements
 * - CRUD operations implementation
 * - Error handling and validation
 */

namespace HabitTracker.Services
{

    public class DatabaseService : IDatabaseService
    {
        // Learned about connection strings and database configuration
        private readonly string _connectionString = "Data Source=habit.db";

        // Learned about creating tables and SQL DDL
        public void CreateTable()
        {
            using (var connection = new SqliteConnection(_connectionString))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = @"
               CREATE TABLE IF NOT EXISTS habit_records (
                   Id INTEGER PRIMARY KEY AUTOINCREMENT,
                   Name TEXT NOT NULL,
                   Date TEXT NOT NULL,
                   Duration REAL NOT NULL
                )";

                command.ExecuteNonQuery();
            }
        }

        // Learned about SQL injection prevention using parameters
        public void InsertHabitRecord(HabitRecord habitRecord)
        {
            CreateTable();
            using (var connection = new SqliteConnection(_connectionString))
            {
                connection.Open();
                var command = connection.CreateCommand();
                // Using parameterized queries for security
                command.CommandText = "INSERT INTO habit_records (Name, Date, Duration) VALUES (@Name, @Date, @Duration)";

                command.Parameters.AddWithValue("@Name", habitRecord.Name);
                command.Parameters.AddWithValue("@Date", habitRecord.Date.ToString("dd-MM-yyyy"));
                command.Parameters.AddWithValue("@Duration", habitRecord.Duration);

                command.ExecuteNonQuery();
            }
        }

        public void DeleteHabitRecord(int id)
        {
            using (var connection = new SqliteConnection(_connectionString))
            {

                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = "DELETE FROM habit_records WHERE Id = @Id";
                command.Parameters.AddWithValue("@Id", id);

                int rowCount = command.ExecuteNonQuery();
                if (rowCount == 0)
                {

                    Console.WriteLine($"\nRecord with Id {id} doesn't exist.\n");

                }
            }
        }

        public void UpdateHabitRecord(HabitRecord habitRecord)
        {
            using (var connection = new SqliteConnection(_connectionString))
            {
                connection.Open();

                var checkCommand = connection.CreateCommand();
                checkCommand.CommandText = "SELECT COUNT(1) FROM habit_records WHERE Id = @Id";
                checkCommand.Parameters.AddWithValue("Id", habitRecord.Id);

                int exists = Convert.ToInt32(checkCommand.ExecuteScalar());

                if (exists == 0)
                {
                    Console.WriteLine($"\nRecord with Id {habitRecord.Id} doesn't exist.\n");
                    return;
                }

                var updateCommand = connection.CreateCommand();
                updateCommand.CommandText = @"
                    UPDATE habit_records
                    SET Name = @Name,
                        Date = @Date,
                        Duration = @Duration
                    WHERE Id = @Id";

                updateCommand.Parameters.AddWithValue("@Name", habitRecord.Name);
                updateCommand.Parameters.AddWithValue("@Date", habitRecord.Date.ToString("dd-MM-yyyy"));
                updateCommand.Parameters.AddWithValue("@Duration", habitRecord.Duration);
                updateCommand.Parameters.AddWithValue("@Id", habitRecord.Id);

                updateCommand.ExecuteNonQuery();
                Console.WriteLine($"\nRecord with Id {habitRecord.Id} updated successfully.\n");

            }
        }

        public List<HabitRecord> GetAllHabitRecords()
        {
            CreateTable(); // Ensure it exists
            var habitRecords = new List<HabitRecord>();

            using (var connection = new SqliteConnection(_connectionString))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = "SELECT * FROM habit_records ORDER BY Id";

                // Learned about reading from SQL To List
                using (var reader = command.ExecuteReader())
                {

                    while (reader.Read())
                    {
                        var habitRecord = new HabitRecord(

                            reader.GetInt32(0),
                            reader.GetString(1),
                            DateTime.ParseExact(reader.GetString(2), "dd-MM-yyyy", CultureInfo.InvariantCulture),
                            reader.GetDouble(3)


                        );
                        habitRecords.Add(habitRecord);
                    }
                }
            }
            return habitRecords;

        }
    }
}