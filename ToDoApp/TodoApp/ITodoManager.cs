using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoApp
{
    internal interface ITodoManager
    {
        void AddTodo(string todo);
        void RemoveTodoAt(int index);
        void DisplayTodos();
        int GetTodoCount();


    }
}
