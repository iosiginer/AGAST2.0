using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure
{
    public class ArtistData
    {
        private string _artistName;
        private string _band;
        private string _album;
        private string _track;

        public string ArtistName { get => _artistName; set => _artistName = value; }
        public string Band { get => _band; set => _band = value; }
        public string Album { get => _album; set => _album = value; }
        public string Track { get => _track; set => _track = value; }

        public ArtistData(string artistName = null, string band = null, string album = null, string track = null)
        {
            ArtistName = artistName;
            Band = band;
            Album = album;
            Track = track;
        }
    }
}
