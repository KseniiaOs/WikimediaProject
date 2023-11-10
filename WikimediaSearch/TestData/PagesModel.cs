using System;
using Newtonsoft.Json;

namespace PagesModel
{
    public class Page
    {
        [JsonProperty("id")]
        public int? id { get; set; }
        [JsonProperty("key")]
        public string? key { get; set; }
        [JsonProperty("title")]
        public string? title { get; set; }
        [JsonProperty("excerpt")]
        public string? excerpt { get; set; }
        [JsonProperty("matched_title")]
        public string? matched_title { get; set; }
        [JsonProperty("description")]
        public string? description { get; set; }
        [JsonProperty("thumbnail")]
        public Thumbnail? thumbnail { get; set; }
    }

    public class Pages
    {
        [JsonProperty("pages")]
        public List<Page> pages { get; set; }
    }

    public class Thumbnail
    {
        [JsonProperty("mimetype")]
        public string? mimetype { get; set; }
        [JsonProperty("size")]
        public int? size { get; set; }
        [JsonProperty("width")]
        public int? width { get; set; }
        [JsonProperty("height")]
        public int? height { get; set; }
        [JsonProperty("duration")]
        public int? duration { get; set; }
        [JsonProperty("url")]
        public string? url { get; set; }
    }

}

