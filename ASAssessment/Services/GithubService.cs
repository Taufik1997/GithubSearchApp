using ASAssessment.Clients.Interfaces;
using ASAssessment.Models;
using ASAssessment.Services.Interfaces;
using System;

namespace ASAssessment.Services
{
    public class GithubService : IGithubService
    {
        private readonly IGithubApiClient _githubApiClient;

        public GithubService(IGithubApiClient githubApiClient)
        {
            _githubApiClient = githubApiClient;
        }

        public GitHubUserViewModel GetUserAndRepositories(string username)
        {
            if (string.IsNullOrEmpty(username))
                throw new ArgumentNullException(nameof(username), "Username cannot be null or empty.");

            try
            {
                var userInformation = _githubApiClient.GetUserDetails(username)
                    .GetAwaiter()
                    .GetResult();

                var repositories = _githubApiClient.GetUserRepositories(userInformation.RepositoriesUrl)
                    .GetAwaiter()
                    .GetResult();

                var userModel = new GitHubUserViewModel
                {
                    User = userInformation,
                    Repositories = repositories
                };

                return userModel;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error while retrieving Github User with username: {username}, {ex.Message}",ex);
            }
        }
    }
}