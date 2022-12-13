using Microsoft.AspNetCore.Mvc.Testing;
using System.Threading.Tasks;
using Xunit;

namespace TestProject
{
    public class ControllerIntegrationTest: IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly WebApplicationFactory<Program> _factory;

        public ControllerIntegrationTest(WebApplicationFactory<Program> factory)
        {
            _factory = factory;
        }

        [Theory]
        [InlineData("api/material")]
        [InlineData("api/users/mentors")]
        [InlineData("api/users/mentors/1")]
        [InlineData("api/users/student/1")]
        [InlineData("api/users/students")]
        [InlineData("api/material/1")]
        [InlineData("api/teams/demos")]
        [InlineData("api/teams")]
        [InlineData("api/teams/1")]
        [InlineData("api/teams/1/students")]
        
        public async Task Get_EndpointsReturnSuccessAndCorrectContentType(string url)
        {
            // Arrange
            var client = _factory.CreateClient();

            // Act
            var response = await client.GetAsync(url);

            // Assert
            response.EnsureSuccessStatusCode(); // Status Code 200-299
            Assert.Equal("application/json; charset=utf-8",
                response.Content.Headers.ContentType.ToString());
        }
    }
}