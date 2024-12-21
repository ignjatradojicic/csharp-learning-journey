/*
 * Learning Journey - Console Menu Logic
 * Key Learning Points:
 * - Implementing a simple console-based menu
 * - Handling user input and implementing switch-case logic
 * - Looping through menu options until the user decides to exit
 */

namespace HabitTracker
{
    public class Menu
    {
        private readonly MenuHandler _menuHandler;

        public Menu(MenuHandler menuHandler)
        {
            _menuHandler = menuHandler;
        }

        public void Display()
        {
            bool closeApp = false;

            while (!closeApp)
            {
                Console.Clear();
                Console.WriteLine("\nMain Menu");
                Console.WriteLine("1. View All Records");
                Console.WriteLine("2. Add Record");
                Console.WriteLine("3. Update Record");
                Console.WriteLine("4. Delete Record");
                Console.WriteLine("0. Exit");

                var choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        _menuHandler.ViewAllRecords();
                        break;
                    case "2":
                        _menuHandler.AddRecord();
                        break;
                    case "3":
                        _menuHandler.UpdateRecord();
                        break;
                    case "4":
                        _menuHandler.DeleteRecord();
                        break;
                    case "0":
                        closeApp = true;
                        break;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            }
        }
    }
}
