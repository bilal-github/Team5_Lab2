using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

namespace SlipsData
{
    [DataObject(true)]
    public static class SlipDB
    {
        [DataObjectMethod(DataObjectMethodType.Select)]
        // retrieve slips with given Dock ID
        public static List<Slip> GetSlipsByDockID(int dockID)
        {
            List<Slip> slips = new List<Slip>(); // empty list
            Slip sl = null; // for reading

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
                sl = new Slip();
                sl.ID = (int)reader["ID"];
                sl.Width = (int)reader["Width"];
                sl.Length = (int)reader["Length"];
                sl.DockID = (int)reader["DockID"];
                slips.Add(sl);
            }
            reader.Close();

            return slips;
        }

        
        //retrieve available slips
        [DataObjectMethod(DataObjectMethodType.Select)]
        public static List<Slip> GetAvailableSlips(int DockID)
        {
            List<Slip> availableSlips = new List<Slip>();
            Slip slip;

            using (SqlConnection connection = MarinaDB.GetConnection())
            {
                string selectQuery = "select S.ID,S.Width,S.Length, S.DockID from Slip S " +
                                    "Left join Lease L on L.SlipID = S.ID " +
                                    "Where L.ID is NULL and S.DockID = @DockID " +
                                    "order by 1";
                using (SqlCommand command = new SqlCommand(selectQuery, connection))
                {

                    connection.Open();

                    command.Parameters.AddWithValue("DockID", DockID);

                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        slip = new Slip();
                        slip.ID = (int)reader["ID"];
                        slip.Width = (int)reader["Width"];
                        slip.Length = (int)reader["Length"];
                        slip.DockID = (int)reader["DockID"];
                        availableSlips.Add(slip);
                    }
                    reader.Close();
                }
            }
            return availableSlips;
        }
    }
}