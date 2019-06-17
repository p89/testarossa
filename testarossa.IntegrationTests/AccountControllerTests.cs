using System;
using System.Net.Http;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using testarossa.Api;

namespace testarossa.IntegrationTests
{
    
    public class AccountControllerTests
    {
        private readonly TestServer _server;
        private readonly HttpClient _client;
        
        public AccountControllerTests()
        
        {
            _server = new TestServer(new WebHostBuilder()
                .UseStartup<Startup>());
            _client = _server.CreateClient();
        }
    }
}
