namespace DogHouseApi.Models.Dto
{
    public record AddDogDto
    {
        public string Name { get; set; }
        public string Color { get; set; }
        public uint TailLength { get; set; }
        public uint Weight { get; set; }
    }
}