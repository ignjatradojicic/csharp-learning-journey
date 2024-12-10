using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoApp
{
    public class TodoItem
    {
        public string Description { get; set; }

        public TodoItem(string description) 
        {
            Description = description;
        }
        public override string ToString()
        {
            return Description;
        }
    }
}
