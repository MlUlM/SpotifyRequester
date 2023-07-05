using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    [Serializable]
    public class SearchResponse
    {
        public Search Search { get; set; }
    }


    [Serializable]
    public class Search
    {
        [JsonProperty("tracks")] public List<FullTrack> Tracks { get; set; }
    }
}