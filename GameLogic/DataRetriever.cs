using AGAST2.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;

namespace AGAST2.GameLogic
{
    public class DataRetriever : IDataRetriever
    {
        private Random randy;


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
