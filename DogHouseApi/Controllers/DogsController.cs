using System.Threading.Tasks;
using DogHouseApi.Constants;
using DogHouseApi.Filters.Exception;
using DogHouseApi.Models.Dto;
using DogHouseApi.Services.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace DogHouseApi.Controllers
{
    [ApiController]
    [ArgumentExceptionFilter]
    public class DogsController : ControllerBase
    {
        #region Properties

        private IDogsService DogsService { get; }

        #endregion

        #region Constructor

        public DogsController(IDogsService dogsService)
        {
            DogsService = dogsService;
        }

        #endregion

        #region Get

        [Route(ApiRoutes.GetDogs)]
        [HttpGet]
        public async Task<IActionResult> GetDogs([FromQuery] GetDogsDto dto)
        {
            var dogs = await DogsService.GetDogs(dto);
            return Ok(dogs);
        }

        #endregion

        #region Post

        [Route(ApiRoutes.AddDog)]
        [HttpPost]
        public async Task<IActionResult> AddDog([FromBody] AddDogDto dto)
        {
            await DogsService.AddDog(dto);
            return Ok();
        }

        #endregion
    }
}