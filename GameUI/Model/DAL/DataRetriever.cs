using AGAST2.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace AGAST2.GameLogic.DAL
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
            connection.Open();
            
        }

        public string GetFact()
        {
            connection.
        }

        public ArtistData GetArtistDataFromName(string artist)
        {
            throw new NotImplementedException();
        }

        public ArtistData GetArtistDataFromTrack(string track)
        {
            throw new NotImplementedException();
        }

        public List<string> GetArtistOptionsByNotName(string artistName)
        {
            throw new NotImplementedException();
        }

        public string GetRandomAlbum()
        {
            throw new NotImplementedException();
        }

        public string GetRandomArtist()
        {
            throw new NotImplementedException();
        }

        public string GetRandomTrack()
        {
            throw new NotImplementedException();
        }

        public List<string> GetTrackOptionsByNotArtist(string artistName)
        {
            throw new NotImplementedException();
        }
    }
}
