using System.Collections.Generic;

namespace ASAssessment.Models
{
    public class GitHubUserViewModel
    {   
        public GithubUser User { get; set; } 
        public List<GithubRepository> Repositories { get; set; }
        public List<string> Errors { get; set; } = new List<string>();
        public string SuccessMessage { get; set; }
    }
}