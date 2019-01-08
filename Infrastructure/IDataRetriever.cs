using System;
using System.Collections.Generic;
using System.Text;

namespace AGAST2.Infrastructure
{
    public interface IDataRetriever
    {
        ArtistData GetArtistDataFromName(string artist);
        ArtistData GetArtistDataFromTrack(string track);
        string GetRandomArtist();
        string GetRandomTrack();
        string GetRandomAlbum();
        List<string> GetArtistOptionsByNotName(string artistName);
        List<string> GetTrackOptionsByNotArtist(string artistName); 
    }
}
