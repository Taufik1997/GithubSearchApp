using ASAssessment.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ASAssessment.Clients.Interfaces
{
    public interface IGithubApiClient
    {
        /// <summary>
        /// Retrieves detailed information about a user from Github's API.
        /// </summary>
        /// <param name="username">The username of the GitHub user.</param>
        /// <returns>A task representing the asynchronous operation, returning an object containing GitHub user details.</returns>
        Task<GithubUser> GetUserDetails(string username);

        /// <summary>
        /// Retrieves a list of repositories belonging to a user from Github's API.
        /// </summary>
        /// <param name="reposUrl">The URL endpoint provided to access the user's repositories.</param>
        /// <returns>A task representing the asynchronous operation, returning a list of GitHub repositories.</returns>
        Task<List<GithubRepository>> GetUserRepositories(string reposUrl);

    }
}