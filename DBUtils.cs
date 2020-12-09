using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;

namespace Task_Manager
{
    class DBUtils
    {
        public static SqlConnection GetDBConnection()
        {
            string datasource = @"DESKTOP-2VGA775";

            string database = "task_DB";
            string username = "sa";
            string password = "12345678";

            return DBSQLServerUtils.GetDBConnection(datasource, database, username, password);

        }
    }
}
