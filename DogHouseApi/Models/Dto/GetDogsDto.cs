using System.ComponentModel.DataAnnotations;
using DogHouseApi.Constants;

namespace DogHouseApi.Models.Dto
{
    public record GetDogsDto
    {
        public string Attribute { get; set; }


        [RegularExpression("^(desc|asc)$", ErrorMessage = ExceptionMessages.SortOrderValidation)]
        public string Order { get; set; }

        [Range(1, uint.MaxValue, ErrorMessage = ExceptionMessages.PageNumberRange)]
        public uint PageNumber { get; set; } = 1;

        public uint PageSize { get; set; } = 10;
    }
}