using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;

namespace BackEnd.Models
{
    public class connection
    {
        public static SqlConnection my_sql_connection;
        public static SqlConnection getConnection()
        {
            if (my_sql_connection == null)
            {
                my_sql_connection = new SqlConnection();
                my_sql_connection.ConnectionString = ConfigurationManager.ConnectionStrings["mydb"].ToString();
                my_sql_connection.Open();
            }
            return my_sql_connection;
        }
    }
}