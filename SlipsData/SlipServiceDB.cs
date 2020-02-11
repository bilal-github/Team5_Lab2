using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;


namespace SlipsData
{
    [DataObject(true)] // Initialize it as a data object
    public static class SlipServiceDB
    {
        // Code by Elias Nahas
        [DataObjectMethod(DataObjectMethodType.Select)] // Select object method
        // retrieve slips with given Dock ID
        public static List<SlipServices> GetSlipsByDockID(int dockID) // Get slips with the provided Dock ID
        {
            List<SlipServices> slips = new List<SlipServices>(); // empty list
            SlipServices sl = null; // for reading

            // create connection
            SqlConnection connection = MarinaDB.GetConnection();

            // create SELECT command
            string query = "SELECT ID, Width, Length, DockID " +
                           "FROM Slip " +
                           "WHERE DockID = @DockID";
            SqlCommand cmd = new SqlCommand(query, connection);

            // supply parameter value
            cmd.Parameters.AddWithValue("@DockID", dockID);

            // run the Select query
            connection.Open();
            SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);

            // build slip object to return
            while (reader.Read()) // if there is a slip on this dock
            {
                sl = new SlipServices();
                sl.ID = (int)reader["ID"];
                sl.Width = (int)reader["Width"];
                sl.Length = (int)reader["Length"];
                sl.DockID = (int)reader["DockID"];
                slips.Add(sl);
            }
            reader.Close();

            return slips;
        }

        /*
 * Bilal Ahmad
 * Lab 2
 * Feb 9/2020
 * 
 */
        //retrieve available slips
        [DataObjectMethod(DataObjectMethodType.Select)]
        public static List<SlipServices> GetAvailableSlips(int DockID) // Get available slips by a given Dock ID
        {
            List<SlipServices> availableSlips = new List<SlipServices>();
            SlipServices slip;

            using (SqlConnection connection = MarinaDB.GetConnection())
            {
                // SQL command using joined tables to create a table with dimensions and services available
                string selectQuery = "select S.ID,S.Width,S.Length, D.ElectricalService,D.WaterService from Slip S " +
                                    "inner join Dock D on D.ID = S.DockID " +
                                    "Left join Lease L on L.SlipID = S.ID " +
                                    "Where L.ID is NULL and S.DockID = @DockID " +
                                    "order by S.ID";
                using (SqlCommand command = new SqlCommand(selectQuery, connection))
                {

                    connection.Open();

                    command.Parameters.AddWithValue("DockID", DockID);

                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        slip = new SlipServices();
                        slip.ID = (int)reader["ID"];
                        slip.Width = (int)reader["Width"];
                        slip.Length = (int)reader["Length"];
                        slip.ElectricalService = (bool)reader["ElectricalService"];
                        slip.WaterService = (bool)reader["WaterService"];
                        availableSlips.Add(slip);
                    }
                    reader.Close();
                }
            }
            return availableSlips;
        }
    }
}