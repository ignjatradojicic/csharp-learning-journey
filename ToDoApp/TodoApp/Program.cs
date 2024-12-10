using System;
using System.ComponentModel.Design;

namespace TodoApp

{
    internal class Program
    {
        static void Main(string[] args)
        {
            Menu menu = new Menu();
            menu.Start();

            Console.WriteLine("Press any key to close the application");


        }
    }
}