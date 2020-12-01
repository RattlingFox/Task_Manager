﻿using System;
using System.Collections.Generic;
using System.Linq;

class UI // фронт программы и сборка элемента списка
{
    public static void add(Manager manager)
    {
        string subject;
        DateTime date;
        Console.WriteLine("Insert new task");
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
        bool isOK = false;
        while (!isOK)
        {
            try
            {
                indexUI = UI.insertInt();
                Console.WriteLine("");
                Console.WriteLine("Insert task");
                subject = Console.ReadLine();
                Console.WriteLine("");
                date = UI.insertDataTime();
                Task task = new Task(subject, date);
                manager.edit(indexUI, task);
                Console.WriteLine("Edited successfully");
                Console.WriteLine("");
                return;
            }
            catch (ArgumentOutOfRangeException)
            {
                Console.WriteLine("Error. There is nothing to edit");
                Console.WriteLine("");
                isOK = true;
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("");
                isOK = true;
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
        Console.WriteLine("Insert task id");
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
        Console.WriteLine("Insert date YYYY/MM/DD");
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


}
