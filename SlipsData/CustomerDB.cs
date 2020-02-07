using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;


namespace SlipsData
{
    public static class CustomerDB
    {
        public static void AddCustomer(string FirstName, string LastName, string Phone, string City)
        {
            Customer customer;
            using (SqlConnection connection = MarinaDB.GetConnection())
            {
                string insertQuery = "INSERT INTO Customer(FirstName,LastName,Phone,City) " +
                                                   "Values(@FirstName,@LastName,@Phone,@City)";
                using(SqlCommand command = new SqlCommand(insertQuery, connection))
                {
                    connection.Open();
                    command.Parameters.AddWithValue("FirstName",FirstName);
                    command.Parameters.AddWithValue("LastName", LastName);
                    command.Parameters.AddWithValue("Phone", Phone);
                    command.Parameters.AddWithValue("City", City);
                    command.ExecuteNonQuery();

                }
            }



        }



    }
}