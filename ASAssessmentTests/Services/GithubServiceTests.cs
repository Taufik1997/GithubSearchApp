
using ASAssessment.Clients.Interfaces;
using ASAssessment.Models;
using ASAssessment.Services;
using Moq;

namespace ASAssessment.Tests
{
    [TestClass]
    public class GithubServiceTests
    {
        private readonly Mock<IGithubApiClient> _mockGithubApiClient;
        private readonly GithubService _githubService;

        public GithubServiceTests()
        {
            _mockGithubApiClient = new Mock<IGithubApiClient>();
            _githubService = new GithubService(_mockGithubApiClient.Object);
        }

        [TestMethod]
        public void GetUserAndRepositories_ValidUsername_ReturnsUserViewModel()
        {
            #region Arrange

            var username = "testUser";

            var mockUserInformation = new GithubUser
            {
                Username = username,
                RepositoriesUrl = "",
                Location = "US"
            }; 

            var mockRepositories = new List<GithubRepository>();

            _mockGithubApiClient.Setup(client => client.GetUserDetails(username))
                .Returns(Task.FromResult(mockUserInformation));
            _mockGithubApiClient.Setup(client => client.GetUserRepositories(It.IsAny<string>()))
                .Returns(Task.FromResult(mockRepositories));

            #endregion Arrange

            #region Act

            var result = _githubService.GetUserAndRepositories(username);

            #endregion Act

            #region Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(mockUserInformation, result.User);
            Assert.AreEqual(mockRepositories, result.Repositories);

            #endregion Assert
        }


        [TestMethod]
        public void GetUserAndRepositories_ValidUsernameWithoutLocation_ReturnsUserViewModel()
        {
            #region Arrange
            var username = "testUser";
            var nullLocationResult = "Location not available.";

            var mockUserInformation = new GithubUser
            {
                Username = username,
                RepositoriesUrl = "",
            };

            var mockRepositories = new List<GithubRepository>();

            _mockGithubApiClient.Setup(client => client.GetUserDetails(username))
                .Returns(Task.FromResult(mockUserInformation));
            _mockGithubApiClient.Setup(client => client.GetUserRepositories(It.IsAny<string>()))
                .Returns(Task.FromResult(mockRepositories));

            #endregion Arrange

            #region Act

            var result = _githubService.GetUserAndRepositories(username);

            #endregion Act

            #region Assert

            Assert.IsNotNull(result);
            Assert.AreEqual(mockUserInformation, result.User);
            Assert.AreEqual(nullLocationResult, result.User.Location);
            Assert.AreEqual(mockRepositories, result.Repositories);

            #endregion Assert
        }

        [TestMethod]
        public void GetUserAndRepositories_EmptyUsername_ThrowsArgumentNullException()
        {
            #region Act & Assert

            var username = "";
            Assert.ThrowsException<ArgumentNullException>(() => _githubService.GetUserAndRepositories(username));

            #endregion Act & Assert
        }

        [TestMethod]
        public void GetUserAndRepositories_ApiClientThrowsException_ThrowsException()
        {
            #region Arrange

            var username = "testUser";
            _mockGithubApiClient.Setup(client => client.GetUserDetails(username))
                .Throws(new Exception("API Client Failure"));

            #endregion Arrange

            #region Act & Assert

            var exception = Assert.ThrowsException<Exception>(() => _githubService.GetUserAndRepositories(username));
            StringAssert.Contains(exception.Message, "Error while retrieving Github User");

            #endregion Act & Assert
        }
    }
}

