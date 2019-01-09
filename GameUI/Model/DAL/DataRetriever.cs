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
        private static DataRetriever instance = null;
        private MySqlConnection connection;
        private string connectionString;

        private DataRetriever()
        {
            // Getting the connection string and creating a connection
            this.Initialize();
        }

        public static DataRetriever Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new DataRetriever();
                }
                return instance;
            }
        }

        private void Initialize()
        {
            connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DBconnection"].ConnectionString;
            connection = new MySqlConnection(connectionString);

        }

        public Dictionary<int,string> GetQuestionDictionary()
        {
            Dictionary<int, string> dict = new Dictionary<int,string>();
            int questionID = 0;
            int questionPhrase = 1;
            string commandString = "SELECT * FROM questions";
            MySqlCommand command = new MySqlCommand(commandString);
            command.Connection = connection;
            connection.Open();
            command.CommandType = CommandType.Text;
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                int key = reader.GetInt32(questionID);
                dict.Add(key, reader.GetString(questionPhrase));
            }
            reader.Close();
            command.Connection.Close();
            return dict;
        }

        public JArray GetDataFromDB(string query)
        {
            JArray dataArr = new JArray();
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
                dataArr.Add(row);

            }
            reader.Close();
            connection.Close();
            return dataArr;         
        }

        public string GetRandomArtist()
        {
            int nameColum = 0;
            string artistName = String.Empty;
            connection.Open();
            string query = "SELECT name FROM artist_facts ORDER BY RAND() limit 1";
            MySqlCommand command = new MySqlCommand(query, connection);
            command.CommandType = CommandType.Text;
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                artistName = reader.GetString(nameColum);
            }
            reader.Close();
            connection.Close();
            return artistName;

        }

        public string GetRandomRelease()
        {
            int nameColum = 0;
            string releaseName = "";
            connection.Open();
            string query = "SELECT name FROM release_facts ORDER BY RAND() limit 1";
            MySqlCommand command = new MySqlCommand(query, connection);
            command.CommandType = CommandType.Text;
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                releaseName = reader.GetString(nameColum);
            }
            reader.Close();
            connection.Close();
            return releaseName;
        }

    }
}
