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
            List<string> tables = new List<string>();
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
                    tables.Add(reader.GetString(0));
                    Console.WriteLine(i + ")" + tables[i]);
                }
            connect.Close();
            connect.Dispose();
            Console.WriteLine("");
            return tables;
        }

        public static void getTableFromDB()
        {
            List<string> tables = storageDB.getTableList();
            Console.WriteLine("Select the task list to display");
            int index = Manager.insertInt();
            storageDB.getListInTable(tables, index);
            Console.WriteLine("");
        }


        public static void getListInTable(List<string> tables, int index)
        {
            SqlConnection connect = DBUtils.GetDBConnection();
            connect.Open();
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connect;
                Console.WriteLine("");
                cmd.CommandText = ("Select * from " + tables[index]);

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
        }

        public static void createTableInStorage()
        {
            Console.WriteLine("Insert the name of new task list");
            string tableName = Console.ReadLine();
            Console.WriteLine("");
            SqlConnection connect = DBUtils.GetDBConnection();
            connect.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connect;
            cmd.CommandText = $"CREATE TABLE [dbo].[{tableName}] ([Id] INT NOT NULL PRIMARY KEY, [_subject] VARCHAR(500) NULL, [_date] DATE NOT NULL)";
            using DbDataReader reader = cmd.ExecuteReader();
            connect.Close();
            connect.Dispose();
            Console.WriteLine("New task list created successfully");
            Console.WriteLine("");
        }

        public static void removeTableFromStorage()
        {
            List<string> list = storageDB.getTableList();
            Console.WriteLine("Select the task list to remove");
            int indexTable = Manager.insertInt();
            Console.WriteLine("");
            SqlConnection connect = DBUtils.GetDBConnection();
            connect.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connect;
            cmd.CommandText = $"DROP TABLE dbo.{list[indexTable]}";
            using DbDataReader reader = cmd.ExecuteReader();
            connect.Close();
            connect.Dispose();
            Console.WriteLine("");
        }
    }
}
