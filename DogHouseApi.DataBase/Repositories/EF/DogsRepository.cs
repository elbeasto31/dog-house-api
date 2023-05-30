using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DogHouseApi.DataBase.Entities;
using DogHouseApi.DataBase.Repositories.Abstractions;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.EF;

namespace DogHouseApi.DataBase.Repositories.EF
{
    public class DogsRepository : IDogsRepository
    {
        private DbSet<Dog> Items => DbContext.Dogs;
        private DogHouseDbContext DbContext { get; }

        public DogsRepository(DogHouseDbContext dbContext)
        {
            DbContext = dbContext;
        }

        public async Task AddDog(Dog dog)
        {
            await DbContext.Dogs.AddAsync(dog);
            await DbContext.SaveChangesAsync();
        }

        public Task<bool> DogExists(string name)
            => Items.AnyAsync(x => x.Name == name);

        public Task<List<Dog>> GetSortedDogs(string sortProperty, string sortOrder, int offset, int limit)
        {
            var sortedDogs = sortOrder switch
            {
                "desc" => Items.OrderByDescending(d => Property<object>(d, sortProperty)),
                "asc" => Items.OrderBy(d => Property<object>(d, sortProperty)),
                null => Items.AsQueryable(),
                _ => throw new ArgumentException($"Wrong sort order input: {sortOrder}")
            };

            return sortedDogs.Skip(offset).Take(limit).ToListAsync();
        }
    }
}