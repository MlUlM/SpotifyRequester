using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Client
{
    public class HttpSpotify
    {
        public static async Task<string> PostCommentAsync(CommentData comment)
        {
            using (var client = new HttpClient())
            {
                var json = JsonConvert.SerializeObject(comment);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var res = await client.PostAsync("http://localhost:8000/comment", content);
                var response = await res.Content.ReadAsStringAsync();
                return response;
            }
        }


        public static bool TryParseNone(string response, out NoneResponse none)
        {
            try
            {
                none = JsonConvert.DeserializeObject<NoneResponse>(response);
                return true;
            }
            catch
            {
                none = null;
                return false;
            }
        }


        public static bool TryParsSearch(string response, out SearchResponse none)
        {
            try
            {
                none = JsonConvert.DeserializeObject<SearchResponse>(response);
                return true;
            }
            catch
            {
                none = null;
                return false;
            }
        }


        public static bool TryParseShowNext(string response, out ShowNextResponse none)
        {
            try
            {
                none = JsonConvert.DeserializeObject<ShowNextResponse>(response);
                return true;
            }
            catch
            {
                none = null;
                return false;
            }
        }
    }
}