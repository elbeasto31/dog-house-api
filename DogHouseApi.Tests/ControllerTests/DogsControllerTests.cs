using System.Collections.Generic;
using System.Threading.Tasks;
using DogHouseApi.Controllers;
using DogHouseApi.DataBase.Entities;
using DogHouseApi.Models.Dto;
using DogHouseApi.Services.Abstractions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace DogHouseApi.Tests.ControllerTests
{
    public class DogsControllerTests
    {
        private readonly DogsController _dogsController;
        private readonly Mock<IDogsService> _dogsServiceMock;

        public DogsControllerTests()
        {
            _dogsServiceMock = new Mock<IDogsService>();
            _dogsController = new DogsController(_dogsServiceMock.Object);
        }

        [Fact]
        public async Task GetDogsReturnsOkResult()
        {
            // Arrange
            _dogsServiceMock.Setup(service => service.GetDogs(It.IsAny<GetDogsDto>()))
                .ReturnsAsync(new List<Dog>());

            var dto = new GetDogsDto();

            // Act
            var result = await _dogsController.GetDogs(dto);

            // Assert
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async Task AddDogReturnsOkResult()
        {
            // Arrange
            _dogsServiceMock.Setup(service => service.AddDog(It.IsAny<AddDogDto>()))
                .Returns(Task.CompletedTask);

            var dto = new AddDogDto();

            // Act
            var result = await _dogsController.AddDog(dto);

            // Assert
            Assert.IsType<OkResult>(result);
        }
    }
}