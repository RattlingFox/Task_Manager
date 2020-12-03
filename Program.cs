using System;
using System.Collections.Generic;

namespace Task_Manager
{

    class Program // вход в программу
    {
        static void Main()

        {
            Console.WriteLine("Welcome to my Task Manager!");
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            Console.Clear();
            Manager manager = new Manager();
            while (true)
            {
                Console.WriteLine("Choose the operation:");
                Console.WriteLine("1 - Show all tasks;");
                Console.WriteLine("2 - Add task;");
                Console.WriteLine("3 - Edit task");
                Console.WriteLine("4 - Remove task");
                Console.WriteLine("5 - View files in directory");
                Console.WriteLine("6 - Exit");
                string choose = Console.ReadLine();
                if (choose == "1")
                {
                    Console.Clear();
                    UI.show(manager);
                }
                else if (choose == "2")
                {
                    Console.Clear();
                    UI.add(manager);
                }
                else if (choose == "3")
                {
                    Console.Clear();
                    UI.edit(manager);
                }
                else if (choose == "4")
                {
                    Console.Clear();
                    UI.remove(manager);
                }
                else if (choose == "5")
                {
                    UI.viewFiles();
                }
                else if (choose == "6")
                {
                    Console.Clear();
                    Console.WriteLine("Good Bye!");
                    System.Threading.Thread.Sleep(2000);
                    return;
                }
                else
                {
                    Console.WriteLine("Wrong number");
                    Console.WriteLine("");
                }
                
            }           
        }
    }
       
}
