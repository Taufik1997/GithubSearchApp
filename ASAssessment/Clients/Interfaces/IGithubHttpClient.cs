using System.Net.Http;
using System.Threading.Tasks;


namespace ASAssessment.Clients.Interfaces
{
    public interface IGithubHttpClient
    {
        /// <summary>
        /// Sends an asynchronous generic HTTP request.
        /// </summary>
        /// <param name="requestUri">The URI of the request.</param>
        /// <returns>A task representing the asynchronous operation, returning an HTTP response message.</returns>
        Task<HttpResponseMessage> SendRequestAsync(string requestUri);
    }
}