using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace SlipsData
{
    public static class MarinaDB
    {
        public static SqlConnection GetConnection()  //method which needs a call and return
        {
            string connectionString = @"Data Source=localhost\SQLEXPRESS; Initial Catalog = Marina; Integrated Security = True";  //@ allows you to put the entire path 
            //regardless of special characters
            return new SqlConnection(connectionString);
        }
    }
}