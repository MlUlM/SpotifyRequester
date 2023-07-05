using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Client
{
    [Serializable]
    public class CommentData
    {
        [JsonProperty("comment")] public string Comment { get; set; }
    }
}