using AGAST2.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;

namespace AGAST2.GameUI.Model.DAL
{
    public class DataRetriever : IDataRetriever
    {
        private SqlConnection connection;
        private string connectionString;
        private Random randy;


        private DataRetriever()
        {
            this.Initialize();
        }

        private void Initialize()
        {
            //connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DBconnection"].ConnectionString;
            //connection = new MySqlConnection(connectionString);
            //connection.Open();
            
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
