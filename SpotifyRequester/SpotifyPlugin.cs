using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Windows.Forms;
using System.Xml.Linq;
using Newtonsoft.Json;
using Plugin;

namespace SpotifyRequester
{
    public class CommentData
    {
        [JsonProperty("comment")] public string Comment { get; set; }
    }


    public class SpotifyPlugin : IPlugin
    {
        public async void AutoRun()
        {
            // var url =
            //     "https://accounts.spotify.com/authorize?client_id=a9893b53bdd248deaf0fe498669d49d6&scope=user-read-playback-state%2C+user-modify-playback-state&state=DoQYGecD60tzmBga&redirect_uri=http%3A%2F%2Flocalhost%3A8000%2Fcallback&response_type=code";
            //
            // using (var client = new HttpClient())
            // {
            //     await client.GetAsync(url);
            // }


            this.Host.ReceivedComment += Host_ReceivedComment;
        }

        private async void Host_ReceivedComment(object sender, ReceivedCommentEventArgs e)
        {
            try
            {
                foreach (var comment in e.CommentDataList)
                {
                    using (var client = new HttpClient())
                    {
                        var json = JsonConvert.SerializeObject(new CommentData
                        {
                            Comment = comment.Comment,
                        });
                        var content = new StringContent(json, Encoding.UTF8, "application/json");
                        await client.PostAsync("http://localhost:8000/comment", content);
                    }
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
                throw;
            }
        }

        public void Run()
        {
        }

        public IPluginHost Host { get; set; }
        public bool IsAutoRun => true;
        public string Description => "コメントからSpotifyの曲をリクエストします。";
        public string Version => "1.0.0";
        public string Name => "SpotifyRequester";
    }
}