using Newtonsoft.Json;

namespace ASAssessment.Models
{
    public class GithubUser
    {
        [JsonProperty("login")]
        public string Username { get; set; }
        [JsonProperty("avatar_url")]
        public string AvatarUrl { get; set; }

        [JsonProperty("repos_url")]
        public string RepositoriesUrl { get; set; }

        private string LocationResult;

        [JsonProperty("location")]
        public string Location
        {
            get => LocationResult ?? "Location not available.";
            set => LocationResult = value;
        }
    }
}