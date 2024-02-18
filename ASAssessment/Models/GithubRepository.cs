using Newtonsoft.Json;

namespace ASAssessment.Models
{
    public class GithubRepository
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("stargazers_count")]
        public int StargazersCount { get; set; }

        [JsonProperty("html_url")]
        public string HtmlUrl { get; set; }
    }
}