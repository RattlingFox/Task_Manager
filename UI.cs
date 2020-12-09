using System;
using System.Collections.Generic;
using System.Linq;
//using System.IO;

class UI // фронт программы и сборка элемента списка
{
    public static void add(Manager manager)
    {
        string subject;
        DateTime date;
        Console.WriteLine("Enter new task");
        subject = Console.ReadLine();
        Console.WriteLine("");
        try
        {
            date = UI.insertDataTime();
            Task task = new Task(subject, date);
            manager.add(task);
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine(ex.Message);
            Console.WriteLine("");
            return;
        }


    }

    public static void remove(Manager manager)
    {
        int indexUI;
        UI.show(manager);
        while (true)
        {
            try
            {
                indexUI = UI.insertInt();
                manager.remove(indexUI);
                Console.WriteLine("Removed successfully");
                Console.WriteLine("");
                return;
            }
            catch (ArgumentOutOfRangeException)
            {
                Console.WriteLine("Error. There is nothing to remove");
                Console.WriteLine("");
                return;
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("");
                return;
            }

        }
    }

    public static void show(Manager manager)
    {
        List<Task> showList = manager.getList().OrderBy(task => task._date).ToList();
        for (int i = 0; i < showList.Count; i++)
        {

            Console.WriteLine(i + " " + showList[i].toString());
        }
        Console.WriteLine("");


    }

    public static void edit(Manager manager)
    {
        int indexUI;
        string subject;
        DateTime date;
        UI.show(manager);
        while (true)
        {
            try
            {
                indexUI = UI.insertInt();
                if (manager.isExist(indexUI))
                {
                    Console.WriteLine("");
                    Console.WriteLine("Enter task");
                    subject = Console.ReadLine();
                    Console.WriteLine("");
                    date = UI.insertDataTime();
                    Task task = new Task(subject, date);
                    manager.edit(indexUI, task);
                    Console.WriteLine("Edited successfully");
                    Console.WriteLine("");
                    return;
                }
                throw new Exception();
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("");
                return;
            }
            catch (Exception)
            {
                Console.WriteLine("Error. There is nothing to edit");
                Console.WriteLine("");
                return;
            }
        }
    }
    public static int insertInt()
    {
        string indexUI;
        int indexUI_Int;
        Console.WriteLine("Enter id");
        indexUI = Console.ReadLine();        
        try
        {
            indexUI_Int = Convert.ToInt32(indexUI);
            return indexUI_Int;
        }
        catch (Exception)
        {
            Console.WriteLine("Error. Type 'y' for repeat");
            if (Console.ReadLine() == "y")
            {
                Console.WriteLine("");
                insertInt();
            }
            throw new ArgumentException("Error. Id is wrong");
        }
    }
    public static DateTime insertDataTime()
    {
        string date;
        DateTime check;
        Console.WriteLine("Enter date YYYY/MM/DD");
        date = Console.ReadLine();
        Console.WriteLine("");
        try
        {
            check = Convert.ToDateTime(date);
            return check;
        }
        catch (Exception)
        {
            Console.WriteLine("Error. Type 'y' for repeat");
            if (Console.ReadLine() == "y")
            {
                Console.WriteLine("");
                insertDataTime();
            }
            throw new ArgumentException("Error. Date is wrong");
        }


    }
    
    public static void clear(Manager manager)
    {
        string change;
        Console.WriteLine("Clear current list? Type 'y' for remove all data");
        change = Console.ReadLine();
        if (change == "y")
        {
            manager.clear();
        }
    }
}