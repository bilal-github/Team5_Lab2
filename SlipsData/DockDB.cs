using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace SlipsData
{
    [DataObject(true)]
    public static class DockDB
    {
        [DataObjectMethod(DataObjectMethodType.Select)]
        // retrieve docks
        public static List<Dock> GetDocks()
        {
            List<Dock> docks = new List<Dock>(); // empty list
            Dock dc = null; // for reading

            // create connection
            SqlConnection connection = MarinaDB.GetConnection();

            // create SELECT command
            string query = "SELECT ID, Name, WaterService, ElectricalService " +
                            "FROM Dock";
            SqlCommand cmd = new SqlCommand(query, connection);

            // run the Select query
            connection.Open();
            SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);

            // build dock object to return
            while (reader.Read()) // if there is a dock
            {
                dc = new Dock();
                dc.ID = (int)reader["ID"];
                dc.Name = (string)reader["Name"];
                dc.WaterService = (bool)reader["WaterService"];
                dc.ElectricalService = (bool)reader["ElectricalService"];
                docks.Add(dc);
            }
            reader.Close();

            return docks;
        }

       
    }
}