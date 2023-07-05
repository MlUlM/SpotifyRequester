using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Threading.Tasks;
using Client;

namespace TestClient
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public async Task TestTrial()
        {
            var response = await HttpSpotify.PostCommentAsync(new CommentData()
            {
                Comment = "/t a"
            });

            Assert.IsTrue(HttpSpotify.TryParseNone(response, out var _));
        }


        [TestMethod]
        public async Task TestSearch()
        {
            var response = await HttpSpotify.PostCommentAsync(new CommentData()
            {
                Comment = "/sr hello"
            });

            Assert.IsTrue(HttpSpotify.TryParsSearch(response, out var _));
            HttpSpotify.TryParsSearch(response, out var search);

            Assert.AreEqual(search.Search.Tracks[0].Name, "鳥の詩");
        }


        [TestMethod]
        public async Task TestShowNext()
        {
            var response = await HttpSpotify.PostCommentAsync(new CommentData()
            {
                Comment = "/sn"
            });

            Assert.IsTrue(HttpSpotify.TryParseShowNext(response, out var _));
            HttpSpotify.TryParseShowNext(response, out var showNext);

            Assert.AreNotEqual(showNext.ShowNext.NextTrack.Name, "");
        }
    }
}