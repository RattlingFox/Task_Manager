using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Data.SqlClient;
using System.Data.Common;
using Task_Manager;


class UI // фронт программы и сборка элемента списка
{
    public static void addNewTask()
    {
        List<string> list = storageDB.getTableList();
        string subject;
        DateTime date;

        Console.WriteLine("Select the task list to add a new task");
        int index = Manager.insertInt();
        Console.WriteLine("");

        Console.WriteLine("Enter a new task");
        subject = Console.ReadLine();
        Console.WriteLine("");
        try
        {
            date = Manager.insertDataTime();
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine(ex.Message);
            Console.WriteLine("");
            return;
        }
        Manager.add(list[index], index, subject, date);
    }

    public static void editTaskInTable()
    {
        List<string> list = storageDB.getTableList();
        string subject;
        DateTime date;
        Console.WriteLine("Select the task list to edit the task");
        int indexTable = Manager.insertInt();
        Console.WriteLine("");
        storageDB.getListInTable(list, indexTable);
        Console.WriteLine("");
        Console.WriteLine("Select the task id to edit");
        int indexTask = Manager.insertInt();
        Console.WriteLine("");

        Console.WriteLine("Enter a new task");
        subject = Console.ReadLine();
        Console.WriteLine("");
        try
        {
            date = Manager.insertDataTime();
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine(ex.Message);
            Console.WriteLine("");
            return;
        }
        Manager.add(list[indexTable], indexTable, subject, date);
        Manager.remove(list[indexTask], indexTask);

        Console.WriteLine("Task edited successfully");
        Console.WriteLine("");

    }

    public static void removeTaskFromTable()
    {
        List<string> list = storageDB.getTableList();
        Console.WriteLine("Select the task list to remove the task");
        int indexTable = Manager.insertInt();
        Console.WriteLine("");
        storageDB.getListInTable(list, indexTable);
        Console.WriteLine("");
        Console.WriteLine("Select the task id to remove the task from table");
        int indexTask = Manager.insertInt();
        Manager.remove(list[indexTask], indexTask);
        Console.WriteLine("");
        Console.WriteLine("Task removed from the list successfully");
        Console.WriteLine("");
    }    
}