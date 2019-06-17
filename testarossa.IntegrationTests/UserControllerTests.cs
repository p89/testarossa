using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Newtonsoft.Json;
using testarossa.Api;
using testarossa.Infrastructure.Commands.Users;
using testarossa.Infrastructure.DTO;
using Xunit;

namespace testarossa.IntegrationTests
{
    
    public class UserControllerTests
    {
        private readonly TestServer _server;
        private readonly HttpClient _client;
        
        public UserControllerTests()
        
        {
            _server = new TestServer(new WebHostBuilder()
                .UseStartup<Startup>());
            _client = _server.CreateClient();
        }

        [Fact]
        public async Task given_valid_email_user_should_exist()
        {
            var email = "mail1@gmail.com";
            var user = await GetUser(email);

            Assert.Equal(email, user.Email);
        }

        [Fact]
        public async Task given_invalid_email_user_should_not_exist()
        {
            var email = "mail1000@gmail.com";
            var response = await _client.GetAsync($"users/{email}");
            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }

        [Fact]
        public async Task given_unique_email_user_should_be_created()
        {
            var email = "mails0010@gmail.com";
            var request = new CreateUser
            {
                Email = email,
                Password = "password1",
                Username = "supername"
            };
            var payload = GetPayload(request);
            var response = await _client.PostAsync("users", payload);
            Assert.Equal(HttpStatusCode.Created, response.StatusCode);
            Assert.Equal($"users/{request.Email}", response.Headers.Location.ToString());

            var user = await GetUser(request.Email);
            Assert.Equal(user.Email, request.Email);
        }

        private StringContent GetPayload(object data)
        {
            var json = JsonConvert.SerializeObject(data);
            return new StringContent(json, Encoding.UTF8, "application/json");
        }

        private async Task<UserDTO> GetUser(string email)
        {
            var response = await _client.GetAsync($"users/{email}");
            var responseString = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<UserDTO>(responseString);
        }
    }
}
