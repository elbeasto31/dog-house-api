using System.ComponentModel.DataAnnotations;
using DogHouseApi.Constants;

namespace DogHouseApi.Models.Dto
{
    public record AddDogDto
    {
        [Required] public string Name { get; set; }

        [Required] public string Color { get; set; }

        public uint TailLength { get; set; }

        [Range(1, uint.MaxValue, ErrorMessage = ExceptionMessages.DogWeightRange)]
        public uint Weight { get; set; }
    }
}