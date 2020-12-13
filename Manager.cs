using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.Common;
using Task_Manager;
//using System.Text;
//using System.IO;

class Manager // бэк программы
{
    public static List<string> getTableList()
    {
        List<string> tables = new List<string>();
        SqlConnection connect = DBUtils.GetDBConnection();
        connect.Open();
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = connect;
        Console.WriteLine("");
        cmd.CommandText = "SELECT tasks_list_name FROM tasks_list";
        using DbDataReader reader = cmd.ExecuteReader();
        if (reader.HasRows)
            for (int i = 0; reader.Read(); i++)
            {
                tables.Add(reader.GetString(0));
                Console.WriteLine(i + ")" + tables[i]);
            }
        connect.Close();
        connect.Dispose();
        Console.WriteLine("");
        return tables;
    }
    public static void getListFromTable(List<string> tables, int index)
    {
        SqlConnection connect = DBUtils.GetDBConnection();
        connect.Open();
        try
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connect;
            Console.WriteLine("");
            cmd.CommandText = $"Select * from tasks WHERE tasks_list_name = '{tables[index]}'";
            using DbDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
                while (reader.Read())
                {
                    long id = Convert.ToInt64(reader.GetValue(0));
                    string task_text = reader.GetString(1);
                    DateTime task_date = reader.GetDateTime(2);
                    Console.WriteLine("Id:" + id);
                    Console.WriteLine("Task Text:" + task_text);
                    Console.WriteLine("Task Date:" + task_date.ToString().Substring(0, 10));
                }
        }
        catch (Exception)
        {
            Console.WriteLine("Error. No task list with this ID");
        }
        finally
        {
            connect.Close();
            connect.Dispose();
        }
    }

    public static void add(string list, string subject,  DateTime date)
    {
        SqlConnection connect = DBUtils.GetDBConnection();
        connect.Open();
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = connect;
        cmd.CommandText = $"INSERT INTO tasks VALUES ('{subject}','{date.ToString("yyyy.MM.dd")}','{list}')";
        using DbDataReader reader = cmd.ExecuteReader();
        connect.Close();
        connect.Dispose();
    }

    public static void remove(string list, int indexTask)
    {
        SqlConnection connect = DBUtils.GetDBConnection();
        connect.Open();
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = connect;
        cmd.CommandText = $"DELETE FROM tasks WHERE tasks_list_name = '{list}' AND id = {indexTask}";
        using DbDataReader reader = cmd.ExecuteReader();
        connect.Close();
        connect.Dispose();
    }

    public static int isExist(string tableName)
    {
        int index;
        SqlConnection connect = DBUtils.GetDBConnection();
        connect.Open();
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = connect;
        cmd.CommandText = $"SELECT id FROM tasks";
        using DbDataReader reader = cmd.ExecuteReader();
        for (index = 0 ; reader.Read(); index++)
        {
            reader.GetInt32(0);
        }
        
        connect.Close();
        connect.Dispose();
        return index;
    }

    public static void checkIndexTable(string list)
    {
        SqlConnection connect = DBUtils.GetDBConnection();
        connect.Open();
        try
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connect;
            Console.WriteLine("");
            cmd.CommandText = $"Select * FROM tasks WHERE tasks_list_name = '{list}'";
            using DbDataReader reader = cmd.ExecuteReader();
        }
        finally
        {
            connect.Close();
            connect.Dispose();
        }
    }

    public static void checkIndexString(int task, string list)
    {
        SqlConnection connect = DBUtils.GetDBConnection();
        connect.Open();
        try
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connect;
            Console.WriteLine("");
            cmd.CommandText = $"SELECT * FROM tasks WHERE tasks_list_name = '{list}' AND id = {task}";
            using DbDataReader reader = cmd.ExecuteReader();
            if (!reader.HasRows)
            {

            }
        }
        finally
        {
            connect.Close();
            connect.Dispose();
        }
    }

    public static int insertInt(string text)
    {
        string indexUI;
        int indexUI_Int;
        Console.WriteLine(text);
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
                insertInt(text);
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

    public static void createTableInStorage(string tableName)
    {
        //int index = Manager.isExist(tableName);
        SqlConnection connect = DBUtils.GetDBConnection();
        connect.Open();
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = connect;
        cmd.CommandText = $"INSERT INTO tasks_list VALUES ('{tableName}')";
        using DbDataReader reader = cmd.ExecuteReader();
        connect.Close();
        connect.Dispose();
    }

    public static void removeTableFromStorage(string list)
    {
        SqlConnection connect = DBUtils.GetDBConnection();
        connect.Open();
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = connect;
        cmd.CommandText = $"DELETE FROM tasks_list WHERE tasks_list_name = '{list}'";
        using DbDataReader reader = cmd.ExecuteReader();
        connect.Close();
        connect.Dispose();
    }
}
