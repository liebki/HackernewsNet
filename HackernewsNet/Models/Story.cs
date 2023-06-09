using Newtonsoft.Json;

namespace HackernewsNet.Models
{
    public class Story
    {
        [JsonProperty("by", NullValueHandling = NullValueHandling.Ignore)]
        public string By { get; set; }

        [JsonProperty("descendants", NullValueHandling = NullValueHandling.Ignore)]
        public long? Descendants { get; set; }

        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public long? Id { get; set; }

        [JsonProperty("score", NullValueHandling = NullValueHandling.Ignore)]
        public long? Score { get; set; }

        [JsonProperty("time", NullValueHandling = NullValueHandling.Ignore)]
        public long Time { get; set; }

        [JsonProperty("title", NullValueHandling = NullValueHandling.Ignore)]
        public string Title { get; set; }

        [JsonProperty("type", NullValueHandling = NullValueHandling.Ignore)]
        public string Type { get; set; }

        [JsonProperty("url", NullValueHandling = NullValueHandling.Ignore)]
        public Uri Url { get; set; }

        public DateTime TimeAsDate()
        {
            DateTimeOffset dateTimeOffset = DateTimeOffset.FromUnixTimeSeconds(this.Time);
            DateTime dateTime = dateTimeOffset.UtcDateTime;

            return dateTime;
        }

        public override string ToString()
        {
            return $"{{{nameof(By)}={By}, {nameof(Descendants)}={Descendants.ToString()}, {nameof(Id)}={Id.ToString()}, {nameof(Score)}={Score.ToString()}, {nameof(Time)}={Time.ToString()}, {nameof(Title)}={Title}, {nameof(Type)}={Type}, {nameof(Url)}={Url}}}";
        }
    }
}