using AGAST2.Infrastructure;
using MySql.Data;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;

namespace AGAST2.GameUI.DAL
{
    public class DataRetriever : IDataRetriever
    {
        private MySqlConnection connection;
        private string connectionString;
        private Random randy;


        public DataRetriever()
        {
            this.Initialize();
            //this.InitializeQuestions();
        }

        private void Initialize()
        {
            //connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DBconnection"].ConnectionString;
            connectionString = "Database=agast;Data Source=localhost;User Id=root;Password=123123";
            connection = new MySqlConnection(connectionString);

        }

        public Dictionary<int,string> InitializeQuestions()
        {
            Dictionary<int, string> dict = new Dictionary<int,string>();
            string commandString = "SELECT * FROM questions";
            MySqlCommand command = new MySqlCommand(commandString);
            command.Connection = connection;
            connection.Open();
            command.CommandType = CommandType.Text;
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                int key = reader.GetInt32(0);
                dict.Add(key, reader.GetString(1));
            }
            reader.Close();
            command.Connection.Close();
            return dict;
        }

        public JArray GetQuestionByQuery(string query)
        {
            JArray arr = new JArray();
            connection.Open();
            MySqlCommand command = new MySqlCommand(query, connection);
            command.CommandType = CommandType.Text;
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                JObject row = new JObject();
                for (int i = 0; i < reader.FieldCount; i++) 
                {
                    string columName = reader.GetName(i);
                    row[columName] = reader.GetString(i); 
                }
                arr.Add(row);

            }
            reader.Close();
            connection.Close();
            return arr;         
        }

    }
}
