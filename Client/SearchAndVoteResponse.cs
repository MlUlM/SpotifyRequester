using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace Client
{
    [Serializable]
    public class SearchAndVoteResponse
    {
        public SearchAndVote SearchAndVote { get; set; }

        public string ToComment()
        {
            return string.Join(Environment.NewLine,
                SearchAndVote
                    .Tracks
                    .Select((t, i) => $"{i}. {t.ToComment()}"));
        }
    }


    [Serializable]
    public class SearchAndVote
    {
        [JsonProperty("tracks")] public List<FullTrack> Tracks { get; set; }
    }
}