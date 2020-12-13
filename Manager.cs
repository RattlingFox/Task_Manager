using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Data.SqlClient;
using System.Data.Common;
using Task_Manager;

class Manager // бэк программы
{
    
    public static void add(string list, int index, string subject,  DateTime date)
    {
        index = Manager.isExist(index, list);
        SqlConnection connect = DBUtils.GetDBConnection();
        connect.Open();
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = connect;
        cmd.CommandText = $"INSERT INTO {list} VALUES ({index},'{subject}','{date.ToString("yyyy.MM.dd")}')";
        using DbDataReader reader = cmd.ExecuteReader();
        connect.Close();
        connect.Dispose();
        Console.WriteLine("");

    }

    public static void remove(string list, int indexTask)
    {
        SqlConnection connect = DBUtils.GetDBConnection();
        connect.Open();
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = connect;
        cmd.CommandText = $"DELETE FROM {list} WHERE id = {indexTask}";
        using DbDataReader reader = cmd.ExecuteReader();
        connect.Close();
        connect.Dispose();
    }

   /* public List<Task> getList()
    {
        
    }*/

    public static int isExist(int index, string list)
    {
        SqlConnection connect = DBUtils.GetDBConnection();
        connect.Open();
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = connect;

        cmd.CommandText = ("Select id from " + list);
        using DbDataReader reader = cmd.ExecuteReader();
        for (index = 0 ; reader.Read(); index++)
        {
            reader.GetInt32(0);
        }
        
        connect.Close();
        connect.Dispose();
        return index;
    }

    public static int insertInt()
    {
        string indexUI;
        int indexUI_Int;
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
}
