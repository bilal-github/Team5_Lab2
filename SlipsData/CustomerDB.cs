using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;


namespace SlipsData
{
    [DataObject]
    public static class CustomerDB
    {
        public static void AddCustomer(string FirstName, string LastName, string Phone, string City,string UserName)
        {
            Customer customer;
            using (SqlConnection connection = MarinaDB.GetConnection())
            {
                string insertQuery = "INSERT INTO Customer(FirstName,LastName,Phone,City,UserName) " +
                                                   "Values(@FirstName,@LastName,@Phone,@City,@UserName)";
                using(SqlCommand command = new SqlCommand(insertQuery, connection))
                {
                    connection.Open();
                    command.Parameters.AddWithValue("FirstName",FirstName);
                    command.Parameters.AddWithValue("LastName", LastName);
                    command.Parameters.AddWithValue("Phone", Phone);
                    command.Parameters.AddWithValue("City", City);
                    command.Parameters.AddWithValue("UserName", UserName);
                    command.ExecuteNonQuery();
                }
            }
        }
        //written by Eli
        // retrieve slips with given Customer ID
        [DataObjectMethod(DataObjectMethodType.Select)]        
        public static List<Slip> GetSlipsByCustID(string UserName)
        {
            List<Slip> CustomerLeases = new List<Slip>(); // empty list
            Slip slip = null; // for reading

            // create connection
            SqlConnection connection = MarinaDB.GetConnection();

            // create SELECT command
            string query = "SELECT l.ID as LeaseID, s.ID as SlipID, Width, Length, DockID " +
                           "FROM Slip s " +
                           "INNER JOIN Lease l " +
                           "ON s.ID = l.SlipID " +
                           "    INNER JOIN Customer c " +
                           "    ON l.CustomerID = c.ID " +
                           "WHERE c.UserName = @UserName";
            SqlCommand cmd = new SqlCommand(query, connection);

            // supply parameter value
            cmd.Parameters.AddWithValue("@UserName", UserName);

            // run the Select query
            connection.Open();
            SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);

            // build slip object to return
            while (reader.Read()) // if there is a slip on this dock
            {
                slip = new Slip();
                slip.LeaseID = (int)reader["LeaseID"];
                slip.ID = (int)reader["SlipID"];
                slip.Width = (int)reader["Width"];
                slip.Length = (int)reader["Length"];
                slip.DockID = (int)reader["DockID"];
                CustomerLeases.Add(slip);
            }
            reader.Close();
            return CustomerLeases;
        }
    }
}