using System.Text.Json;
using DogHouseApi.Extensions;

namespace DogHouseApi.Utils.NamingPolicies
{
    public class SnakeCaseNamingPolicy : JsonNamingPolicy
    {
        public static SnakeCaseNamingPolicy Instance { get; }

        static SnakeCaseNamingPolicy()
        {
            Instance = new();
        }

        public override string ConvertName(string name)
            => name.ToSnakeCase();
    }
}