using System.Collections.Generic;
using System.Threading.Tasks;
using DogHouseApi.DataBase.Entities;
using DogHouseApi.Models.Dto;

namespace DogHouseApi.Services.Abstractions
{
    public interface IDogsService
    {
        Task AddDog(AddDogDto dto);
        Task<List<Dog>> GetDogs(GetDogsDto dto);
    }
}