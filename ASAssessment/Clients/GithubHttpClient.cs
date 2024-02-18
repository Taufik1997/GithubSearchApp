using ASAssessment.Clients.Interfaces;
using System;
using System.Net.Http;
using System.Threading.Tasks;

public class GithubHttpClient : IGithubHttpClient
{
    private readonly HttpClient _httpClient;

    public GithubHttpClient()
    {
        _httpClient = new HttpClient
        {
            BaseAddress = new Uri("https://api.github.com/")
        };
        _httpClient.DefaultRequestHeaders.UserAgent.Add(new System.Net.Http.Headers.ProductInfoHeaderValue("AppName", "1.0"));
    }

    public async Task<HttpResponseMessage> SendRequestAsync(string requestUri)
    {
        return await _httpClient.GetAsync(requestUri).ConfigureAwait(false);
    }
}