using AGAST2.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace AGAST2.GameUI.Model.DAL
{
    public class DataRetriever : IDataRetriever
    {
        private MySqlConnection connection;
        private string connectionString;
        private Random randy;


        private DataRetriever()
        {
            this.Initialize();
        }

        private void Initialize()
        {
            connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DBconnection"].ConnectionString;
            connection = new MySqlConnection(connectionString);
            
        }

        //public string GetFact(string query)
        //{
        //    connection.Open();
        //    MySqlCommand command = new MySqlCommand(query, connection);

        //}
    }
}
