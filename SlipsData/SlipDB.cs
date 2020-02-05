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
    }
}