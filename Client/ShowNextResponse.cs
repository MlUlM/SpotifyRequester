using System;
using Newtonsoft.Json;

namespace Client
{
    [Serializable]
    public class ShowNextResponse
    {
        public ShowNext ShowNext { get; set; }

        public string ToComment()
        {
            return $"Next {ShowNext.NextTrack.ToComment()}";
        }
    }


    [Serializable]
    public class ShowNext
    {
        [JsonProperty("next_track")] public FullTrack NextTrack { get; set; }
    }
}