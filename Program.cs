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
                Console.WriteLine("1 - Show all tables in storage");
                Console.WriteLine("2 - Show all tasks in a table");
                Console.WriteLine("3 - Add a new task in a table");
                //Console.WriteLine("4 - Edit a task in a table");
                //Console.WriteLine("5 - Remove task from table");
                //Console.WriteLine("6 - Remove table from storage");
                Console.WriteLine("9 - Exit");
                string choose = Console.ReadLine();
                if (choose == "1")
                {
                    Console.Clear();
                    storageDB.getTableList();
                }
                else if (choose == "2")
                {
                    Console.Clear();
                    storageDB.getTableFromDB();
                }
                else if (choose == "3")
                {
                    Console.Clear();
                    storageDB.addNewTask();
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
