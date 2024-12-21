/*
 * Learning Journey - User Interface Logic
 * Key Learning Points:
 * - Console UI implementation
 * - Input validation and error handling
 * - Using while loops for input retry logic
 * - Exception handling with try-catch blocks
 * - LINQ usage for data queries
 */

namespace HabitTracker
{
    public class MenuHandler
    {
        // Dependency injection for accessing habit service logic
        private readonly IHabitService _habitService;

        // Constructor: Inject the habit service to manage records
        public MenuHandler(IHabitService habitService)
        {
            _habitService = habitService;
        }

        // View all habit records with formatting and validation
        public void ViewAllRecords()
        {
            Console.Clear();

            // Fetch all records from the service
            var records = _habitService.GetAllHabitRecords();

            if (records.Count == 0) // Handle case when no records are present
            {
                Console.WriteLine("\nNo records found.\n");
            }
            else
            {
                Console.WriteLine("\nAll Habits:\n");
                foreach (var record in records) // Display each record
                {
                    Console.WriteLine(record);
                }
            }

            // Pause for user to review results
            Console.WriteLine("\nPress any key to continue...\n");
            Console.ReadKey();
        }

        // Add a new habit record with user input validation
        public void AddRecord()
        {
            try
            {
                Console.Clear();
                Console.WriteLine("\nAdd New Habit Record\n");

                // Collect habit name with input validation
                string name;
                while (true)
                {
                    Console.Write("Enter Name of Habit: ");
                    name = Console.ReadLine()?.Trim();
                    if (!string.IsNullOrWhiteSpace(name))
                        break;
                    Console.WriteLine("\nName cannot be empty. Please try again.");
                }

                // Collect habit date with validation for correct format
                DateTime date;
                while (true)
                {
                    Console.Write("Enter Date (dd-MM-yyyy): ");
                    if (DateTime.TryParseExact(Console.ReadLine(), "dd-MM-yyyy",
                        CultureInfo.InvariantCulture, DateTimeStyles.None, out date))
                        break;
                    Console.WriteLine("\nInvalid date format. Please try again.");
                }

                // Collect habit duration with validation for non-negative values
                double duration;
                while (true)
                {
                    Console.Write("Enter Duration (in hours): ");
                    if (double.TryParse(Console.ReadLine(), out duration) && duration >= 0)
                        break;
                    Console.WriteLine("\nInvalid duration. Please enter a positive number.");
                }

                // Create and save the new habit record
                var habitRecord = new HabitRecord(0, name, date, duration);
                _habitService.AddHabitRecord(habitRecord);

                Console.WriteLine("\nRecord added successfully! Press any key to continue...");
                Console.ReadKey();
            }
            catch (Exception ex)
            {
                // Handle unexpected errors gracefully
                Console.WriteLine($"\nAn error occurred: {ex.Message}\nPress any key to continue...");
                Console.ReadKey();
            }
        }

        // Update an existing habit record with user input
        public void UpdateRecord()
        {
            try
            {
                Console.Clear();
                Console.WriteLine("\nUpdate Habit Record\n");

                // Fetch and display all existing records
                var records = _habitService.GetAllHabitRecords();
                if (records.Count == 0)
                {
                    Console.WriteLine("No records found to update. Press any key to return...");
                    Console.ReadKey();
                    return;
                }

                foreach (var record in records)
                {
                    Console.WriteLine(record);
                }

                // Validate user input for record ID
                int id;
                while (true)
                {
                    Console.Write("\nEnter the ID of the Habit you wish to update: ");
                    if (!int.TryParse(Console.ReadLine(), out id))
                    {
                        Console.WriteLine("Invalid ID format. Please try again.");
                        continue;
                    }

                    if (!records.Any(r => r.Id == id))
                    {
                        Console.WriteLine($"No record found with ID {id}. Please try again.");
                        continue;
                    }
                    break;
                }

                // Collect updated habit name, date, and duration
                string name;
                while (true)
                {
                    Console.Write("Enter the new Name of Habit: ");
                    name = Console.ReadLine()?.Trim();
                    if (!string.IsNullOrWhiteSpace(name))
                        break;
                    Console.WriteLine("Name cannot be empty. Please try again.");
                }

                DateTime date;
                while (true)
                {
                    Console.Write("Enter new Date (dd-MM-yyyy): ");
                    if (DateTime.TryParseExact(Console.ReadLine(), "dd-MM-yyyy",
                        CultureInfo.InvariantCulture, DateTimeStyles.None, out date))
                        break;
                    Console.WriteLine("Invalid date format. Please try again.");
                }

                double duration;
                while (true)
                {
                    Console.Write("Enter new Duration (in hours): ");
                    if (double.TryParse(Console.ReadLine(), out duration) && duration >= 0)
                        break;
                    Console.WriteLine("Invalid duration. Please enter a positive number.");
                }

                // Update the habit record in the service
                var habitRecord = new HabitRecord(id, name, date, duration);
                _habitService.UpdateHabitRecord(habitRecord);

                Console.WriteLine("\nRecord updated successfully! Press any key to continue...");
                Console.ReadKey();
            }
            catch (Exception ex)
            {
                // Handle errors during update
                Console.WriteLine($"\nAn error occurred: {ex.Message}\nPress any key to continue...");
                Console.ReadKey();
            }
        }

        // Delete an existing habit record by ID
        public void DeleteRecord()
        {
            try
            {
                Console.Clear();
                Console.WriteLine("\nDelete Habit Record\n");

                // Fetch and display all existing records
                var records = _habitService.GetAllHabitRecords();
                if (records.Count == 0)
                {
                    Console.WriteLine("No records found to delete. Press any key to return...");
                    Console.ReadKey();
                    return;
                }

                foreach (var record in records)
                {
                    Console.WriteLine(record);
                }

                // Validate user input for record ID to delete
                Console.Write("\nEnter the ID of the record to delete: ");
                if (!int.TryParse(Console.ReadLine(), out int id))
                {
                    Console.WriteLine("\nInvalid ID format. Press any key to return...");
                    Console.ReadKey();
                    return;
                }

                if (!records.Any(r => r.Id == id))
                {
                    Console.WriteLine($"\nNo record found with ID {id}. Press any key to return...");
                    Console.ReadKey();
                    return;
                }

                // Delete the record from the service
                _habitService.DeleteHabitRecord(id);
                Console.WriteLine("\nRecord deleted successfully! Press any key to continue...");
                Console.ReadKey();
            }
            catch (Exception ex)
            {
                // Handle errors during deletion
                Console.WriteLine($"\nAn error occurred: {ex.Message}\nPress any key to continue...");
                Console.ReadKey();
            }
        }
    }
}
