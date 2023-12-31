﻿using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace Client
{
    [Serializable]
    public class SearchResponse
    {
        public Search Search { get; set; }

        public string ToComment()
        {
            return string.Join(Environment.NewLine,
                Search
                    .Tracks
                    .Select((t, i) => $"{i}. {t.ToComment()}"));
        }
    }


    [Serializable]
    public class Search
    {
        [JsonProperty("tracks")] public List<FullTrack> Tracks { get; set; }
    }
}