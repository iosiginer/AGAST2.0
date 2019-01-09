using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace AGAST2.Infrastructure
{
    public interface IDataRetriever
    {
        Dictionary<int, string> GetQuestionDictionary();
        JArray GetDataFromDB(string query);
        string GetRandomArtist();
        string GetRandomRelease();
    }
}
