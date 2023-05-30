namespace DogHouseApi.Models.Dto
{
    public record GetDogsDto
    {
        public string Attribute { get; set; }
        public string Order { get; set; }
        public uint PageNumber { get; set; } = 1;
        public uint PageSize { get; set; } = 10;
    }
}