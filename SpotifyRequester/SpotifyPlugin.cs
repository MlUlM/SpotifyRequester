using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Client;
using Plugin;

namespace SpotifyRequester
{
    public class SpotifyPlugin : IPlugin
    {
        private readonly object _lockObject = new object();
        private bool _voting;

        public async void AutoRun()
        {
            // var url =
            //     "https://accounts.spotify.com/authorize?client_id=a9893b53bdd248deaf0fe498669d49d6&scope=user-read-playback-state%2C+user-modify-playback-state&state=DoQYGecD60tzmBga&redirect_uri=http%3A%2F%2Flocalhost%3A8000%2Fcallback&response_type=code";
            //
            // using (var client = new HttpClient())
            // {
            //     await client.GetAsync(url);
            // }


            Host.ReceivedComment += Host_ReceivedComment;
        }

        public void Run()
        {
        }

        public IPluginHost Host { get; set; }
        public bool IsAutoRun => true;
        public string Description => "コメントからSpotifyの曲をリクエストします。";
        public string Version => "1.0.0";
        public string Name => "SpotifyRequester";

        private async void Host_ReceivedComment(object sender, ReceivedCommentEventArgs e)
        {
            try
            {
                foreach (var comment in e.CommentDataList)
                {
                    var data = new CommentData
                    {
                        Comment = comment.Comment
                    };

                    var response = await SpotifyHttp.PostCommentAsync(data);
                    ProcessResponseAsync(response);
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
                throw;
            }
        }


        private bool ProcessResponseAsync(string response)
        {
            if (SpotifyHttp.TryParsSearch(response, out var search)) return Host.SendOwnerComment(search.ToComment());

            if (SpotifyHttp.TryParseSearchAndVote(response, out var sv))
            {
                if (IsVoting())
                {
                    Host.SendOwnerComment("現在投票中のためリクエストは無効になりました。");
                }
                else
                {
                    SetVote(true);
                    var tracks = string.Join(" ", sv.SearchAndVote.Tracks
                        .Take(9)
                        .Select(track => track.Name));

                    Host.SendOwnerComment($"/vote start 次の曲 {tracks}");
                }
            }

            if (SpotifyHttp.TryParseShowNext(response, out var showNext)) return Host.SendComment(showNext.ToComment());


            return true;
        }

        private void VoteTimeoutHandler(bool vote)
        {
            Task.Run(async () =>
            {
                await Task.Delay(10000);
                Host.SendOwnerComment("/vote stop");

                Host.SendOwnerComment("/vote showresult");

                SetVote(false);
            });
        }

        private bool IsVoting()
        {
            lock (_lockObject)
            {
                return _voting;
            }
        }


        private void SetVote(bool vote)
        {
            lock (_lockObject)
            {
                _voting = vote;
            }
        }
    }
}