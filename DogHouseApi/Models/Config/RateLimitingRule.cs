namespace DogHouseApi.Models.Config
{
    public record RateLimitingRule
    {
        public string Endpoint { get; set; }
        public string Period { get; set; }
        public int Limit { get; set; }
    }
}