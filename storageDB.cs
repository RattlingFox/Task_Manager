using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data.Common;

namespace Task_Manager
{
    class storageDB
    {
        public static List<string> getTableList()
        {
            List<string> indexTables = new List<string>();
            SqlConnection connect = DBUtils.GetDBConnection();
            connect.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connect;
            Console.WriteLine("");
            cmd.CommandText = "SELECT TABLE_NAME FROM information_schema.TABLES";
            using DbDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
                //while (reader.Read())
                for (int i = 0 ; reader.Read() ; i++)
                {
                    indexTables.Add(reader.GetString(0));
                    Console.WriteLine(i + ")" + indexTables[i]);
                }
            connect.Close();
            connect.Dispose();
            Console.WriteLine("");
            return indexTables;
        }

        public static void getTableFromDB()
        {
            List<string> indexTables = storageDB.getTableList();
            Console.WriteLine("Select the task list to display");
            int index = UI.insertInt();
            SqlConnection connect = DBUtils.GetDBConnection();
            connect.Open();
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connect;
                Console.WriteLine("");
                cmd.CommandText = ("Select * from " + indexTables[index]);

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
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e);
                Console.WriteLine(e.StackTrace);
            }
            finally
            {
                connect.Close();
                connect.Dispose();
                
            }
            Console.WriteLine("");
        }

        public static void addNewTask()
        {
            List<string> list = storageDB.getTableList();
            Console.WriteLine("Select the task list to add a new task");
            int index = UI.insertInt();
            SqlConnection connect = DBUtils.GetDBConnection();
            connect.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connect;
            Console.WriteLine("");
            string subject;
            DateTime date;
            Console.WriteLine("Enter a new task");
            subject = Console.ReadLine();
            Console.WriteLine("");
            try
            {
                date = UI.insertDataTime();
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("");
                return;
            }
            cmd.CommandText = $"INSERT INTO {list[index]} VALUES ({index},'{subject}','{date.ToString("yyyy.MM.dd")}')";
            using DbDataReader reader = cmd.ExecuteReader();
            connect.Close();
            connect.Dispose();
            Console.WriteLine("");
        }

        public static void editTaskInTable()
        {

        }


        public static void removeTaskFromTable()
        {

        }


        public static void removeTableFromStorage()
        {

        }
    }
}
