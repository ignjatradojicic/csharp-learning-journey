/*
 * Learning Journey - Service Interface
 * Key Learning Points:
 * - Interface-based design
 * - Contract-first development
 * - Separation of concerns
 * - Dependency injection preparation
 */

namespace HabitTracker.Interfaces
{
    public interface IHabitService
    {
        void AddHabitRecord(HabitRecord habitRecord);
        void DeleteHabitRecord(int id);
        void UpdateHabitRecord(HabitRecord habitRecord);

        List<HabitRecord> GetAllHabitRecords();

    }
}
