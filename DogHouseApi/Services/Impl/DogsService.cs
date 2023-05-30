using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DogHouseApi.Constants;
using DogHouseApi.DataBase.Entities;
using DogHouseApi.DataBase.Repositories.Abstractions;
using DogHouseApi.Extensions;
using DogHouseApi.Models.Dto;
using DogHouseApi.Services.Abstractions;

namespace DogHouseApi.Services.Impl
{
    public class DogsService : IDogsService
    {
        private IDogsRepository DogsRepository { get; }

        public DogsService(IDogsRepository dogsRepo)
        {
            DogsRepository = dogsRepo;
        }

        public async Task AddDog(AddDogDto dto)
        {
            if (await DogsRepository.DogExists(dto.Name))
                throw new ArgumentException(ExceptionMessages.DogAlreadyExists);

            var dog = new Dog
            {
                Name = dto.Name,
                Color = dto.Color,
                TailLength = dto.TailLength,
                Weight = dto.Weight
            };

            await DogsRepository.AddDog(dog);
        }

        public Task<List<Dog>> GetDogs(GetDogsDto dto)
        {
            var sortAttribute = dto.Attribute?.ToPascalCase();
            var sortOrder = dto.Order;
            
            if (sortOrder == null ^ sortAttribute == null)
                throw new ArgumentException(ExceptionMessages.SortArgumentsError);

            if (sortAttribute != null && typeof(Dog).GetProperty(sortAttribute) == null)
                throw new ArgumentException($"{ExceptionMessages.AttributeDoesNotExist} {dto.Attribute}");
            
            var offset = (int)((dto.PageNumber - 1) * dto.PageSize);
            var limit = (int)dto.PageSize;
            
            return DogsRepository.GetSortedDogs(sortAttribute, sortOrder, offset, limit);
        }
    }
}