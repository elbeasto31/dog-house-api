using System.Linq;

namespace DogHouseApi.Extensions
{
    public static class NamingCaseExtensions
    {
        public static string ToSnakeCase(this string str)
            => string.Concat(str.Select((x, i) => i > 0 && char.IsUpper(x) ? "_" + x : x.ToString())).ToLower();

        public static string ToPascalCase(this string str)
            => string.Concat(str.Split("_").Select(word => char.ToUpper(word[0]) + word.Substring(1)));
    }
}