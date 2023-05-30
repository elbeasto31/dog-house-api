namespace DogHouseApi.DataBase.Entities
{
    public record Dog
    {
        public string Name { get; set; }
        public string Color { get; set; }
        public uint TailLength { get; set; }
        public uint Weight { get; set; }
    }
}