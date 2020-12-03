using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
    public class RegisterEndpoint : IClassFixture<ApiTestFixture>
    {
        public RegisterEndpoint(ApiTestFixture factory)
        {
            Client = factory.CreateClient();
        }

        public HttpClient Client { get; }

        [Theory]
        [InlineData("testuser@example.com", AuthorizationConstants.DEFAULT_PASSWORD, HttpStatusCode.OK)]
        [InlineData("test", AuthorizationConstants.DEFAULT_PASSWORD, HttpStatusCode.BadRequest)]
        [InlineData("testuser@example.com", "pass", HttpStatusCode.BadRequest)]
        public async Task ReturnsExpectedResultGivenCredentials(string testEmail, string testPassword, HttpStatusCode statusCode)
        {
            var request = new RegisterRequest()
            {
                Email = testEmail,
                Password = testPassword
            };
            var jsonContent = new StringContent(JsonSerializer.Serialize(request), Encoding.UTF8, "application/json");
            var response = await Client.PostAsync("api/register", jsonContent);

            Assert.Equal(statusCode, response.StatusCode);
        }

    }
}
