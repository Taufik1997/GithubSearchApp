using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using ASAssessment.Clients.Interfaces;
using ASAssessment.Models;
using Newtonsoft.Json;

public class GithubApiClient : IGithubApiClient
{
    private readonly GithubHttpClient _githubHttpClient;

    public GithubApiClient()
    {
        _githubHttpClient = new GithubHttpClient();
    }

    private async Task<T> SendRequestAndProcessResponse<T>(string requestUri)
    {
        var response = await _githubHttpClient.SendRequestAsync(requestUri).ConfigureAwait(false);
        if (response.IsSuccessStatusCode)
        {
            var content = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            return JsonConvert.DeserializeObject<T>(content);
        }
        else
        {
            var errorMessage = await response.Content.ReadAsStringAsync();
            if (response.StatusCode == HttpStatusCode.NotFound)
                throw new Exception($"The requested resource of type '{typeof(T).Name}' could not be found. Please check the provided value for accuracy and try again.");
            else
                throw new Exception($"Error occurred: {response.StatusCode} - {errorMessage}");
        }
    }

    public async Task<GithubUser> GetUserDetails(string username)
    {
        return await SendRequestAndProcessResponse<GithubUser>($"users/{username}")
            .ConfigureAwait(false);
    }

    public async Task<List<GithubRepository>> GetUserRepositories(string reposUrl)
    {
        return await SendRequestAndProcessResponse<List<GithubRepository>>(reposUrl)
            .ConfigureAwait(false);
    }
}
