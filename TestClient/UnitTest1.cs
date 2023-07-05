using System.Threading.Tasks;
using Client;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestClient
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public async Task TestTrial()
        {
            await SpotifyHttp.PostCommentAsync(new CommentData
            {
                Comment = "/t a"
            });
        }


        [TestMethod]
        public async Task TestSearch()
        {
            var response = await SpotifyHttp.PostCommentAsync(new CommentData
            {
                Comment = "/sr 鳥の詩"
            });

            Assert.IsTrue(SpotifyHttp.TryParsSearch(response, out var _));
            SpotifyHttp.TryParsSearch(response, out var search);

            Assert.AreEqual(search.Search.Tracks[0].Name, "鳥の詩");
        }


        [TestMethod]
        public async Task TestSearchAndVote()
        {
            var response = await SpotifyHttp.PostCommentAsync(new CommentData
            {
                Comment = "/sv 鳥の詩"
            });

            Assert.IsTrue(SpotifyHttp.TryParseSearchAndVote(response, out var _));
            SpotifyHttp.TryParseSearchAndVote(response, out var sv);

            Assert.AreEqual(sv.SearchAndVote.Tracks[0].Name, "鳥の詩");
        }


        [TestMethod]
        public async Task TestShowNext()
        {
            var response = await SpotifyHttp.PostCommentAsync(new CommentData
            {
                Comment = "/sn"
            });

            Assert.IsTrue(SpotifyHttp.TryParseShowNext(response, out var _));
            SpotifyHttp.TryParseShowNext(response, out var showNext);

            Assert.AreNotEqual(showNext.ShowNext.NextTrack.Name, "");
        }
    }
}