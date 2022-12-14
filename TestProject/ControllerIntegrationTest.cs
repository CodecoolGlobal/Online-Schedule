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

        [Fact]
        public async Task Post_Api_TeamReturnSuccessAndCorrectContentType()
        {
            HttpContent content = new StringContent("");
            var client = _factory.CreateClient();
            var response = await client.PostAsync("api/teams?studentId=1&name=haki&repo=github.com", content);
            response.EnsureSuccessStatusCode(); // Status Code 200-299
            string json = await response.Content.ReadAsStringAsync();
            Team team = JsonSerializer.Deserialize<Team>(json, options)!;
            Assert.Equal("application/json; charset=utf-8", response.Content.Headers.ContentType?.ToString());
            Assert.Equal("haki", team.Name);
        }
        

        [Fact]
        public async Task Put_Api_Teams_Name_Change_ReturnSuccessAndCorrectContentType()
        {
            HttpContent content = new StringContent("");
            var client = _factory.CreateClient();
            var response = await client.PostAsync("api/teams?studentId=1&name=haki&repo=github.com", content);
            string json = await response.Content.ReadAsStringAsync();
            Team team = JsonSerializer.Deserialize<Team>(json, options)!;
            var response2 = await client.PutAsync($"api/teams/{team.Id}?newName=Tancosok", content);
            response2.EnsureSuccessStatusCode();
            var response3 = await client.GetAsync($"api/teams/{team.Id}");
            string json2 = await response3.Content.ReadAsStringAsync();
            Team team2 = JsonSerializer.Deserialize<Team>(json2, options)!;
            Assert.Equal("Tancosok",team2.Name);
            Assert.Equal(null, response2.Content.Headers.ContentType?.ToString());
        }

        [Fact]
        public async Task Delete_Api_TeamReturnSuccessAndCorrectContentType()
        {
            HttpContent content = new StringContent("");
            var client = _factory.CreateClient();
            var response = await client.PostAsync("api/teams?studentId=1&name=haki&repo=github.com", content);
            string json = await response.Content.ReadAsStringAsync();
            Team team = JsonSerializer.Deserialize<Team>(json, options)!;
            var response2 = await client.DeleteAsync($"api/teams/{team.Id}");
            response2.EnsureSuccessStatusCode();
            Assert.Equal(null, response2.Content.Headers.ContentType?.ToString());
        }

        [Fact]
        public async Task Put_Api_Teams_reviewTime_change_ReturnSuccessAndCorrectContentType()
        {
            HttpContent content = new StringContent("");
            var client = _factory.CreateClient();
            var response = await client.PostAsync("api/teams?studentId=1&name=haki&repo=github.com", content);
            string json = await response.Content.ReadAsStringAsync();
            Team team = JsonSerializer.Deserialize<Team>(json, options)!;
            var response2 = await client.PutAsync($"api/teams/{team.Id}/review?reviewTime=2022-12-14T10%3A54%3A39.6374337&type=siStart", content);
            response2.EnsureSuccessStatusCode();
            var response3 = await client.GetAsync($"api/teams/{team.Id}");
            string json2 = await response3.Content.ReadAsStringAsync();
            Team team2 = JsonSerializer.Deserialize<Team>(json2, options)!;
            Assert.Equal("2022-12-14T10:54:39.6374337", team2.SiReviewStart);
            Assert.Equal(null, response2.Content.Headers.ContentType?.ToString());
        }

        [Fact]
        public async Task Put_Api_Teams_add_member_ReturnSuccessAndCorrectContentType()
        {
            // Arrange
            HttpContent content = new StringContent("");
            var client = _factory.CreateClient();
            var response = await client.PostAsync("api/teams?studentId=1&name=haki&repo=github.com", content);
            string json = await response.Content.ReadAsStringAsync();
            Team team = JsonSerializer.Deserialize<Team>(json, options)!;

            var responseStudent = await client.PostAsync("api/users/student?name=Sanya&email=email@amail.hu&password=jijiji", content);
            string json2 = await responseStudent.Content.ReadAsStringAsync();
            Student student = JsonSerializer.Deserialize<Student>(json2, options)!;
            // Act
            var response2 = await client.PutAsync($"api/teams/{team.Id}/add/{student.ID}", content);
            
            var response3 = await client.GetAsync($"api/teams/{team.Id}");
            string json3 = await response3.Content.ReadAsStringAsync();
            Team team2 = JsonSerializer.Deserialize<Team>(json3, options)!;
            // Assert
            response2.EnsureSuccessStatusCode();
            Assert.Equal("Sanya", team2.Students.FirstOrDefault(x=> x.ID == student.ID).Name);
            Assert.Equal(null, response2.Content.Headers.ContentType?.ToString());
        }

        [Fact]
        public async Task Put_Api_Teams_delete_member_ReturnSuccessAndCorrectContentType()
        {
            // Arrange
            HttpContent content = new StringContent("");
            var client = _factory.CreateClient();
            var response = await client.PostAsync("api/teams?studentId=1&name=haki&repo=github.com", content);
            string json = await response.Content.ReadAsStringAsync();
            Team team = JsonSerializer.Deserialize<Team>(json, options)!;

            var responseStudent = await client.PostAsync("api/users/student?name=Sanya&email=email@amail.hu&password=jijiji", content);
            string json2 = await responseStudent.Content.ReadAsStringAsync();
            Student student = JsonSerializer.Deserialize<Student>(json2, options)!;
            
            var response2 = await client.PutAsync($"api/teams/{team.Id}/add/{student.ID}", content);
            // Act
            var responseDelete = await client.PutAsync($"api/teams/{team.Id}/remove/{student.ID}", content);
            var response3 = await client.GetAsync($"api/teams/{team.Id}");
            string json3 = await response3.Content.ReadAsStringAsync();
            Team team2 = JsonSerializer.Deserialize<Team>(json3, options)!;
            // Assert
            responseDelete.EnsureSuccessStatusCode();
            Assert.Equal(null, team2.Students.FirstOrDefault(x => x.ID == student.ID));
            Assert.Equal(null, response2.Content.Headers.ContentType?.ToString());
        }
    }
}