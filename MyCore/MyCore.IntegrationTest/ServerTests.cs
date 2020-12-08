using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Hosting;
using Xunit;

namespace MyCore.IntegrationTest.API
{
    public class ServerTests
    {
        [Fact]
        public async Task GetAsync()
        {
            // Arrange
            var hostBuilder = new HostBuilder()
                .ConfigureWebHost(webHost =>
                {
                    // Add TestServer
                    webHost.UseTestServer();

                    // Specify the environment
                    webHost.UseEnvironment("Testing");

                    webHost.Configure(app => app.Run(async ctx => await ctx.Response.WriteAsync("Hello World!")));
                });

            var host = await hostBuilder.StartAsync();
            var client = host.GetTestClient();

            // Act
            var response = await client.GetAsync("/");

            // Assert
            var responseString = await response.Content.ReadAsStringAsync();
            Assert.Equal("Hello World!", responseString);
        }
    }
}
