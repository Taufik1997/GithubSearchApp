using ASAssessment.Models;

namespace ASAssessment.Services.Interfaces
{
    public interface IGithubService
    {
        /// <summary>
        /// Retrieves detailed information about a GitHub user along with their repository list.
        /// </summary>
        /// <param name="username">The GitHub username of the user.</param>
        /// <returns>A GitHubUserViewModel containing the user's information and their repositories.</returns>
        GitHubUserViewModel GetUserAndRepositories(string username);

    }
}