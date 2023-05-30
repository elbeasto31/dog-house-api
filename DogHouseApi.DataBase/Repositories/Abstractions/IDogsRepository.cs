using System.Collections.Generic;
using System.Threading.Tasks;
using DogHouseApi.DataBase.Entities;

namespace DogHouseApi.DataBase.Repositories.Abstractions
{
    public interface IDogsRepository
    {
        Task AddDog(Dog dog);
        Task<bool> DogExists(string name);
        Task<List<Dog>> GetSortedDogs(string sortAttribute, string sortOrder, int offset, int limit);
    }
}