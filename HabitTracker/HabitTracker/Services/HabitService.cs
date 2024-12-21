/*
 * Learning Journey - Habit Service Logic
 * Key Learning Points:
 * - Implementation of service layer pattern
 * - Dependency injection for database operations
 * - Encapsulation of database service logic
 * - Simplifying UI interactions through reusable methods
 */

namespace HabitTracker.Services
{
    public class HabitService : IHabitService
    {
        private readonly IDatabaseService _databaseService;

        public HabitService(IDatabaseService databaseService)
        {
            _databaseService = databaseService;
        }

        public void AddHabitRecord(HabitRecord habitRecord)
        {
            _databaseService.InsertHabitRecord(habitRecord);
        }

        public void DeleteHabitRecord(int id)
        {
            _databaseService.DeleteHabitRecord(id);
        }

        public void UpdateHabitRecord(HabitRecord habitRecord)
        {
            _databaseService.UpdateHabitRecord(habitRecord);
        }

        public List<HabitRecord> GetAllHabitRecords()
        {
            return _databaseService.GetAllHabitRecords();
        }
    }
}
