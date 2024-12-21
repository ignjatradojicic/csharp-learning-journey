/*
 * Learning Journey - Console Application Entry Point
 * Key Learning Points:
 * - Dependency Injection pattern in C# without using a DI container
 * - Setting up a layered application architecture
 * - Program initialization and application flow
 */

namespace HabitTracker
{
    class Program
    {
        static void Main(string[] args)
        {
            // Initialize services using dependency injection pattern
            // This creates a clean separation of concerns and makes the code more testable
            IDatabaseService databaseService = new DatabaseService();
            IHabitService habitService = new HabitService(databaseService);
            var menu = new Menu(new MenuHandler(habitService));
            menu.Display();
        }
    }

}