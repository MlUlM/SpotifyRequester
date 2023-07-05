using System;
using Newtonsoft.Json;

namespace Client
{
    public class FullTrack
    {
        [JsonProperty("album")] public Album Album { get; set; }

        [JsonProperty("artists")] public TemperaturesArtist[] Artists { get; set; }

        [JsonProperty("available_markets")] public string[] AvailableMarkets { get; set; }

        [JsonProperty("disc_number")] public long DiscNumber { get; set; }

        [JsonProperty("duration_ms")] public long DurationMs { get; set; }

        [JsonProperty("explicit")] public bool Explicit { get; set; }

        [JsonProperty("external_ids")] public ExternalIds ExternalIds { get; set; }

        [JsonProperty("external_urls")] public ExternalUrls ExternalUrls { get; set; }

        [JsonProperty("href")] public string Href { get; set; }

        [JsonProperty("id")] public string Id { get; set; }

        [JsonProperty("is_playable")] public bool IsPlayable { get; set; }

        [JsonProperty("linked_from")] public LinkedFrom LinkedFrom { get; set; }

        [JsonProperty("restrictions")] public Restrictions Restrictions { get; set; }

        [JsonProperty("name")] public string Name { get; set; }

        [JsonProperty("popularity")] public long Popularity { get; set; }

        [JsonProperty("preview_url")] public string PreviewUrl { get; set; }

        [JsonProperty("track_number")] public long TrackNumber { get; set; }

        [JsonProperty("type")] public string Type { get; set; }

        [JsonProperty("uri")] public string Uri { get; set; }

        [JsonProperty("is_local")] public bool IsLocal { get; set; }


        public string ToComment()
        {
            return $"[Name={Name}, Id={Id}, Uri={Uri}]";
        }
    }

    public class Album
    {
        [JsonProperty("album_type")] public string AlbumType { get; set; }

        [JsonProperty("total_tracks")] public long TotalTracks { get; set; }

        [JsonProperty("available_markets")] public string[] AvailableMarkets { get; set; }

        [JsonProperty("external_urls")] public ExternalUrls ExternalUrls { get; set; }

        [JsonProperty("href")] public string Href { get; set; }

        [JsonProperty("id")] public string Id { get; set; }

        [JsonProperty("images")] public Image[] Images { get; set; }

        [JsonProperty("name")] public string Name { get; set; }

        [JsonProperty("release_date")] public string ReleaseDate { get; set; }

        [JsonProperty("release_date_precision")]
        public string ReleaseDatePrecision { get; set; }

        [JsonProperty("restrictions")] public Restrictions Restrictions { get; set; }

        [JsonProperty("type")] public string Type { get; set; }

        [JsonProperty("uri")] public string Uri { get; set; }

        [JsonProperty("copyrights")] public Copyright[] Copyrights { get; set; }

        [JsonProperty("external_ids")] public ExternalIds ExternalIds { get; set; }

        [JsonProperty("genres")] public string[] Genres { get; set; }

        [JsonProperty("label")] public string Label { get; set; }

        [JsonProperty("popularity")] public long Popularity { get; set; }

        [JsonProperty("album_group")] public string AlbumGroup { get; set; }

        [JsonProperty("artists")] public AlbumArtist[] Artists { get; set; }
    }

    public class AlbumArtist
    {
        [JsonProperty("external_urls")] public ExternalUrls ExternalUrls { get; set; }

        [JsonProperty("href")] public string Href { get; set; }

        [JsonProperty("id")] public string Id { get; set; }

        [JsonProperty("name")] public string Name { get; set; }

        [JsonProperty("type")] public string Type { get; set; }

        [JsonProperty("uri")] public string Uri { get; set; }
    }

    public class ExternalUrls
    {
        [JsonProperty("spotify")] public string Spotify { get; set; }
    }

    public class Copyright
    {
        [JsonProperty("text")] public string Text { get; set; }

        [JsonProperty("type")] public string Type { get; set; }
    }

    public class ExternalIds
    {
        [JsonProperty("isrc")] public string Isrc { get; set; }

        [JsonProperty("ean")] public string Ean { get; set; }

        [JsonProperty("upc")] public string Upc { get; set; }
    }

    public class Image
    {
        [JsonProperty("url")] public Uri Url { get; set; }

        [JsonProperty("height")] public long Height { get; set; }

        [JsonProperty("width")] public long Width { get; set; }
    }

    public class Restrictions
    {
        [JsonProperty("reason")] public string Reason { get; set; }
    }

    public class TemperaturesArtist
    {
        [JsonProperty("external_urls")] public ExternalUrls ExternalUrls { get; set; }

        [JsonProperty("followers")] public Followers Followers { get; set; }

        [JsonProperty("genres")] public string[] Genres { get; set; }

        [JsonProperty("href")] public string Href { get; set; }

        [JsonProperty("id")] public string Id { get; set; }

        [JsonProperty("images")] public Image[] Images { get; set; }

        [JsonProperty("name")] public string Name { get; set; }

        [JsonProperty("popularity")] public long Popularity { get; set; }

        [JsonProperty("type")] public string Type { get; set; }

        [JsonProperty("uri")] public string Uri { get; set; }
    }

    public class Followers
    {
        [JsonProperty("href")] public string Href { get; set; }

        [JsonProperty("total")] public long Total { get; set; }
    }

    public class LinkedFrom
    {
    }
}