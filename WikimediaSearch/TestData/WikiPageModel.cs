using System;
using Newtonsoft.Json;

namespace WikiPageModel
{
    public class Latest
    {
        [JsonProperty("id")]
        public int? id { get; set; }
        [JsonProperty("timestamp")]
        public DateTime? timestamp { get; set; }
    }

    public class License
    {
        [JsonProperty("url")]
        public string? url { get; set; }
        [JsonProperty("title")]
        public string? title { get; set; }
    }

    public class WikiPage
    {
        [JsonProperty("id")]
        public int? id { get; set; }
        [JsonProperty("key")]
        public string? key { get; set; }
        [JsonProperty("title")]
        public string? title { get; set; }
        [JsonProperty("latest")]
        public Latest? latest { get; set; }
        [JsonProperty("content_model")]
        public string? content_model { get; set; }
        [JsonProperty("license")]
        public License? license { get; set; }
        [JsonProperty("html_url")]
        public string? html_url { get; set; }
    }
}

