/*
 * Learning Journey - Entity Class
 * Key Learning Points:
 * - Creating immutable properties with private setters
 * - Constructor parameter validation
 * - DateTime handling in C#
 * - Override ToString() method for custom string representation
 */
namespace HabitTracker.Entities
{
    public class HabitRecord
    {
        // Using private setters for immutability - learned about encapsulation
        public int Id { get; private set; }
        public string Name { get; private set; }
        public DateTime Date { get; private set; }
        public double Duration { get; private set; }

        // Constructor enforces that all required data is provided
        public HabitRecord(int id, string name, DateTime date, double duration)
        {
            Id = id;
            Name = name;
            Date = date;
            Duration = duration;
        }

        // Learned about overriding object methods for better string representation
        public override string ToString()
        {
            return $"{Id} - {Name} {Date.ToString("dd-MM-yyyy")} - Duration: {Duration} hours";
        }
    }
}