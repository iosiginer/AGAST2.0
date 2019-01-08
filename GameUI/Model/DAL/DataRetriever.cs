using AGAST2.Infrastructure;
using MySql.Data;
using MySql.Data.MySqlClient;
using System;
using System.Data;

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

        private void InitializeQuestions()
        {
            //connection.Open();

            //MySqlCommand command = new MySqlCommand();
            //command.CommandType = CommandType.Text;
            //MySqlDataReader reader = command.ExecuteReader();
            //while (reader.Read())
            //{

            //}
        }

        public string GetDataByQuery(string query)
        {
            //int i = 0;
            String result = "";
            connection.Open();
            MySqlCommand command = new MySqlCommand(query, connection);
            command.CommandType = CommandType.Text;
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                result = reader.ToString();
            }
            connection.Close();
            return result;         
        }
    }
}
