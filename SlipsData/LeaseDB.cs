using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace SlipsData
{

    [DataObject]
    public static class LeaseDB
    {

        [DataObjectMethod(DataObjectMethodType.Insert)]
        public static void AddLease(int SlipID,string UserName)
        {
            int CustomerID = GetCustomerID(UserName);
            Customer customer;
            using (SqlConnection connection = MarinaDB.GetConnection())
            {


                string insertQuery = "INSERT INTO Lease(SlipID,CustomerID) " +
                                    "Values(@SlipID,@CustomerID)";
                using (SqlCommand command = new SqlCommand(insertQuery, connection))
                {
                    connection.Open();
                    command.Parameters.AddWithValue("SlipID", SlipID);
                    command.Parameters.AddWithValue("CustomerID", CustomerID);
                    command.ExecuteNonQuery();
                }
            }
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public static int GetCustomerID(string UserName)
        {
            int CustomerID = -1;
            using (SqlConnection connection = MarinaDB.GetConnection())
            {
                string insertQuery = "select ID from Customer where UserName = @UserName";
                using (SqlCommand command = new SqlCommand(insertQuery, connection))
                {
                    connection.Open();
                    command.Parameters.AddWithValue("UserName", UserName);
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        CustomerID = (int)reader[0];
                    }
                }
            }
            return CustomerID;
        }
    }
}