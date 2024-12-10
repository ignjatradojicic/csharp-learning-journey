using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace TodoApp
{
    internal class TodoManager : ITodoManager
    {

        private readonly List<string> todoList = new List<string>();

        public void AddTodo(string todo)
        {
            todoList.Add(todo);
            Console.WriteLine("TODO added successfully.\n");
        }
        public void RemoveTodoAt(int index)
        {
            if(index < 0 || index >= todoList.Count) {
                Console.WriteLine("Invalid index. \n");
                return;

            }
            todoList.RemoveAt(index);
            Console.WriteLine("TODO Removed Successfully.\n");
        }
       public void DisplayTodos()
        {
            if (todoList.Count == 0)
            {
                Console.WriteLine("No Items in the list.\n");
                return;
            }

            for(int i = 0; i<todoList.Count; i++)
            {
                Console.WriteLine($"[{i}] {todoList[i]}"); 
            }
            Console.WriteLine();
        }

        public int GetTodoCount()
        {
            return todoList.Count;
        }
    }
}
