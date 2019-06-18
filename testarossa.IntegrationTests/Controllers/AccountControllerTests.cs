using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using testarossa.Api;
using testarossa.Infrastructure.Commands.Users;
using testarossa.IntegrationTests.Controllers;
using Xunit;

namespace testarossa.IntegrationTests
{
    public class AccountControllerTests : ControllerTestsBase
    {
       
        [Fact]
        public async Task given_valid_current_and_new_password_it_should_be_changed()
        {
            var command = new ChangeUserPassword
            {
                CurrentPassword = "password1",
                NewPassword = "password2"
            };
            var payload = GetPayload(command);
            var response = await client.PostAsync("accounts/password", payload);
            Assert.Equal(HttpStatusCode.NoContent, response.StatusCode);
        }
    }
}
