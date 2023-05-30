using System.IO;
using System.Text;
using DogHouseApi.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Xunit;

namespace DogHouseApi.Tests.ControllerTests
{
    public class AppControllerTests
    {
        [Fact]
        public void GetPingReturnsOkResult()
        {
            // Arrange
            var appSettings = @"{""AppSettings"":{""Version"" : ""1.0.1""}}";
            var builder = new ConfigurationBuilder();
            builder.AddJsonStream(new MemoryStream(Encoding.UTF8.GetBytes(appSettings)));

            var configuration = builder.Build();
            var controller = new AppController(configuration);

            // Act
            var result = controller.GetPing();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.False(string.IsNullOrEmpty(okResult.Value.ToString()));
        }
    }
}