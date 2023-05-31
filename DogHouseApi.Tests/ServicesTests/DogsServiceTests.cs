using System;
using System.Threading.Tasks;
using DogHouseApi.DataBase.Entities;
using DogHouseApi.DataBase.Repositories.Abstractions;
using DogHouseApi.Models.Dto;
using DogHouseApi.Services.Impl;
using Moq;
using Xunit;

namespace DogHouseApi.Tests.ServicesTests
{
    public class DogsServiceTests
    {
        private Mock<IDogsRepository> _dogsRepositoryMock;
        private DogsService _dogsService;

        public DogsServiceTests()
        {
            _dogsRepositoryMock = new Mock<IDogsRepository>();
            _dogsService = new DogsService(_dogsRepositoryMock.Object);
        }

        [Fact]
        public async Task AddDogThrowsArgumentExceptionWhenDogExists()
        {
            // Arrange
            SetupDogExists(true);

            var dto = new AddDogDto();

            // Act and Assert
            await Assert.ThrowsAsync<ArgumentException>(() => _dogsService.AddDog(dto));
        }

        [Fact]
        public async Task AddDogCallsAddDogMethodWhenDogDoesNotExist()
        {
            // Arrange
            SetupDogExists(false);
            var dto = new AddDogDto();

            // Act
            await _dogsService.AddDog(dto);

            // Assert
            _dogsRepositoryMock.Verify(repo => repo.AddDog(It.IsAny<Dog>()), Times.Once);
        }

        [Fact]
        public async Task GetDogsThrowsArgumentExceptionWhenSortAttributeIsInvalid()
        {
            // Arrange
            var wrongAttributeDto = new GetDogsDto
            {
                Attribute = "invalidAttribute",
                Order = "desc"
            };

            // Act and Assert
            await Assert.ThrowsAsync<ArgumentException>(() => _dogsService.GetDogs(wrongAttributeDto));
        }

        [Fact]
        public async Task GetDogsThrowsArgumentExceptionWhenOneOfSortArgumentsIsNull()
        {
            // Arrange
            var nullAttributeDto = new GetDogsDto
            {
                Attribute = null,
                Order = "desc"
            };

            var nullOrderDto = new GetDogsDto
            {
                Attribute = "weight",
                Order = null
            };

            // Act and Assert
            await Assert.ThrowsAsync<ArgumentException>(() => _dogsService.GetDogs(nullAttributeDto));
            await Assert.ThrowsAsync<ArgumentException>(() => _dogsService.GetDogs(nullOrderDto));
        }

        [Fact]
        public async Task GetDogsCallsGetSortedDogsMethodWithCorrectParameters()
        {
            // Arrange
            var dto = new GetDogsDto
            {
                Attribute = "weight",
                Order = "desc"
            };

            // Act
            await _dogsService.GetDogs(dto);

            // Assert
            _dogsRepositoryMock.Verify(repo => repo.GetSortedDogs("Weight", "desc", 0, 10), Times.Once);
        }

        private void SetupDogExists(bool exists)
        {
            _dogsRepositoryMock
                .Setup(repo => repo.DogExists(It.IsAny<string>()))
                .ReturnsAsync(exists);
        }
    }
}