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
                Console.WriteLine("1 - Show all tasks;");
                Console.WriteLine("2 - Add task;");
                Console.WriteLine("3 - Edit task");
                Console.WriteLine("4 - Remove task");
                Console.WriteLine("5 - Clear data");
                Console.WriteLine("6 - View all items in storage");
                Console.WriteLine("7 - Read item from storage to list");
                Console.WriteLine("8 - Save data to item in storage");
                Console.WriteLine("9 - Exit");
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
                    UI.clear(manager);
                }
                else if (choose == "6")
                {
                    Storage.viewFiles();
                }
                else if (choose == "7")
                {
                    Storage.readFileToList(manager);
                }
                else if (choose == "8")
                {
                    Storage.saveFile(manager);
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
