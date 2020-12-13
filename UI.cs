using System;
using System.Collections.Generic;
//using System.Text;
//using System.IO;
//using System.Data.SqlClient;
//using System.Data.Common;
//using Task_Manager;


class UI // фронт программы
{
    public static void getTablesFromDB()
    {
        List<string> tables = Manager.getTableList();
        Console.WriteLine("Select the task list to display");
        try
        {
            int index = Manager.insertInt();
            Manager.getListFromTable(tables, index);
            Console.WriteLine("");
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine(ex.Message);
            Console.WriteLine("");
            return;
        }
    }

    public static void addNewTask()
    {
        try
        {
            List<string> list = Manager.getTableList();
            string subject;
            DateTime date;
            Console.WriteLine("Select the task list to add a new task");
            int index = Manager.insertInt();
            Manager.checkIndexTable(list[index]);
            Console.WriteLine("");
            Console.WriteLine("Enter a new task");
            subject = Console.ReadLine();
            Console.WriteLine("");
            date = Manager.insertDataTime();
            Manager.add(list[index], index, subject, date);
            Console.WriteLine("New task added successfully");
            Console.WriteLine("");
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine(ex.Message);
            Console.WriteLine("");
            return;
        }
        catch (IndexOutOfRangeException)
        {
            Console.WriteLine("Error. There is nothing on this ID");
            Console.WriteLine("");
            return;
        }
    }

    public static void editTaskInTable()
    {
        try
        {
            List<string> list = Manager.getTableList();
            string subject;
            DateTime date;
            Console.WriteLine("Select the task list to edit the task");
            int indexTable = Manager.insertInt();
            Manager.checkIndexTable(list[indexTable]);
            Console.WriteLine("");
            Manager.getListFromTable(list, indexTable);
            Console.WriteLine("");
            Console.WriteLine("Select the task id to edit");
            int indexTask = Manager.insertInt();
            Manager.checkIndexString(indexTask, list[indexTable]);
            Console.WriteLine("");
            Console.WriteLine("Enter a new task");
            subject = Console.ReadLine();
            Console.WriteLine("");
            try
            {
                date = Manager.insertDataTime();
                Manager.add(list[indexTable], indexTable, subject, date);
                Manager.remove(list[indexTask], indexTask);
                Console.WriteLine("Task edited successfully");
                Console.WriteLine("");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("");
                return;
            }
        }
        catch (IndexOutOfRangeException)
        {
            Console.WriteLine("Error. There is nothing on this ID");
            Console.WriteLine("");
            return;
        }
    }

    public static void removeTaskFromTable()
    {
        try
        {
            List<string> list = Manager.getTableList();
            Console.WriteLine("Select the task list to remove the task");
            int indexTable = Manager.insertInt();
            Manager.checkIndexTable(list[indexTable]);
            Console.WriteLine("");
            Manager.getListFromTable(list, indexTable);
            Console.WriteLine("");
            Console.WriteLine("Select the task id to remove the task from table");
            int indexTask = Manager.insertInt();
            Manager.checkIndexString(indexTask, list[indexTable]);
            Manager.remove(list[indexTask], indexTask);
            Console.WriteLine("");
            Console.WriteLine("Task removed from the list successfully");
            Console.WriteLine("");
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine(ex.Message);
            Console.WriteLine("");
            return;
        }
        catch (IndexOutOfRangeException)
        {
            Console.WriteLine("Error. There is nothing on this ID");
            Console.WriteLine("");
            return;
        }
    }

    public static void createTableInStorage()
    {
        try
        {
            Console.WriteLine("Insert the name of new task list");
            string tableName = Console.ReadLine();
            Console.WriteLine("");
            Manager.createTableInStorage(tableName);
            Console.WriteLine("New task list created successfully");
            Console.WriteLine("");
        }
        catch (Exception)
        {
            Console.WriteLine("Name is wrong");
        }
    }

    public static void removeTableFromStorage()
    {
        try
        {
            List<string> list = Manager.getTableList();
            Console.WriteLine("Select the task list to remove");
            int indexTable = Manager.insertInt();
            Console.WriteLine("");
            Manager.removeTableFromStorage(list[indexTable]);
            Console.WriteLine("Task list removed successfully");
            Console.WriteLine("");
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine(ex.Message);
            Console.WriteLine("");
            return;
        }
        catch (IndexOutOfRangeException)
        {
            Console.WriteLine("Error. There is nothing on this ID");
            Console.WriteLine("");
            return;
        }
    }
}