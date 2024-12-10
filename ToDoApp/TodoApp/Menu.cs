using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoApp
{
    public class Menu
    {
        private readonly ITodoManager _todoManager;

        public Menu()
        {
            _todoManager = new TodoManager() ?? throw new ArgumentNullException(nameof(TodoManager));
        }
        public void Start()
        {
            bool closeApp = false;

            while (!closeApp)
            {
                Console.WriteLine("Hello!");
                Console.WriteLine("What do you want to do?");
                Console.WriteLine("[S]ee all TODOs");
                Console.WriteLine("[A]dd a TODO");
                Console.WriteLine("[R]emove a TODO");
                Console.WriteLine("[E]xit");

                string commandInput = Console.ReadLine().ToUpper();

                switch (commandInput)
                {
                    case "E":
                        Console.WriteLine("\nGoodbye!\n");
                        closeApp = true;
                        break;
                    case "A":
                        AddTodo();
                        break;
                    case "R":
                        RemoveTodo();
                        break;
                    case "S":
                        _todoManager.DisplayTodos();
                        break;
                    default:
                        Console.WriteLine("\nInvalid Command. Please type S, A, R, or E.\n");
                        break;
                }
            }
        }

        private void AddTodo()
        {
            Console.WriteLine("Insert new TODO:");
            string newTodo = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(newTodo))
            {
                Console.WriteLine("TODO cannot be empty. Please try again. \n");
                return;
            }


            _todoManager.AddTodo(newTodo);
        }
        private void RemoveTodo()
        {
            _todoManager.DisplayTodos();
            if (_todoManager.GetTodoCount() == 0)
            {
                Console.WriteLine("No TODOs available to remove.\n");
                return;
            }
            Console.WriteLine("Enter the index of the TODO to remove:");
            if (int.TryParse(Console.ReadLine(), out int index))
            {
                _todoManager.RemoveTodoAt(index);
            }
            else 
            {
                Console.WriteLine("Invalid input. Please enter a number.\n");
            }
        }
    }
}
