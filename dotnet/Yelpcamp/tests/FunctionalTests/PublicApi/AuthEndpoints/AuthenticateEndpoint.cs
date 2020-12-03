using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Xunit;
using Yelpcamp.ApplicationCore.Constants;
using Yelpcamp.ApplicationCore.Extensions;
using Yelpcamp.PublicApi.AuthEndpoints;

namespace FunctionalTests.PublicApi.AuthEndpoints
{
    [Collection("Sequential")]
    public class AuthenticateEndpoint : IClassFixture<ApiTestFixture>
    {
        public AuthenticateEndpoint(ApiTestFixture factory)
        {
            Client = factory.CreateClient();
        }

        public HttpClient Client { get; }

        [Theory]
        [InlineData("rjnay@microsoft.com", AuthorizationConstants.DEFAULT_PASSWORD, true)]
        [InlineData("rjnay@microsoft.com", "badpassword", false)]
        [InlineData("baduser@microsoft.com", "badpassword", false)]
        public async Task ReturnsExpectedResultGivenCredentials(string testUsername, string testPassword, bool expectedResult)
        {
            var request = new AuthenticateRequest()
            {
                Username = testUsername,
                Password = testPassword
            };
            var jsonContent = new StringContent(JsonSerializer.Serialize(request), Encoding.UTF8, "application/json");
            var response = await Client.PostAsync("api/authenticate", jsonContent);
            response.EnsureSuccessStatusCode();
            var stringResponse = await response.Content.ReadAsStringAsync();
            var model = stringResponse.FromJson<AuthenticateResponse>();

            Assert.Equal(expectedResult, model.Result);
        }
    }
}
