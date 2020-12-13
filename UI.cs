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
        string text = "Select the task list to display";
        try
        {
            int index = Manager.insertInt(text);
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
            string text = "Select the task list to add a new task";
            int index = Manager.insertInt(text);
            Manager.checkIndexTable(list[index]);
            Console.WriteLine("Enter a new task");
            subject = Console.ReadLine();
            Console.WriteLine("");
            date = Manager.insertDataTime();
            Manager.add(list[index], subject, date);
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
            string textList = "Select the task list to edit the task";
            int tableId = Manager.insertInt(textList);
            Manager.checkIndexTable(list[tableId]);
            Console.WriteLine("");
            Manager.getListFromTable(list, tableId);
            Console.WriteLine("");
            string textTask = "Select the task id to edit";
            int taskId = Manager.insertInt(textTask);
            Manager.checkIndexString(taskId, list[tableId]);
            Console.WriteLine("");
            Console.WriteLine("Enter a new task");
            subject = Console.ReadLine();
            Console.WriteLine("");
            date = Manager.insertDataTime();
            Manager.add(list[tableId], subject, date);
            Manager.remove(list[tableId], taskId);
            Console.WriteLine("Task edited successfully \n");
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
            string text_list = "Select the task list to remove the task";
            int indexTable = Manager.insertInt(text_list);
            Manager.checkIndexTable(list[indexTable]);
            Manager.getListFromTable(list, indexTable);
            Console.WriteLine("");
            string text_task = "Select the task id to remove the task from table";
            int indexTask = Manager.insertInt(text_task);
            Manager.checkIndexString(indexTask, list[indexTable]);
            Manager.remove(list[indexTable], indexTask);
            Console.WriteLine("");
            Console.WriteLine("Task removed from the list successfully");
            Console.WriteLine("");
        }
        catch (ArgumentOutOfRangeException)
        {
            Console.WriteLine("Error. There is nothing on this ID");
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
            string text = "Select the task list to remove";
            int indexTable = Manager.insertInt(text);
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