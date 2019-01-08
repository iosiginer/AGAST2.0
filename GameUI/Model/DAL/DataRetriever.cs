using AGAST2.Infrastructure;
using MySql.Data;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using Newtonsoft.Json.Linq;

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
            this.InitializeQuestions();
            //Initialize
        }

        private void Initialize()
        {
            //connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DBconnection"].ConnectionString;
            connectionString = "Server=localhost;Database=agast;UserID=root;Password=123123";
            connection = new MySqlConnection(connectionString);

        }

        private JArray InitializeQuestions()
        {
            connection.Open();
            JArray arr = new JArray();
            MySqlCommand command = new MySqlCommand("SELECT * FROM  questions");
            command.CommandType = CommandType.Text;
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                JObject question = new JObject();
                {
                    for (int i = 0; i < reader.FieldCount ;i++)
                    {
                        question[i] = reader[i].ToString();
                    }
                    arr.Add(question);
                }
            }
            reader.Close();
            connection.Close();
            return arr;

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
            connection.Close();
            return arr;         
        }

        public JArray GetFactByQuery(string query)
    }
}
