using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using Xunit;

namespace MyCore.IntegrationTest
{
    public class WeatherForecastControllerTests
    {
        [Fact]
        public async Task Get()
        {
            // Arrange
            var hostBuilder = new HostBuilder()
                .ConfigureWebHost(webHost =>
                {
                    // Add TestServer
                    webHost.UseTestServer();

                    // Specify the environment
                    webHost.UseEnvironment("Testing");

                    webHost.UseStartup<Startup>();
                });

            var host = await hostBuilder.StartAsync();
            var client = host.GetTestClient();

            // Act
            var response = await client.GetAsync("/WeatherForecast");

            // Assert
            var responseString = await response.Content.ReadAsStringAsync();

            var weatherForecast = JsonConvert.DeserializeObject<List<WeatherForecast>>(responseString);

            Assert.Equal(5, weatherForecast.Count);
        }
    }
}
