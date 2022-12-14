using CodecoolAdvanced.Model;
using Microsoft.AspNetCore.Mvc.Testing;
using System;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
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
    
        private JsonSerializerOptions options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };
     

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
            Assert.Equal("application/json; charset=utf-8", response.Content.Headers.ContentType.ToString());
        }

        [Fact]
        public async Task Post_Api_MaterialReturnSuccessAndCorrectContentType()
        {
            HttpContent content = new StringContent("");
            var client = _factory.CreateClient();
            var response =await client.PostAsync("api/material?name=alma", content);
            response.EnsureSuccessStatusCode(); // Status Code 200-299
            string json = await response.Content.ReadAsStringAsync();
            EducationalMaterial eduMat = JsonSerializer.Deserialize<EducationalMaterial>(json, options)!; 
            Assert.Equal("application/json; charset=utf-8", response.Content.Headers.ContentType?.ToString());
            Assert.Equal("alma", eduMat.Name);
        }
        [Fact]
        public async Task Put_Api_MaterialReturnSuccessAndCorrectContentType()
        {
            HttpContent content = new StringContent("");
            var client = _factory.CreateClient();
            var response = await client.PostAsync("api/material?name=alma", content);
            string json = await response.Content.ReadAsStringAsync();
            EducationalMaterial eduMat = JsonSerializer.Deserialize<EducationalMaterial>(json, options)!;
            var response2 = await client.PutAsync($"api/material/{eduMat.ID}/add?material=Tanc", content);
            response2.EnsureSuccessStatusCode();
            var response3 = await client.GetAsync($"api/material/{eduMat.ID}");
            string json2 = await response2.Content.ReadAsStringAsync();
            EducationalMaterial eduMat2 = JsonSerializer.Deserialize<EducationalMaterial>(json2, options)!;
            Assert.Equal("Tanc", eduMat2.Materials.FirstOrDefault().Name);
            Assert.Equal("application/json; charset=utf-8", response.Content.Headers.ContentType?.ToString());
        }

        [Fact]
        public async Task Delete_Api_MaterialReturnSuccessAndCorrectContentType()
        {
            // Arrange
            HttpContent content = new StringContent("");
            var client = _factory.CreateClient();
            var response = await client.PostAsync("api/material?name=alma", content);
            string json = await response.Content.ReadAsStringAsync();
            EducationalMaterial eduMaterial = JsonSerializer.Deserialize<EducationalMaterial>(json, options)!;
            var putResponse = await client.PutAsync($"api/material/{eduMaterial.ID}/add?material=Tanc", content);
            var response2 = await client.GetAsync($"api/material/{eduMaterial.ID}");
            string jsonString = await response2.Content.ReadAsStringAsync();
            EducationalMaterial eduMat2 = JsonSerializer.Deserialize<EducationalMaterial>(jsonString, options)!;
            // Act
            var id = eduMat2.Materials.FirstOrDefault().ID;
            var response3 = await client.DeleteAsync($"api/material/{id}/remove");
            Console.WriteLine(eduMat2.Materials.FirstOrDefault().ID);
            // Assert
            response3.EnsureSuccessStatusCode();
            Assert.Equal(null, response3.Content.Headers.ContentType?.ToString());
        }
        [Fact]
        public async Task Delete_Api_EducationMaterialReturnSuccessAndCorrectContentType()
        {
            HttpContent content = new StringContent("");
            var client = _factory.CreateClient();
            var response = await client.PostAsync("api/material?name=alma", content);
            string json = await response.Content.ReadAsStringAsync();
            EducationalMaterial eduMat = JsonSerializer.Deserialize<EducationalMaterial>(json, options)!;
            var response2 = await client.DeleteAsync($"api/material/{eduMat.ID}");
            response2.EnsureSuccessStatusCode();
            Assert.Equal(null, response2.Content.Headers.ContentType?.ToString());
        }
        
    }
}