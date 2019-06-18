using System.Net.Http;
using System.Text;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Newtonsoft.Json;
using testarossa.Api;

namespace testarossa.IntegrationTests.Controllers
{
    public abstract class ControllerTestsBase
    {
        protected readonly TestServer server;
        protected readonly HttpClient client;
        
        public ControllerTestsBase()
        {
            server = new TestServer(new WebHostBuilder()
                .UseStartup<Startup>());
            client = server.CreateClient();
        }

        protected StringContent GetPayload(object data)
        {
            var json = JsonConvert.SerializeObject(data);
            return new StringContent(json, Encoding.UTF8, "application/json");
        }
    }
}