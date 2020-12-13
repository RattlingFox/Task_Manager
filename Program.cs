using System;
//using System.Collections.Generic;

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
                Console.WriteLine("1 - Show all task lists in storage");
                Console.WriteLine("2 - Show all tasks in a task list");
                Console.WriteLine("3 - Add a new task to the task list");
                Console.WriteLine("4 - Edit task in the task list");
                Console.WriteLine("5 - Remove task from task list");
                Console.WriteLine("6 - Create task list in storage");
                Console.WriteLine("7 - Remove task list from storage");
                Console.WriteLine("9 - Exit");
                string choose = Console.ReadLine();
                if (choose == "1")
                {
                    Console.Clear();
                    Manager.getTableList();
                }
                else if (choose == "2")
                {
                    Console.Clear();
                    UI.getTablesFromDB();
                }
                else if (choose == "3")
                {
                    Console.Clear();
                    UI.addNewTask();
                }
                else if (choose == "4")
                {
                    Console.Clear();
                    UI.editTaskInTable();
                }
                else if (choose == "5")
                {
                    Console.Clear();
                    UI.removeTaskFromTable();
                }
                else if (choose == "6")
                {
                    Console.Clear();
                    UI.createTableInStorage();
                }
                else if (choose == "7")
                {
                    Console.Clear();
                    UI.removeTableFromStorage();
                }
                else if (choose == "9")
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
