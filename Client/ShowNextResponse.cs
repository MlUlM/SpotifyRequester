using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    [Serializable]
    public class ShowNextResponse
    {
        public ShowNext ShowNext { get; set; }
    }


    [Serializable]
    public class ShowNext
    {
        [JsonProperty("next_track")] public FullTrack NextTrack { get; set; }
    }
}