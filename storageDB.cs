using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data.Common;

namespace Task_Manager
{
    class storageDB
    {
        public static void getTableFromDB(Manager manager)
        {
            UI.clear(manager);
            SqlConnection connect = DBUtils.GetDBConnection();
            connect.Open();
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connect;
                Console.WriteLine("");
                cmd.CommandText = "Select * from table_1";

                using (DbDataReader reader = cmd.ExecuteReader())
                    if (reader.HasRows)
                        while (reader.Read())
                        {
                            long id = Convert.ToInt64(reader.GetValue(0));
                            string task_text = reader.GetString(1);
                            DateTime task_date = reader.GetDateTime(2);
                            Console.WriteLine("Id:" + id);
                            Console.WriteLine("Task Text:" + task_text);
                            Console.WriteLine("Task Date:" + task_date.ToString().Substring(0, 10));
                            manager.add(new Task(task_text, task_date));
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
    }
}
